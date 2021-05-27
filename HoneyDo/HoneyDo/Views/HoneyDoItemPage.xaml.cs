using HoneyDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoneyDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoneyDoItemPage : ContentPage
    {
        HoneyDoItemViewModel viewModel;

        public HoneyDoItemPage()
        {
            InitializeComponent();

            BindingContext = viewModel = App.SelectedItemViewModel;
        }

    }
}