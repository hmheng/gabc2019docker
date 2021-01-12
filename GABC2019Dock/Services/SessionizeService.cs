using GABC2019Dock.Models;
using GABC2019Dock.Models.ScheduleModel;
using GABC2019Dock.Models.Sessionize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GABC2019Dock.Services
{
    public class SessionizeService : ISessionizeService
    {
        HttpClient _httpClient = new HttpClient();

        public async Task<SessionizeModel> GetSessionizeDataAsync(string sessionizeEndpoint)
        {
            SessionizeModel sessionizeModel = null;
            try
            {
                if (_httpClient != null)
                {
                    var response = await _httpClient.GetAsync(sessionizeEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        sessionizeModel = JsonConvert.DeserializeObject<SessionizeModel>(await response.Content.ReadAsStringAsync());
                        sessionizeModel.sessions = sessionizeModel.sessions.OrderBy(x => x.roomId).ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return sessionizeModel;

        }

        public async Task<List<Schedule>> GetScheduleAsync(string sessionizeEndpoint)
        {
            List<Schedule> scheduleModel = null;
            try
            {
                if (_httpClient != null)
                {
                    var response = await _httpClient.GetAsync(sessionizeEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        scheduleModel = JsonConvert.DeserializeObject<List<Schedule>>(str);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return scheduleModel;

        }

        public async Task<List<SpeakerModel>> GetSpeakersAsync(string sessionizeEndpoint)
        {
            List<SpeakerModel> speakers = null;
            try
            {
                if (_httpClient != null)
                {
                    var response = await _httpClient.GetAsync(sessionizeEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        speakers = JsonConvert.DeserializeObject<List<SpeakerModel>>(str);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return speakers;

        }
    }
}
