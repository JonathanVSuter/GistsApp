using GistApp.ExtractModels;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GistApp.ExtractModels
{
    public class PostGistItem : IBaseExtractModel
    {
        [BsonId]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [BsonField("node_id")]
        [JsonPropertyName("node_id")]
        public string Node_Id { get; set; }
        [BsonField("git_pull_url")]
        [JsonPropertyName("git_pull_url")]
        public string Git_Pull_Url { get; set; }
        [BsonField("git_push_url")]
        [JsonPropertyName("git_push_url")]
        public string Git_Push_Url { get; set; }
        [BsonField("html_url")]
        [JsonPropertyName("html_url")]
        public string Html_Url { get; set; }
        [BsonField("Files")]
        [JsonIgnore]
        public List<File> Files {get; set;}
        [BsonIgnore]
        [JsonIgnore]
        private IDictionary<string, JsonElement> _FilesObj;
        [JsonPropertyName("files")]
        [BsonIgnore]
        public IDictionary<string, JsonElement> FilesObj
        {
            get 
            {
                return _FilesObj;
            }
            set
            {
                _FilesObj = value;
                //convert the complex object to model
                Files = value.Cast<KeyValuePair<string, JsonElement>>()
                    .Select(x => x.Value)
                    .Cast<JsonElement>()
                    .Select(y=> new File() 
                    {
                        Filename = y.GetProperty("filename").GetString(),
                        Language = y.GetProperty("language").GetString(),
                        Raw_url = y.GetProperty("raw_url").GetString(),
                        Type = y.GetProperty("type").GetString(),
                        Size = y.GetProperty("size").GetInt32()
                    }).ToList();                
            }
        }
        [BsonField("owner")]
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new Owner();
        [BsonField("url")]
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [BsonField("forks_url")]
        [JsonPropertyName("forks_url")]
        public string Forks_Url { get; set; }
        [BsonField("commits_url")]
        [JsonPropertyName("commits_url")]
        public string Commits_Url { get; set; }
        [BsonField("public")]
        [JsonPropertyName("public")]
        public bool Ispublic { get; set; }
        [BsonField("updated_at")]
        [JsonPropertyName("updated_at")]
        public DateTime Updated_at { get; set; }
        [BsonField("created_at")]
        [JsonPropertyName("created_at")]
        public DateTime Created_at { get; set; }
        [BsonField("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [BsonField("comments")]
        [JsonPropertyName("comments")]
        public int Comments { get; set; }
        [BsonField("user")]
        [JsonPropertyName("user")]
        public string User { get; set;}
        [BsonField("comments_url")]
        [JsonPropertyName("comments_url")]
        public string Comments_url { get; set; }
        [BsonField("truncated")]
        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }
    }
}
