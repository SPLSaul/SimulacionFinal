namespace SimulacionFinal.Paginas;

public partial class PiPage : ContentPage
{
    public double[] Almacenar;
    public static double N, x = 0, PiCal, evaluar;
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

    private void btnCalcular_Clicked(object sender, EventArgs e)
	{
        Almacenar = Generador.Almacenar;
        if (Almacenar != null)
        {
            try
            {
                //Asignacion de variables
                N = Generador.Num;

                for (int i = 0; i < N; i++)
                {
                    //Agregamos valores a las columnas del dataGridJuego
                    int n = dataGridJuego.Rows.Add();

                    dataGridJuego.Rows[n].Cells[0].Value = (i + 1);
                    dataGridJuego.Rows[n].Cells[1].Value = Almacenar[i];
                    dataGridJuego.Rows[n].Cells[2].Value = Almacenar[i + 2];

                    //calculamos R1 Y R2
                    evaluar = Math.Sqrt(Math.Pow(Almacenar[i], 2) + Math.Pow(Almacenar[i + 1], 2));
                    dataGridJuego.Rows[n].Cells[3].Value = evaluar;

                    //Se decide si esta o no en el Sector
                    if (evaluar < 1)
                    {
                        //sumar 1 en x por cada si
                        dataGridJuego.Rows[n].Cells[4].Value = "Si";
                        x = x + 1;
                    }
                    else
                    {
                        dataGridJuego.Rows[n].Cells[4].Value = "No";

                    }
                }

                txtCuarto.Text = x.ToString();

                //calcular pi
                PiCal = 4 * (x / N);
                txtEstimacion.Text = PiCal.ToString();

            }
            catch (FormatException)
            {
                DisplayAlert("ALERTA","Solo valores Numericos por favor","OK");
            }

        }
        else
        {
            DisplayAlert("ALERTA","Por favor genere primero los numeros pseudoaleatorios","Ok");
        }
    }
}