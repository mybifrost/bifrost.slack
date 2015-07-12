# bifrost.slack

How to Compile:

Nuget packages should be resolved when building - the solution is setup to have Visual Studios resolve any missing packages at build time

Behaviors SDK (XAML) and SQLite for Windows Phone 8.1 extensions are required.  The Behaviors SDK should already be installed as part of the Visual Studios install.  If you have not previously installed SQLite, visit the link below to install.
SQLite - https://visualstudiogallery.msdn.microsoft.com/5d97faf6-39e3-4048-a0bc-adde2af75d1b


About the App:

The application is setup to support Xamarin and leverages the MvvmCross framework for MVVM and IoC.  Both the Bifrost.Slack.Core and Bifrost.Slack.UI.Core projects could be reused by an Android or iOS application, allowing all of the business and app logic to be shared cross-platform.

Bifrost.Slack.Core - this PCL provides a reusable Slack client that can be reused in any MvvmCross application.  For this example the authorization token is hard-coded into the client, in a live app this would be provided at runtime once the user logs in to Slack.
Bifrost.Slack.UI.Core - this PCL uses the Slack client from Slack.Core and provides all of the ViewModel classes and application initialization.  Common converters are also stored here to be reused in Android or iOS projects.
Bifrost.Slack.UI.WinPhone - this is the actual Windows Phone project.  It provides the View layer to go along with the viewmodels from Slack.UI.Core as well as Windows-specific value converters.  This also implements the ISQLite interface from Slack.Core, creating a SQLite database in the local Windows file system.