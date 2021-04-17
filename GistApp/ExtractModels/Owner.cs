using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GistApp.ExtractModels
{
    public class Owner
    {
        [JsonPropertyName("id")]
        public int Id;       
        [JsonPropertyName("login")]
        public string Login {get;set;}
        [JsonPropertyName("node_id")]
        public string Node_id { get; set; }
        [JsonPropertyName("avatar_url")]
        public string Avatar_Url { get; set; }
        [JsonPropertyName("gravatar_id")]
        public string Gravatar_id { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("html_url")]
        public string Html_url { get; set; }
        [JsonPropertyName("followers_url")]
        public string Followers_url { get; set; }
        [JsonPropertyName("subscriptions_url")]
        public string Subscriptions_url { get; set; }
        [JsonPropertyName("repos_url")]
        public string Repos_url { get; set; }
        [JsonPropertyName("received_events_url")]
        public string Received_events_url { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("site_admin")]
        public bool Site_adm { get; set; }
    }
}
