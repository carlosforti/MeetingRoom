using Ffsti.MeetingRoom.Data;
using Ffsti.MeetingRoom.Data.Interfaces;
using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service.Interfaces;
using Ffsti.MeetingRoom.Service.Validation;
using Ffsti.MeetingRoom.Service.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Ffsti.MeetingRoom.Service
{
    public class ContactService: BaseService<Contact>, IContactService
    {
        private ModelStateWrapper modelState = new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary());

        public ContactService() :
            base(new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary()), new ContactRepository()) { }

        public ContactService(IValidationDictionary validationDictionary) :
            base(validationDictionary, new ContactRepository()) { }

        public ContactService(IValidationDictionary validationDictionary, IGenericRepository<Contact> repository) :
            base(validationDictionary, repository) { }

        public ContactService(ModelStateDictionary modelState) :
            base(new ModelStateWrapper(modelState), new ContactRepository()) { }

        public override bool IsValid(Contact entity)
        {
            var otherContact = this.Search(c => c.FirstName == entity.FirstName && c.LastName == entity.LastName);
            if (otherContact != null)
                this.modelState.AddError("FirstName", "Já existe um contato com essa combinação de Nome e Sobrenome");

            return base.IsValid(entity);
        }
    }
}
