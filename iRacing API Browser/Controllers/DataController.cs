using Aydsko.iRacingData;
using Microsoft.AspNetCore.Mvc;

namespace iRacing_API_Browser.Controllers
{
    public class DataController : Controller
    {
        private readonly IDataClient _iRacingDataClient;
        private readonly ILogger<HomeController> _logger;

        public DataController(IDataClient iRacingDataClient, ILogger<HomeController> logger)
        {
            _iRacingDataClient = iRacingDataClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Series(int seriesId)
        {
            if (seriesId > 0)
            {
                return View("SeriesInfo", seriesId);
            }
            else
            {
                var dataResponse = await _iRacingDataClient.GetSeriesAsync();
                return View("Series", dataResponse?.Data);
            }           
        }

        public async Task<IActionResult> Cars()
        {
            var dataResponse = await _iRacingDataClient.GetCarsAsync();
            return View(dataResponse?.Data);
        }

        public async Task<IActionResult> Tracks()
        {
            var dataResponse = await _iRacingDataClient.GetTracksAsync();
            return View(dataResponse?.Data);
        }
    }
}
