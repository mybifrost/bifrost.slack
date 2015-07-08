using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// Color used to display a colored username.
        /// </summary>
        [DataMember(Name = "color")]
        public string Color { get; set; }

        /// <summary>
        /// True if the user has been deleted, false otherwise.
        /// </summary>
        [DataMember(Name = "deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// True if the user has two-step verification, false otherwise.
        /// </summary>
        /// <remarks>
        /// This field will only be populated if you (1) are looking at your own user
        /// information, or (2) are a team admin or owner.
        /// </remarks>
        [DataMember(Name = "has_2fa")]
        public bool IsTwoStepVerificationEnabled { get; set; }

        /// <summary>
        /// True if the user has files available, false otherwise.
        /// </summary>
        [DataMember(Name = "has_files")]
        public bool HasFiles { get; set; }

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// True if the user is a team admin, false otherwise.
        /// </summary>
        [DataMember(Name = "is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// True if the user is a bot, false otherwise.
        /// </summary>
        [DataMember(Name = "is_bot")]
        public bool IsBot { get; set; }

        /// <summary>
        /// True if the user is a team owner, false otherwise.
        /// </summary>
        [DataMember(Name = "is_owner")]
        public bool IsOwner { get; set; }

        /// <summary>
        /// True if the user is the team's primary owner, false otherwise.
        /// </summary>
        [DataMember(Name = "is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }

        /// <summary>
        /// True if the user is restricted, false otherwise.
        /// </summary>
        [DataMember(Name = "is_restricted")]
        public bool IsRestricted { get; set; }

        /// <summary>
        /// True if the user is ultra restricted, false otherwise.
        /// </summary>
        [DataMember(Name = "is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }

        /// <summary>
        /// Username, without a leading @ sign.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// (Optional) Full name based on the user's first and last name provided in their profile.
        /// </summary>
        [DataMember(Name = "real_name")]
        public string RealName { get; set; }

        /// <summary>
        /// Prefered timezone for the user.
        /// </summary>
        [DataMember(Name = "tz")]
        public string Timezone { get; set; }

        /// <summary>
        /// Name of the user's prefered timezone.
        /// </summary>
        [DataMember(Name = "tz_label")]
        public string TimezoneName { get; set; }

        /// <summary>
        /// Timezone offset, in milliseconds, for the user's prefered timezone.
        /// </summary>
        [DataMember(Name = "tz_offset")]
        public long TimezoneOffset { get; set; }
    }
}
