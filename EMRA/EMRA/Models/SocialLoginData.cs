using System;
using System.Collections.Generic;
using System.Text;

namespace EMRA.Models
{
    public class SocialLoginData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string userPicture { get; set; }
        public FacebookPicture ProfilePicture { get; set; }
        public string Background { get; set; }
        public string Foreground { get; set; }

    }
}
