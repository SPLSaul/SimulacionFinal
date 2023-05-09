using MathNet.Numerics;
using System.Diagnostics;

namespace SimulacionFinal.Paginas;

public partial class PiPage : ContentPage
{
    public double[] Almacenar;
    public static double N, x = 0, PiCal, evaluar;
    //ViewModel viewModel = new ViewModel();
    ViewModel generados = new ViewModel();

    public PiPage()
	{
		InitializeComponent();
	}

    private void btnEliminar_Clicked(object sender, EventArgs e)
	{
		
        txtEstimacion.Text = string.Empty;

    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        int dentro_del_circulo = 0;

        Almacenar = Generador.Almacenar;

        if (Almacenar != null)
        {
            await DisplayAlert("Mensaje", $"Cantidad de numeros {Almacenar.Length} dentro del if", "OK");
            try
            {
                //Asignacion de variables
                N = Generador.Num;

                for (int i = 0; i < N - 1; i++)
                {
                    double x = Almacenar[i];
                    double y = Almacenar[i + 1];
                    if (x * x + y * y <= 1)
                    {
                        dentro_del_circulo++;
                    }
                }

                double pi_aproximado = 4.0 * dentro_del_circulo / N;
                txtEstimacion.Text = pi_aproximado.ToString();

               
            }
            catch (FormatException)
            {
                await DisplayAlert("ALERTA", "Solo valores Numericos por favor", "OK");
            }

        }
        else
        {
            await DisplayAlert("ALERTA", "Por favor genere primero los numeros pseudoaleatorios", "Ok");
        }
    }

}