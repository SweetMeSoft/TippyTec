
using TippyTec.Handlers;
using TippyTec.Models;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace TippyTec
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Preferences.Clear();
            if (!Preferences.ContainsKey(Constants.AppInitializated))
            {
                DBHandler.Instance.DeleteDatabase();
                DBHandler.Instance.UpdateTable<Author>();
                DBHandler.Instance.UpdateTable<Tip>();
                DBHandler.Instance.Insert(new Author { Id = 1, Name = "Elon Musk" });
                DBHandler.Instance.Insert(new Author { Id = 2, Name = "Bill Gates" });
                DBHandler.Instance.Insert(new Author { Id = 3, Name = "Jeff Bezos" });
                DBHandler.Instance.Insert(new Author { Id = 4, Name = "Claudia López" });
                Preferences.Set(Constants.AppInitializated, true);
            }

            MainPage = new NavigationPage(new Tips());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
