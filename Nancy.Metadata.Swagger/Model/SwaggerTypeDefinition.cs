using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nancy.Metadata.Swagger.Model
{
    public class SwaggerTypeDefinition
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("required")]
        public List<string> RequiredProperties { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, SwaggerTypeDefinition> Properties { get; set; }
    }
}