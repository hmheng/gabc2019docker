using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Models.Sessionize
{
    public class Session
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public object startsAt { get; set; }
        public object endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<string> speakers { get; set; }
        public List<int> categoryItems { get; set; }
        public List<int> categoryItemsDetails { get; set; }
        public List<object> questionAnswers { get; set; }
        public object roomId { get; set; }

    }
    
    public class Speaker
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bio { get; set; }
        public string tagLine { get; set; }
        public string profilePicture { get; set; }
        public bool isTopSpeaker { get; set; }
        public List<Link> links { get; set; }
        public List<int> sessions { get; set; }
        public string fullName { get; set; }
    }

    public class Link
    {
        public string title { get; set; }
        public string url { get; set; }
        public string linkType { get; set; }
    }
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<Item> items { get; set; }
        public int sort { get; set; }
    }

    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
    }

    public class SessionizeModel
    {
        public List<Session> sessions { get; set; }
        public List<Speaker> speakers { get; set; }
        public List<object> questions { get; set; }
        public List<Category> categories { get; set; }
        public List<Room> rooms { get; set; }

        public List<Session> GetSessionsByCategoryId(List<Session> sessions, string CategoryId)
        {
            List<Session> _sessions = new List<Session>();
            _sessions = sessions.Where(x => (x.categoryItems.Count > 0) ? (x.categoryItems[0].ToString() == CategoryId) : false).ToList();
            return _sessions;
        }
    }
}
