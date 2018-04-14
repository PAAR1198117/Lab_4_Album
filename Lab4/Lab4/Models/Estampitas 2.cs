using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lab4.Models
{
    public class Estampitas2
    {
        public static Dictionary<string, bool> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, bool>>(json, Lab4.Models.Converter2.Settings);
    }

    public static class Serialize2
    {
        public static string ToJson(this Dictionary<string, bool> self) => JsonConvert.SerializeObject(self, Lab4.Models.Converter2.Settings);
    }

    internal class Converter2
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}