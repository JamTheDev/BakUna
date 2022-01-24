using BakUna.LoginElements;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json;
using System.Dynamic;
using System.Globalization;

namespace BakUna.Utilities
{
    public static class Extensions
    {
        public static List<T> Join<T>(this List<T> first, List<T> second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToList();
        }

        public static string DictToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}";
        }

        public static string GenerateID(int len, string chars)
        {
            string random = string.Empty;
            for(int i = 0; i < len; i++)
            {
                random += chars[new Random().Next(0, chars.Length)];
            }
            return "_" + random;
        }

        public static string JsonToCsv(string jsonContent)
        {
            var expandos = JsonConvert.DeserializeObject<ExpandoObject[]>(jsonContent);

            using (var writer = new StringWriter())
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(expandos as IEnumerable<dynamic>);
                }

                return writer.ToString();
            }
        }



    }
}
