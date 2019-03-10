using GABC2019Dock.Models.Sessionize;
using GABC2019Dock.Models.ScheduleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Models
{
    public class IndexViewModel
    {
        public SessionizeModel sessionizeModel { get; set; }
        public List<Schedule> scheduleModel { get; set; }
        public List<SpeakerModel> speakerModel { get; set; }
    }
}
