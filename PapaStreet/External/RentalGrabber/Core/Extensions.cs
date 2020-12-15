using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SiteGrabber.Core
{
    public static class Extensions
    {
        public static JObject ParseJson(this string str)
        {
            try
            {
                return JObject.Parse(str);
            }
            catch 
            {
                return null;
            }
        }

        public static string[] TrimArray(this string[] array)
        {
            return array.Select(s => s?.Trim(" \r\t\n".ToCharArray())).ToArray();
        }
        public static string Safe(this int i)
        {
            return i.ToString();
        }
        public static string Safe(this decimal? i)
        {
            return i.ToString();
        }
        public static string Safe(this object i)
        {
            if (i == null) return "NULL";
            var json = JsonConvert.SerializeObject(i);
            return "N'" + json.Replace("'", "''") + "'";
        }
        public static string Safe(this List<int> list)
        {
            if (list == null) list = new List<int>();
            return $"'{string.Join(",", list)}'";
        }

        public static string Safe(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "NULL";
            }
            str = str.Replace("\\r", "");
            str = str.Replace("\\n", "");
            str = str.Replace("\\t", "");

            str = str.Replace("'", "''");
            str = str.Trim(" \r\t\n".ToCharArray());
        
            return $"N'{str}'";
        }

        public static IEnumerable<string> TrimList(this IEnumerable<string> list)
        {
            return list.Select(str => str?.Trim(" \r\t\n".ToCharArray()));
        }
    }
}