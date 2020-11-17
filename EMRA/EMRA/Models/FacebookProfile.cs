using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRA.Models
{
    public class FacebookProfile
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        public FacebookPicture Picture { get; set; }
    }

    public class FacebookPicture
    {
        public ImageData Data { get; set; }
    }
    public class ImageData
    {
        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}