using System.Collections.Generic;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.WebUI.ViewModel
{
    public class ReservaSalaViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Meeting> Reservations { get; set; }
    }
}