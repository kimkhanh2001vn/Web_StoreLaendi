using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LaendiStore.Common.ZContants;

namespace LaendiStore.Common
{
    public static class ConvertClass
    {
        public static T Xingleton<T>(string prefix = SpecialString.Blank)
        {
            var k = prefix + typeof(T).Name;

            if (_instances == null)
            {
                _instances = new Dictionary<string, object>();
            }

            var exists = _instances.Keys.Contains(k);
            if (!exists)
            {
                var o = Activator.CreateInstance(typeof(T), true);
                _instances.Add(k, o);
            }

            var res = (T)_instances[k];
            return res;
        }
        public static T Singleton<T>(string prefix = SpecialString.Blank)
        {
            // To support engine side calls
            if (HttpContext.Current == null)
            {
                return Xingleton<T>();
            }

            var k = prefix + typeof(T).Name;
            var o = HttpContext.Current.Items[k];

            if (o == null)
            {
                o = Activator.CreateInstance(typeof(T), true);
                HttpContext.Current.Items[k] = o;
            }

            var res = (T)HttpContext.Current.Items[k];
            return res;
        }

        private static Dictionary<string, object> _instances;
    }
}
