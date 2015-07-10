using Bifrost.Slack.Core;
using Bifrost.Slack.Core.Users;
using Cirrious.CrossCore;
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
        private ObservableCollection<UserDetailsViewModel> _users;
        public ObservableCollection<UserDetailsViewModel> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        public UserDetailsViewModel SelectedUser
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    ShowViewModel<UserDetailsViewModel>(new UserDetailsParameters { UserId = value.UserId.GetUserId() });
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
            // Load from cache first
            Initialize(await _slack.Users.GetAllUsersAsync());
            // Try to fetch from the server
            Initialize(await _slack.Users.GetAllUsersAsync(true));
        }

        /// <summary>
        /// Populates the Users property with a list of User objects.
        /// </summary>
        /// <param name="users">Users to be displayed.</param>
        private void Initialize(IEnumerable<User> users)
        {
            var collection = new ObservableCollection<UserDetailsViewModel>();

            // if Slack returned users, create viewmodels for them and add them to Users
            if (users != null)
            {
                foreach (var user in users)
                {
                    var userVM = Mvx.IocConstruct<UserDetailsViewModel>();
                    userVM.Initialize(user).ConfigureAwait(false);
                    collection.Add(userVM);
                }
            }

            Users = collection;
        }
        #endregion
    }
}
