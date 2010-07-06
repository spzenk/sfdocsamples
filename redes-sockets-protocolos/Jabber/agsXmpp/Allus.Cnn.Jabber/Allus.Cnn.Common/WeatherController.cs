using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISVCGetWeather = Allus.Cnn.Weather.ISVC.GetWeather;
using Fwk.HelperFunctions;
using Fwk.Bases.FrontEnd;
using Fwk.Bases;
using Allus.Cnn.Weather.ISVC.GetWeatherLocation;

namespace Allus.Cnn.Common
{
    public class WeatherController: ClientServiceBase
    {

        public Allus.Cnn.Weather.BE.WeatherBE GetWeather(String pLocationCode, String pLanguage)
        {
            Allus.Cnn.Weather.BE.WeatherBE wWeather = new Allus.Cnn.Weather.BE.WeatherBE();
            ISVCGetWeather.GetWeatherRequest wReq = new ISVCGetWeather.GetWeatherRequest();
            ISVCGetWeather.GetWeatherResponse wRes = new ISVCGetWeather.GetWeatherResponse();

            wReq.BusinessData.LocationCode = pLocationCode;
            wReq.BusinessData.Language = pLanguage;

            wReq.CacheSettings.CacheOnServerSide = true;
            wReq.CacheSettings.CacheOnClientSide = false;
            wReq.CacheSettings.ResponseCacheId = pLocationCode;
            //wReq.CacheSettings.TimeMeasures = DateFunctions.TimeMeasuresEnum.FromMinutes;
            //wReq.CacheSettings.ExpirationTime = 45;

            wRes = this.ExecuteService<ISVCGetWeather.GetWeatherRequest, ISVCGetWeather.GetWeatherResponse>(wReq);

            wWeather = Allus.Cnn.Weather.BE.WeatherBE.GetWeatherBEFromXml(wRes.BusinessData.GetXml());

            return wWeather;
        }

        public Allus.Cnn.Weather.ISVC.GetWeatherLocation.LocationBEList GetWeatherLocation()
        {
            GetWeatherLocationRequest wRequest = new GetWeatherLocationRequest();
            GetWeatherLocationResponse wResponse = new GetWeatherLocationResponse();

            wResponse = base.ExecuteService<GetWeatherLocationRequest, GetWeatherLocationResponse>(wRequest);

            if (wResponse.Error != null)
                throw Common.ProcessException(wResponse.Error);


            return wResponse.BusinessData;
        }
    }
}
