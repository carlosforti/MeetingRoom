using System.Collections.Generic;
using Ffsti.MeetingRoom.Domain;

namespace Ffsti.MeetingRoom.WebUI.ViewModel
{
    public class RoomMeetingViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}