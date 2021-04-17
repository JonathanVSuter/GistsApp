using GistApp.ExtractModels;
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
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("node_id")]
        public string Node_Id { get; set; }
        [JsonPropertyName("git_pull_url")]
        public string Git_Pull_Url { get; set; }
        [JsonPropertyName("git_push_url")]
        public string Git_Push_Url { get; set; }
        [JsonPropertyName("html_url")]
        public string Html_Url { get; set; }       
        [JsonIgnore]
        public List<File> Files {get; set;}
        [JsonIgnore]
        private IDictionary<string, JsonElement> _FilesObj;
        [JsonPropertyName("files")]
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
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new Owner();
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("forks_url")]
        public string Forks_Url { get; set; }
        [JsonPropertyName("commits_url")]
        public string Commits_Url { get; set; }
        [JsonPropertyName("public")]
        public bool Ispublic { get; set; }
        [JsonPropertyName("updated_at")]
        public string Updated_at { get; set; }
        [JsonPropertyName("created_at")]
        public string Created_at { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("comments")]
        public int Comments { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set;}
        [JsonPropertyName("comments_url")]
        public string Comments_url { get; set; }
        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }
    }
}
