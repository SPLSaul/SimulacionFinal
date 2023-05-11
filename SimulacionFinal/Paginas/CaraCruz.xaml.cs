namespace SimulacionFinal.Paginas;

public partial class CaraCruz : ContentPage
{
    public double[] Almacenar;
    public static double Monto, Apuesta, pierde = 0, gana = 0;
   

    public CaraCruz()
	{
		InitializeComponent();
	}
    private void btnLimpiar_Clicked(object sender, EventArgs e)
	{
        txtCara.Text = string.Empty;
        txtCruz.Text = string.Empty;
    }

    private void btnJugar_Clicked(object sender, EventArgs e)
    {
        int cara = 0, cruz = 0;
        Almacenar = Generador.Almacenar;
        int n = Generador.Num;
        if (Almacenar != null)
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    if (Almacenar[i] > 0.6)
                    {
                        cara++;
                    }
                    else
                    {
                        cruz++;
                    }
                }
                txtCruz .Text = $"{cara}";
                txtCara .Text = $"{cruz}";

            }
            catch (Exception)
            {
                DisplayAlert("ALERTA", "Error durante el calculo", "Ok");
            }
            //llenado de tabla
        }
        else
        {
            DisplayAlert("Mensaje", "Aun no se han generado los numeros pseudoaleatorios", "Ok");
        }
    }
}
 