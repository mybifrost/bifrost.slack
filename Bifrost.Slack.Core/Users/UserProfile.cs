using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users
{
    [DataContract]
    public class UserProfile
    {
        /// <summary>
        /// (Optional) First name provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// (Optional) Last name provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// (Optional) Full name based on the user's first and last name provided in their profile.
        /// </summary>
        [DataMember(Name = "real_name")]
        public string RealName { get; set; }

        /// <summary>
        /// (Optional) Normalized full name based on the user's first and last name provided in their profile.
        /// </summary>
        [DataMember(Name = "real_name_normalized")]
        public string RealNameNormalized { get; set; }

        /// <summary>
        /// (Optional) Title provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// (Optional) Skype username provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "skype")]
        public string SkypeUserName { get; set; }

        /// <summary>
        /// (Optional) Phone number provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "phone")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// (Optional) Email address provided by the user in their profile.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in 24px resolution.
        /// </summary>
        [DataMember(Name = "image_24")]
        public string ImageSource24 { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in 32px resolution.
        /// </summary>
        [DataMember(Name = "image_32")]
        public string ImageSourc32 { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in 48px resolution.
        /// </summary>
        [DataMember(Name = "imgge_48")]
        public string ImageSource48 { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in 72px resolution.
        /// </summary>
        [DataMember(Name = "image_72")]
        public string ImageSource72 { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in 192px resolution.
        /// </summary>
        [DataMember(Name = "image_192")]
        public string ImageSource192 { get; set; }

        /// <summary>
        /// Https URL for the user's profile image in its original resolution.
        /// </summary>
        [DataMember(Name = "image_original")]
        public string ImageSource { get; set; }
    }
}
