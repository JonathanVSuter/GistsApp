using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GistApp.ExtractModels
{
    public class File
    {
        [BsonField("filename")]
        [JsonPropertyName("filename")]
        public string Filename { get; set; }
        [BsonField("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [BsonField("language")]
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [BsonField("raw_url")]
        [JsonPropertyName("raw_url")]
        public string Raw_url { get; set; }
        [BsonField("size")]
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
