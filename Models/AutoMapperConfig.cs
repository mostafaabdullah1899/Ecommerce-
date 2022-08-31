using AutoMapper;
using Final_Project.ViewModel;

namespace Final_Project.Models
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get;private set; }

        static AutoMapperConfig() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductVM>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}
