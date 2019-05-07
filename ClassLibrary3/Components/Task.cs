using Newtonsoft.Json;

namespace ClassLibrary3.Components
{
    [JsonObject]
    public class AmoModel
    {
        public AmoApiAddTask[] add { get; set; }
    }
    public class AmoApiAddTask
    {
        [JsonProperty("element_id")]
        public int element_id { get; set; }
        [JsonProperty("element_type")]
        public int element_type { get; set; }
        [JsonProperty("complete_till_at")]
        public long complete_till_at { get; set; }
        [JsonProperty("task_type")]
        public int task_type { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("created_at")]
        public long created_at { get; set; }
        [JsonProperty("updated_at")]
        public long updated_at { get; set; }
        [JsonProperty("responsible_user_id")]
        public int responsible_user_id { get; set; }
        [JsonProperty("created_by")]
        public int created_by { get; set; }
    }
}
