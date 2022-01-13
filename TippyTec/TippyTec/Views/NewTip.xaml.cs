using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TippyTec.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TippyTec.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTip : ContentPage
    {
        public NewTip()
        {
            InitializeComponent();
            BindingContext = new NewTipViewModel(Navigation);
        }
    }
}