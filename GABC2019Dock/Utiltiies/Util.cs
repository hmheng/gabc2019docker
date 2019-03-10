using GABC2019Dock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Utiltiies
{
    public static class Util
    {
        public static string GetProfileSpeakers(List<SpeakerModel> speakers, string speakerId)
        {
            if(speakers.Count> 0 && speakerId != null)
            {
                var speaker = speakers.Where(x => x.id == speakerId).FirstOrDefault();
                return speaker.profilePicture;
            }
            else
            {
                return "";
            }
        }
    }
}
