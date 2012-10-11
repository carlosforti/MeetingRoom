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
    public class MeetingService : BaseService<Meeting>, IMeetingService
    {
        private ModelStateWrapper modelState = new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary());

        public MeetingService() :
            base(new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary()), new MeetingRepository()) { }

        public MeetingService(IValidationDictionary validationDictionary) :
            base(validationDictionary, new MeetingRepository()) { }

        public MeetingService(IValidationDictionary validationDictionary, IGenericRepository<Meeting> repository) :
            base(validationDictionary, repository) { }

        public MeetingService(ModelStateDictionary modelState) :
            base(new ModelStateWrapper(modelState), new MeetingRepository()) { }

        public override bool IsValid(Meeting entity)
        {            
            var otherMeeting = this.Search(m => m.RoomId == entity.RoomId &&
                //Verifica se existe alguma reunião no periodo entre o início e o final da desejada
                (m.Start >= entity.Start && m.Finish <= entity.Finish) ||
                //Verifica se existe alguma reunião que começe após o inicio da desejada, e acabe após o final desejado
                (m.Start >= entity.Start && m.Finish >= entity.Finish) ||
                //Verifica se existe alguma reunião que começe antes do inicio da desejada, e termine antes ou durante o periodo desejado
                (m.Start <= entity.Start && (m.Start >= entity.Finish || m.Finish <= entity.Finish)) ||
                //Verifica se existe alguma reunião que começe depois do inicio da desejada, e antes ou termine durante o periodo desejado
                (m.Start >= entity.Start && (m.Start >= entity.Finish || m.Finish <= entity.Finish)))
                .FirstOrDefault();
            if (otherMeeting != null)
                this.modelState.AddError("Start", string.Format("Já existe uma reunião agendada no período de {0} à {1}",
                    otherMeeting.Start, otherMeeting.Finish));

            return base.IsValid(entity);
        }
    }
}
