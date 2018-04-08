using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lab4.Models
{
    public partial class Estampitas1
    {
        [JsonProperty("faltantes")]
        public List<long> Faltantes { get; set; }

        [JsonProperty("coleccionadas")]
        public List<long> Coleccionadas { get; set; }

        [JsonProperty("cambios")]
        public List<long> Cambios { get; set; }
    }

    public partial class Estampitas1
    {
        public static List<Dictionary<string, Estampitas1>> FromJson(string json) => JsonConvert.DeserializeObject<List<Dictionary<string, Estampitas1>>>(json, Lab4.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Dictionary<string, Estampitas1>> self) => JsonConvert.SerializeObject(self, Lab4.Models.Converter.Settings);
    }

    internal class Converter
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