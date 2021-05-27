using HoneyDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoneyDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoneyDoItemsPage : ContentPage
    {
        HoneyDoItemsViewModel viewModel;

        public HoneyDoItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HoneyDoItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}