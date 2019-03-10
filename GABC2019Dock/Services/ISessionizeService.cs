using GABC2019Dock.Models;
using GABC2019Dock.Models.ScheduleModel;
using GABC2019Dock.Models.Sessionize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Services
{
    public interface ISessionizeService
    {
        Task<SessionizeModel> GetSessionizeDataAsync(string sessionizeEndpoint);
        Task<List<Schedule>> GetScheduleAsync(string sessionizeEndpoint);
        Task<List<SpeakerModel>> GetSpeakersAsync(string sessionizeEndpoint);
    }
}
