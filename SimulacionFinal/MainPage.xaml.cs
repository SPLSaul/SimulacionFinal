using SimulacionFinal.Paginas;

namespace SimulacionFinal;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    private void btnGenerador_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Generador());
	}
    private void btnCara_Clicked(object sender, EventArgs e)
    {

    }
    private void btnPI_Clicked(object sender, EventArgs e)
    {

    }
    private void btnInfo_Clicked(object sender, EventArgs e)
    {

    }
    private void btnExit_Clicked(object sender, EventArgs e)
    {

    }

}

