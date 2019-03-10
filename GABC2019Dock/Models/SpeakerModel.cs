using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Models
{
    public class SpeakerModel
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bio { get; set; }
        public string tagLine { get; set; }
        public string profilePicture { get; set; }
        public bool isTopSpeaker { get; set; }
        public List<Link> links { get; set; }
        public List<Session> sessions { get; set; }
        public string fullName { get; set; }
    }

    public class Session
    {
        public int id { get; set; }
        public string name { get; set; }
    }


    public class Link
    {
        public string title { get; set; }
        public string url { get; set; }
        public string linkType { get; set; }
    }
}
