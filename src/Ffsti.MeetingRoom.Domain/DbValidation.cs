using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Validates whether a value is set in another row at the same column.
    /// Does not validate null empty or whitespace strings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueAttribute : ValidationAttribute
    {

        private readonly Type _ContextType;
        public Type ContextType
        {
            get
            {
                return _ContextType;
            }
        }


        //TODO: If placed in your domain, uncomment and replace MyDbContext with your domain's DbContext/ObjectContext class.
        //public UniqueAttribute() : this(typeof(MyDbContext)) { }


        /// <summary>
        /// Initializes a new instance of <see cref="UniqueAttribute"/>.
        /// </summary>
        /// <param name="contextType">The type of <see cref="DbContext"/> or <see cref="ObjectContext"/> subclass that will be used to search for duplicates.</param>
        public UniqueAttribute(Type contextType)
        {
            if (contextType == null)
                throw new ArgumentNullException("contextType");
            if (!contextType.IsSubclassOf(typeof(DbContext)) && !contextType.IsSubclassOf(typeof(ObjectContext)))
                throw new ArgumentException("The contextType Type must be a subclass of DbContext or ObjectContext.", "contextType");
            if (contextType.GetConstructor(Type.EmptyTypes) == null)
                throw new ArgumentException("The contextType type must declare a public parameterless consructor.");

            _ContextType = contextType;
        }


        /// <summary>
        /// Validates the value against the matching columns in the other rows of this table.
        /// Note that this method does not validate null or empty strings.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the <see cref="ValidationResult"/> class.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || (value is string && string.IsNullOrWhiteSpace((string)value))) return ValidationResult.Success;

            var type = validationContext.ObjectType;
            var property = type.GetProperty(validationContext.MemberName);
            type = property.DeclaringType;

            using (var dbcontext = (IDisposable)Activator.CreateInstance(_ContextType))
            {
                var context = dbcontext is DbContext ? ((IObjectContextAdapter)dbcontext).ObjectContext : (ObjectContext)dbcontext;
                var md = context.MetadataWorkspace;
                var entityType = md.GetItems<EntityType>(DataSpace.CSpace).SingleOrDefault(et => et.Name == type.Name);

                while (entityType.BaseType != null)
                    entityType = (EntityType)entityType.BaseType;

                var objectType = typeof(object);
                var isInherited = false;
                var baseType = type;
                while (baseType.Name != entityType.Name && baseType.BaseType != objectType)
                {
                    baseType = baseType.BaseType;
                    isInherited = true;
                }

                var methodCreateObjectSet = typeof(ObjectContext).GetMethod("CreateObjectSet", Type.EmptyTypes).MakeGenericMethod(baseType);
                var baseObjectSet = (ObjectQuery)methodCreateObjectSet.Invoke(context, new object[] { });
                var objectSet = baseObjectSet;
                var setType = baseObjectSet.GetType();

                if (isInherited)
                {
                    var ofType = setType.GetMethod("OfType");
                    ofType = ofType.MakeGenericMethod(type);
                    objectSet = (ObjectQuery)ofType.Invoke(baseObjectSet, null);
                    setType = objectSet.GetType();
                }

                var methodWhere = setType.GetMethod("Where");

                var eSql = string.Format("it.{0} = @{0}", validationContext.MemberName);

                var query = (ObjectQuery)methodWhere.Invoke(objectSet,
                  new object[] { eSql, new[] { new ObjectParameter(validationContext.MemberName, value) } });

                var result = query.Execute(MergeOption.NoTracking).Cast<object>();

                bool isValid = true;
                using (var enumerator = result.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        var nameProperty = typeof(ObjectSet<>).MakeGenericType(baseType).GetProperty("EntitySet");
                        var entitySet = (EntitySet)nameProperty.GetValue(baseObjectSet, null);
                        var entitySetName = entitySet.Name;

                        do
                        {
                            var current = enumerator.Current;
                            var curKey = context.CreateEntityKey(entitySetName, current);
                            var validatingKey = context.CreateEntityKey(entitySetName, validationContext.ObjectInstance);

                            if (curKey != validatingKey)
                            {
                                isValid = false;
                                break;
                            }
                        } while (enumerator.MoveNext());
                    }
                }

                return isValid ?
                  ValidationResult.Success :
                  new ValidationResult(
                    string.Format("There is already a '{0}' record that has its '{1}' field set to '{2}'.",
                      validationContext.ObjectType.Name,
                      validationContext.DisplayName,
                      value),
                    new[] { validationContext.MemberName });
            }
        }
    }
}