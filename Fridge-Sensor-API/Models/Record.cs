using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeSensorAPI.Models
{
    public class Record
    {
        [JsonProperty("h")]
        public float Humidity { get; set; }

        [JsonProperty("t")]
        public float Temperature { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("z")]
        public long TimeStamp { get; set; }
    }
}
