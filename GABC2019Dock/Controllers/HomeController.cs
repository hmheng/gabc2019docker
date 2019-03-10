using GABC2019Dock.Models;
using GABC2019Dock.Models.ScheduleModel;
using GABC2019Dock.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GABC2019Dock.Controllers
{
    public class HomeController : Controller
    {
        private ISessionizeService _sessionizeService;
        public HomeController(ISessionizeService sessionizeService)
        {
            _sessionizeService = sessionizeService;
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.sessionizeModel = await _sessionizeService.GetSessionizeDataAsync("https://sessionize.com/api/v2/30hmbobr/view/all");
            indexViewModel.scheduleModel = await _sessionizeService.GetScheduleAsync("https://sessionize.com/api/v2/30hmbobr/view/grid");
            indexViewModel.speakerModel = await _sessionizeService.GetSpeakersAsync("https://sessionize.com/api/v2/30hmbobr/view/speakers");
            indexViewModel.scheduleModel = SetPlenumSession(indexViewModel.scheduleModel);

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public List<Schedule> SetPlenumSession(List<Schedule> schedules)
        {
            List<Models.ScheduleModel.Session> plenumSessionList = new List<Models.ScheduleModel.Session>();
            List<Schedule> scheduleList = new List<Schedule>();
            if (schedules.Count > 0)
            {
                foreach (var r in schedules[0].rooms)
                {
                    var plenumSessions = r.sessions.Where(x => x.isPlenumSession).ToList();
                    if (plenumSessions.Count > 0)
                    {
                        plenumSessionList.AddRange(plenumSessions);
                    }
                    else
                    {
                        r.sessions.AddRange(plenumSessionList);
                    }

                    r.sessions = r.sessions.OrderBy(x => x.startsAt).ToList();

                }
                scheduleList = schedules;
            }
            return scheduleList;
        }

    }
}
