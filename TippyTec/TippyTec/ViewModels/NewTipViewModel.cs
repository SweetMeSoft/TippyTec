using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using TippyTec.Handlers;
using TippyTec.Models;

using Xamarin.Forms;

namespace TippyTec.ViewModels
{
    public class NewTipViewModel : BaseViewModel
    {
        public Tip NewTip { get; set; }

        public List<Author> Authors { get; set; }

        public NewTipViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NewTip = new Tip();
            NewTip.CreatedDate = DateTime.Now;
            Authors = DBHandler.Instance.Select<Author>();
        }

        public ICommand SaveTipCommand => new Command(SaveTip);

        public void SaveTip()
        {
            if (NewTip.Title == "" || NewTip.Description == "" || NewTip.Author == null)
            {
                DisplayAlert("Error", "Faltan datos por completar", "Volver");
            }
            else
            {
                NewTip.AuthorId = NewTip.Author.Id;
                NewTip.UpdatedDate = DateTime.Now;
                DBHandler.Instance.Insert(NewTip);
                Navigation.PopAsync();
            }
        }
    }
}
