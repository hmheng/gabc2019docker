using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Models.ScheduleModel
{
    public class Session
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<Speaker> speakers { get; set; }
        public List<CategoryItem> categories { get; set; }
        public int roomId { get; set; }
        public string room { get; set; }
    }

    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public string trackName { get; set; }
        public List<Session> sessions { get; set; }
        public int index { get; set; }
        public bool hasOnlyPlenumSessions { get; set; }
    }

    public class Speaker
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<CategoryItem> categoryItems { get; set; }
        public int sort { get; set; }
    }

    public class CategoryItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class TimeSlot
    {
        public string slotStart { get; set; }
        public List<Room> rooms { get; set; }
    }

    public class ScheduleModel
    {
        public List<Schedule> schedules { get; set; }

    }
    public class Schedule
    {

        public DateTime date { get; set; }
        public List<Room> rooms { get; set; }
        public List<TimeSlot> timeSlots { get; set; }


    }
}
