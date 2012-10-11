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
    public class RoomService: BaseService<Room>, IRoomService
    {
        private ModelStateWrapper modelState = new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary());

        public RoomService() :
            base(new ModelStateWrapper(new System.Web.Mvc.ModelStateDictionary()), new RoomRepository()) { }

        public RoomService(IValidationDictionary validationDictionary) :
            base(validationDictionary, new RoomRepository()) { }

        public RoomService(IValidationDictionary validationDictionary, IGenericRepository<Room> repository) :
            base(validationDictionary, repository) { }

        public RoomService(ModelStateDictionary modelState) :
            base(new ModelStateWrapper(modelState), new RoomRepository()) { }

        public override bool IsValid(Room entity)
        {
            var otherRoom = this.Search(c => c.Name == entity.Name);
            if (otherRoom != null)
                this.modelState.AddError("Name", "Já existe uma sala com esse nome");

            return base.IsValid(entity);
        }
    }
}
