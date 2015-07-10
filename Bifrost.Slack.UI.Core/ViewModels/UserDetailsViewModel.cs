using Bifrost.Slack.Core;
using Bifrost.Slack.Core.Users;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.UI.Core.ViewModels
{
    /// <summary>
    /// Navigation parameters that can be passed to the ShowViewModel call
    /// when requesting the UserDetailsViewModel.
    /// </summary>
    public class UserDetailsParameters : IUserId
    {
        public string UserId { get; set; }
        public string GetUserId() { return UserId; }
    }

    public class UserDetailsViewModel : MvxViewModel
    {
        private User _user;
        private ISlackClient _slack;
        public UserDetailsViewModel(ISlackClient slack)
        {
            _slack = slack;
        }

        #region Public Methods
        /// <summary>
        /// Initializes the view model and populates the specified Slack User.
        /// </summary>
        /// <param name="parameters">Initialization parameters, including the user ID to be loaded.</param>
        /// <remarks>This is called by the MVVMCross framework if an instance of
        /// UserDetailsParameters was provied in the ShowViewModel navigation call.</remarks>
        public void Init(UserDetailsParameters parameters)
        {
            Load(parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Populates the view model for the given Slack User.
        /// </summary>
        /// <param name="user">User that the view model represents.</param>
        public void Initialize(User user)
        {
            _user = user;
            RealName = _user.RealName;
        }
        #endregion

        #region Properties
        private string _realName;
        public string RealName
        {
            get { return _realName; }
            set { SetProperty(ref _realName, value); }
        }
        #endregion

        /// <summary>
        /// Loads the user from Slack.
        /// </summary>
        /// <param name="id">User ID to be loaded.</param>
        private async Task Load(IUserId id)
        {
            var user = await _slack.Users.GetUserAsync(id);
            if (user != null)
            {
                Initialize(user);
            }
        }
    }
}
