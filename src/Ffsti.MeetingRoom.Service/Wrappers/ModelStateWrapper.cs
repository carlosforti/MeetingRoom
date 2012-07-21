using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ffsti.MeetingRoom.Service.Validation;

namespace Ffsti.MeetingRoom.Service.Wrappers
{
    public class ModelStateWrapper: IValidationDictionary
    {
        private ModelStateDictionary modelState;

        public ModelStateWrapper(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        public void AddError(string key, string errorMessage)
        {
            this.modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid()
        {
            return this.modelState.IsValid;
        }
    }
}
