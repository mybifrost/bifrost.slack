using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users
{
    [DataContract]
    public class UserProfile
    {
        /// <summary>
        /// Primay key used for local cache.  Allow SQLite to auto-increment this as users are added.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

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
        private string _imageSource24;
        [DataMember(Name = "image_24")]
        public string ImageSource24
        {
            get { return _imageSource24; }
            set
            {
                _imageSource24 = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value);
            }
        }

        /// <summary>
        /// Https URL for the user's profile image in 32px resolution.
        /// </summary>
        private string _imageSource32;
        [DataMember(Name = "image_32")]
        public string ImageSource32
        {
            get { return _imageSource32; }
            set
            {
                _imageSource32 = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value);
            }
        }

        /// <summary>
        /// Https URL for the user's profile image in 48px resolution.
        /// </summary>
        private string _imageSource48;
        [DataMember(Name = "image_48")]
        public string ImageSource48
        {
            get { return _imageSource48; }
            set
            { 
                _imageSource48 = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value); 
            }
        }

        /// <summary>
        /// Https URL for the user's profile image in 72px resolution.
        /// </summary>
        private string _imageSource72;
        [DataMember(Name = "image_72")]
        public string ImageSource72
        {
            get { return _imageSource72; }
            set
            {
                _imageSource72 = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value);
            }
        }

        /// <summary>
        /// Https URL for the user's profile image in 192px resolution.
        /// </summary>
        private string _imageSource192;
        [DataMember(Name = "image_192")]
        public string ImageSource192
        {
            get { return _imageSource192; }
            set
            {
                _imageSource192 = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value);
            }
        }

        /// <summary>
        /// Https URL for the user's profile image in its original resolution.
        /// </summary>
        private string _imageSource;
        [DataMember(Name = "image_original")]
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = string.IsNullOrEmpty(value) ? value : Uri.UnescapeDataString(value);
            }
        }

        [ForeignKey(typeof(User))]
        public string UserId { get; set; }

        [OneToOne]
        public User User { get; set; }
    }
}
