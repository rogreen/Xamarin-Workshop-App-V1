using HoneyDo.Models;
using HoneyDo.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoneyDo.ViewModels
{
    public class HoneyDoItemsViewModel : BaseViewModel
    {
        private HoneyDoItem selectedItem;

        public ObservableCollection<HoneyDoItem> HoneyDoItems { get; set; }

        public Command LoadItemsCommand { get; set; }
        public Command<HoneyDoItem> ItemTapped { get; }
        public HoneyDoItemsViewModel()
        {
            HoneyDoItems = new ObservableCollection<HoneyDoItem>();

            DataStore.Initialize();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<HoneyDoItem>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                HoneyDoItems.Clear();
                var honeyDoItems = await DataStore.GetItemsAsync();
                foreach (var item in honeyDoItems)
                {
                    HoneyDoItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void OnItemSelected(HoneyDoItem item)
        {
            if (item == null)
                return;

            App.SelectedItemViewModel = new HoneyDoItemViewModel();
            App.SelectedItemViewModel.HoneyDoItem = item;
            // This will push the HoneyDoItemPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(HoneyDoItemPage)}");
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
