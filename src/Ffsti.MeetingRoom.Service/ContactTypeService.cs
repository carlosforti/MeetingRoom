using System.Linq;
using System.Web.Mvc;
using Ffsti.MeetingRoom.Data;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service.Interfaces;
using Ffsti.MeetingRoom.Service.Validation;
using Ffsti.MeetingRoom.Service.Wrappers;

namespace Ffsti.MeetingRoom.Service
{
    public class ContactTypeService : BaseService<ContactType>, IContactTypeService
    {
        private ModelStateWrapper modelState = new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary());

        public ContactTypeService() :
            base(new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary()), new ContactTypeRepository()) { }

        public ContactTypeService(IValidationDictionary validationDictionary) :
            base(validationDictionary, new ContactTypeRepository()) { }

        public ContactTypeService(IValidationDictionary validationDictionary, IGenericRepository<ContactType> repository) :
            base(validationDictionary, repository) { }

        public ContactTypeService(ModelStateDictionary modelState) :
            base(new ModelStateWrapper(modelState), new ContactTypeRepository()) { }

        protected override bool ValidateData(ContactType entity)
        {
            var contactType = this.Search(c => c.Name == entity.Name).FirstOrDefault();
            if (contactType != null)
                this.modelState.AddError("Name", "O nome do tipo de contato já está sendo usado");

            return this.modelState.IsValid();
        }

        public override bool Add(ContactType entity)
        {
            if (!ValidateData(entity))
                return false;

            return base.Add(entity);
        }

        public override bool IsValid()
        {
            return this.modelState.IsValid();
        }
    }
}
