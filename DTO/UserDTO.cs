using System.Text.Json.Serialization;

namespace YouTube_Clone.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("ClerkID")]
        public string? ClerkID { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("ImageURL")]
        public string? ImageURL { get; set; }
    }
}