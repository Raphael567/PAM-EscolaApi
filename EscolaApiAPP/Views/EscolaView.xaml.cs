using EscolaApiAPP.ViewModels;

namespace EscolaApiAPP.Views;

public partial class EscolaView : ContentPage
{
	private EscolaViewModel escolaViewModel;
	public EscolaView()
	{
		InitializeComponent();

		escolaViewModel = new EscolaViewModel();
		BindingContext = escolaViewModel;
		Title = "Escola CRUD";
	}
}