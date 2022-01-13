using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TippyTec.Handlers;

using Xamarin.Forms;

namespace TippyTec.ViewModels
{
    public class BaseViewModel
    {
        public INavigation Navigation;

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
