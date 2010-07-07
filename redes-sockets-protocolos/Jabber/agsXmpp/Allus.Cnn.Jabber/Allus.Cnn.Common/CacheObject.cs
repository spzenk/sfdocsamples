using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Caching;
using System.Windows.Forms;
using System.Reflection;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    public  class SettingStorage
    {
        public static Storage Storage = new Storage();
        static string cacheName = Assembly.GetExecutingAssembly().GetName().Name + Environment.UserName;




        private static FwkCache _FwkCache;

        static SettingStorage()
        {
            try
            {
                _FwkCache = new FwkCache();

                if (_FwkCache.CheckIfCachingExists(cacheName))

                    Storage = (Storage)_FwkCache.GetItemFromCache(cacheName);
                else
                    Storage = new Storage();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Save()
        {
            _FwkCache.SaveItemInCache(cacheName, Storage, true);
        }
        public static void Clear()
        {
            _FwkCache.CacheManager.Flush();
            Storage.MeshBEList = null;
        }

        public static void ClearServiceCache()
        {
            FwkCache cache = Fwk.Caching.KwkCacheFactory.GetFwkCache("ServiceCache");
            cache.ClearAll();
        }
    }
    [Serializable]
    public class Storage
    {
        List<MeshBE> _MeshBEList;
        public List<MeshBE> MeshBEList
        {
            get { return _MeshBEList; }
            set { _MeshBEList = value; }
        }


        Allus.Cnn.Weather.BE.LocationBE _LocationBE;        
        public Allus.Cnn.Weather.BE.LocationBE LocationBE
        {
            get { return _LocationBE; }
            set { _LocationBE = value; }
        }

        private Int32 _WeatherRefreshTime;
        public Int32 WeatherRefreshTime
        {
            get
            {
                return _WeatherRefreshTime;
            }
            set
            {
                _WeatherRefreshTime = value;
            }
        }

    }
}
