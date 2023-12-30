using Aydsko.iRacingData;
using iRacing_API_Browser.Data;
using iRacing_API_Browser.Data.Models;
using iRacing_API_Browser.Models;
using Microsoft.AspNetCore.Mvc;

namespace iRacing_API_Browser.Controllers
{
    public class DataController : Controller
    {
        private readonly IDataClient _iRacingDataClient;
        private readonly ILogger<HomeController> _logger;
        private readonly iRacingContext _context;

        public DataController(iRacingContext context, IDataClient iRacingDataClient, ILogger<HomeController> logger)
        {
            _context = context;
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
            var carsViewModel = new CarsViewModel()
            {
                Cars = dataResponse?.Data
            };
            return View(carsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RateCar(IFormCollection fm)
        {
            // Add a rating to the car, save in DB
            _context.Add(new Car { Rating = Int32.Parse(fm["Rating"].ToString()) });
            var dataResponse = await _iRacingDataClient.GetCarsAsync();
            var cars = dataResponse?.Data;

            var carsViewModel = new CarsViewModel()
            {
                Cars = cars

            };
            return View("Cars", carsViewModel);
        }

        public async Task<IActionResult> Tracks()
        {
            var dataResponse = await _iRacingDataClient.GetTracksAsync();
            return View(dataResponse?.Data);
        }
    }
}
