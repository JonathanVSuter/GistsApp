using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GistApp.ExtractModels
{
    public class Owner
    {
        [BsonField("id")]
        [JsonPropertyName("id")]
        public int Id;
        [BsonField("login")]
        [JsonPropertyName("login")]
        public string Login {get;set;}
        [BsonField("node_id")]
        [JsonPropertyName("node_id")]
        public string Node_id { get; set; }
        [BsonField("avatar_url")]
        [JsonPropertyName("avatar_url")]
        public string Avatar_Url { get; set; }
        [BsonField("gravatar_id")]
        [JsonPropertyName("gravatar_id")]
        public string Gravatar_id { get; set; }
        [BsonField("url")]
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [BsonField("html_url")]
        [JsonPropertyName("html_url")]
        public string Html_url { get; set; }
        [BsonField("followers_url")]
        [JsonPropertyName("followers_url")]
        public string Followers_url { get; set; }
        [BsonField("subscriptions_url")]
        [JsonPropertyName("subscriptions_url")]
        public string Subscriptions_url { get; set; }
        [BsonField("repos_url")]
        [JsonPropertyName("repos_url")]
        public string Repos_url { get; set; }
        [BsonField("received_events_url")]
        [JsonPropertyName("received_events_url")]
        public string Received_events_url { get; set; }
        [BsonField("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [BsonField("site_admin")]
        [JsonPropertyName("site_admin")]
        public bool Site_adm { get; set; }
    }
}
