using City.api.Models;

namespace City.api
{
    public class CitiesDataStore
    {

        public  List<CityDto> Cities { get; set; }
        public static CitiesDataStore current { get; }=new CitiesDataStore();
        

        public CitiesDataStore()
        {
           
            Cities = new List<CityDto>()
            {
                    new CityDto(){Id=1,Name="teroon",Description="hi im kami" },
                    new CityDto(){Id=2,Name="tiroon",Description="hi im kami" },
                    new CityDto(){Id=3,Name="njebad",Description="hi im kami" }
            };
        }
    }
}
