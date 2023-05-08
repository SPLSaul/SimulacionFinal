using SimulacionFinal.Paginas;

namespace SimulacionFinal;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    /*private  void btnGenerador_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Generador());

    }*/

    private async void btnGenerador_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Paginas.Generador");
    }

    private async void btnCara_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Paginas.Generador.Flyout1");
    }
    private async void btnPI_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Paginas.Generador.Flyout2");
    }
    private async void btnInfo_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Paginas.Generador");
    }





    /*private void btnCara_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Generador());
    }
    private void btnPI_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Generador());
    }
    private void btnInfo_Clicked(object sender, EventArgs e)
    {

    }*/
    private void btnExit_Clicked(object sender, EventArgs e)
    {

    }

}

