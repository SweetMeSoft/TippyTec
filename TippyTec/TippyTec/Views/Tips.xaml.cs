using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TippyTec.ViewModels;

using Xamarin.Forms;

namespace TippyTec
{
    public partial class Tips : ContentPage
    {
        public Tips()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new TipsViewModel(Navigation);
        }
    }
}
