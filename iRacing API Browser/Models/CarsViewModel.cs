using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Aydsko.iRacingData.Cars;

namespace iRacing_API_Browser.Models
{
    public class CarsViewModel : PageModel
    {
        [BindProperty]
        public Dictionary<int,int> CarRatings { get; set; } // Car Id, Car Rating

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public CarInfo[] Cars { get; set; }
    }
}
