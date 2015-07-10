using Bifrost.Slack.Core;
using Bifrost.Slack.Core.Users;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.UI.Core.ViewModels
{
    public class AllUsersViewModel : MvxViewModel
    {
        private ISlackClient _slack;
        public AllUsersViewModel(ISlackClient slack)
        {
            _slack = slack;
        }

        #region Public Methods
        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <remarks>
        /// This gets called by the MVVMCross framework as part of the default view model lifecycle.
        /// </remarks>
        public override void Start()
        {
            base.Start();
            LoadAsync().ConfigureAwait(false);
        }
        #endregion

        #region Properties
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    ShowViewModel<UserDetailsViewModel>(new UserDetailsParameters { UserId = value.Id });
                }
            }
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Loads user data from Slack and populates the Users property.
        /// </summary>
        private async Task LoadAsync()
        {
            var userData = await _slack.Users.GetAllUsersAsync();

            var collection = new ObservableCollection<User>();
            
            // if Slack returned users, create viewmodels for them and add them to Users
            if (userData != null)
            {
                foreach(var user in userData)
                {
                    collection.Add(user);
                }
            }

            Users = collection;
        }
        #endregion
    }
}
