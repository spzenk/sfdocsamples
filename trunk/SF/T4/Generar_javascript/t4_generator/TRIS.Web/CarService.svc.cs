using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using TRIS.BusinessObjects;
using TRIS.ViewModels;

namespace TRIS.Web
{
    [ServiceBehavior(InstanceContextMode = System.ServiceModel.InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CarService : ICarService
    {
        #region Members
        #endregion

        #region Properties

        private static List<Car> Cars { get; set; }

        #endregion

        #region Constructor(s)

        static CarService()
        {
            var car1 = new Car() { Id = Guid.NewGuid(), Brand = "VW", Model = "Golf", CO2 = 110, ImportDate = new DateTime(2013, 5, 10, 18, 30, 0), IsActive = true };
            car1.Options.Add(new Option() { Id = Guid.NewGuid(), Name = "Heated seats", CatalogPrice = 500 });
            car1.Options.Add(new Option() { Id = Guid.NewGuid(), Name = "Ashtray defroster", CatalogPrice = 75 });
            car1.AvailableYears = new List<int>() { 2011, 2012, 2013 };
            car1.AvailableCountries = new List<string>() { "GB", "BE", "NL", "DE" };
            var car2 = new Car() { Id = Guid.NewGuid(), Brand = "Ford", Model = "Mondeo", CO2 = 135, ImportDate = new DateTime(2013, 4, 18, 9, 5, 0), IsActive = true };
            car2.Options.Add(new Option() { Id = Guid.NewGuid(), Name = "Open windshield", CatalogPrice = 2100 });
            car2.Options.Add(new Option() { Id = Guid.NewGuid(), Name = "Wheels", CatalogPrice = 15000 });
            car2.AvailableYears = new List<int>() { 2012, 2013 };
            car2.AvailableCountries = new List<string>() { "FR", "BE", "NL" };
            Cars = new List<Car>() { car1, car2 };
        }

        #endregion

        public string GetCarList()
        {
            List<SimpleCarViewModel> listvm = new List<SimpleCarViewModel>();
            foreach (var car in Cars)
            {
                listvm.Add(AutoMapper.Mapper.Map<SimpleCarViewModel>(car));
            }
            return serializeToJson(listvm);
        }

        public string GetCar(string id)
        {
            var guid = Guid.Parse(id);
            var car = Cars.Where(c => c.Id == guid).FirstOrDefault();
            return serializeToJson(AutoMapper.Mapper.Map<CarViewModel>(car));
        }

        public string SetCar(Stream stream)
        {
            string json;
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var vm = Newtonsoft.Json.JsonConvert.DeserializeObject<CarViewModel>(json, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local
                });

            var car = Cars.Where(c => c.Id == vm.id).FirstOrDefault();
            if (car == null)
            {
                car = new Car() { Id = Guid.NewGuid() };
                Cars.Add(car);
            }
            car.Brand = vm.brand;
            car.Model = vm.model;
            car.ImportDate = vm.importdate;
            car.CO2 = vm.co2;
            car.IsActive = vm.isactive;

            return serializeToJson(car);
        }

        #region Helper Methods

        private string serializeToJson(object o)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(o, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local
            });

            return json;
        }

        #endregion
    }
}
