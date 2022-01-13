using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using TippyTec.Handlers;
using TippyTec.Models;
using TippyTec.Views;

using Xamarin.Forms;

namespace TippyTec.ViewModels
{
    public class TipsViewModel : BaseViewModel
    {
        public ObservableCollection<Tip> Tips { get; set; }

        public TipsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            var dbTips = DBHandler.Instance.Select<Tip>();
            Tips = new ObservableCollection<Tip>() { };
            foreach(var dbTip in dbTips)
            {
                Tips.Add(dbTip);
            }
        }

        public ICommand MoveToNewTipCommand => new Command(MoveToNewTip);

        public ICommand ShowTipCommand => new Command<Tip>(async (tip) => await ShowTip(tip));

        public ICommand DeleteTipCommand => new Command<Tip>(async (tip) => await DeleteTip(tip));

        public void MoveToNewTip()
        {
            Navigation.PushAsync(new NewTip(), true);
        }

        public async Task ShowTip(Tip tip)
        {
            if (tip.Author != null)
            {
                await DisplayAlert(tip.Title, tip.Description + " by: " + tip.Author.Name, "Cerrar");
            }
            else
            {
                await DisplayAlert(tip.Title, tip.Description, "Cerrar");
            }
        }

        public async Task DeleteTip(Tip tip)
        {
            bool isForDelete = await DisplayAlert("Cuidado!", "Seguro que quieres borrar el tip: " + tip.Description, "Borrar", "Volver");
            if (isForDelete)
            {
                DBHandler.Instance.Delete(tip);
                Tips.Remove(tip);
            }
        }
    }
}
