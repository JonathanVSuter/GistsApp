using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GistApp.ExtractModels
{
    public class File
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("raw_url")]
        public string Raw_url { get; set; }
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
