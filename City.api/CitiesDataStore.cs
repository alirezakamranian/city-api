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
                    new CityDto(){Id=1,Name="teroon",Description="hi im kami",
                        PointsOfIntrest =new List<PointsOfIntrestDto>()
                        { 
                            new PointsOfIntrestDto()
                            {
                                Id=1,
                                Name="khooneh",
                                Description="kheyli khoobeh"
                            }
                    }   },

                    new CityDto(){Id=2,Name="tiroon",Description="hi im kami",
                        PointsOfIntrest =new List<PointsOfIntrestDto>()
                        {
                            new PointsOfIntrestDto()
                            {
                                Id=2,
                                Name="masjed",
                                Description="kheyli khoobeh"
                            },
                            new PointsOfIntrestDto()
                            {
                                Id=3,
                                Name="karavansara",
                                Description="kheyli khoobeh"
                            }
                    }   },

                    new CityDto(){Id=3,Name="njebad",Description="hi im kami",
                        PointsOfIntrest =new List<PointsOfIntrestDto>()
                        {
                            new PointsOfIntrestDto()
                            {
                                Id=4,
                                Name="haramsara",
                                Description="kheyli khoobeh"
                            }
                        }
                    }
            };
        }
    }
}
