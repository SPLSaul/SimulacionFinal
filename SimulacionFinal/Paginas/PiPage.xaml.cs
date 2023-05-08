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
		txtCorridas.Text = string.Empty;
        txtCuarto.Text = string.Empty;
        txtEstimacion.Text = string.Empty;

    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Mensaje", "Click en calcular", "OK");
        Almacenar = Generador.Almacenar;

        if (Almacenar != null)
        {
            await DisplayAlert("Mensaje", $"Cantidad de numeros {Almacenar.Length} dentro del if", "OK");
            try
            {
                //Asignacion de variables
                N = Generador.Num;

                for (int i = 0; i < N; i++)
                {
                    Generado nuevoGenerado = new Generado();
                    nuevoGenerado.Id = i + 1;
                    nuevoGenerado.Valor1 = Almacenar[i];
                    nuevoGenerado.Valor2 = Almacenar[i + 2];
                    nuevoGenerado.R = Math.Sqrt(Math.Pow(Almacenar[i], 2) + Math.Pow(Almacenar[i + 1], 2));
                    nuevoGenerado.EstaEnSector = (nuevoGenerado.R < 1) ? "Si" : "No";
                    await DisplayAlert("", $"Antes de agregar a generados {nuevoGenerado.Valor1}", "OK");

                    generados.generados.Add(nuevoGenerado);
                }

                txtCuarto.Text = x.ToString();

                //calcular pi
                PiCal = 4 * (x / N);
                txtEstimacion.Text = PiCal.ToString();

                miCollectionView.BindingContext = generados;
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