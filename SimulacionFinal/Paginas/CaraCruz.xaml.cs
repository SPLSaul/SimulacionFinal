namespace SimulacionFinal.Paginas;

public partial class CaraCruz : ContentPage
{
    public double[] Almacenar;
    public static double Monto, Apuesta, pierde = 0, gana = 0;
    public static int juegos;

    public CaraCruz()
	{
		InitializeComponent();
	}
    private void btnLimpiar_Clicked(object sender, EventArgs e)
	{
		txtApuesta.Text = string.Empty;
        txtJuegos.Text = string.Empty;
        txtMano.Text = string.Empty;
    }

    private void btnJugar_Clicked(object sender, EventArgs e)
    {
        if (Almacenar != null)
        {
            try
            {
                //variables 
                Monto = double.Parse(txtMano.Text);
                Apuesta = double.Parse(txtApuesta.Text);
                juegos = int.Parse(txtJuegos.Text);

                bool bandera = false;
                double MontoSave, ApuestaSave;
                MontoSave = Monto;
                ApuestaSave = Apuesta;

                dataGridJuego.Refresh();
                for (int i = 0; i < juegos; i++)
                {

                    int n = dataGridJuego.Rows.Add();

                    dataGridJuego.Rows[n].Cells[0].Value = (i + 1);
                    dataGridJuego.Rows[n].Cells[1].Value = Almacenar[i];

                    //activa la bandera para reiniciar la apuesta
                    if (bandera == true)
                    {
                        Apuesta = ApuestaSave;
                    }

                    //cuando pierde
                    if (Almacenar[i] < 0.5)
                    {
                        dataGridJuego.Rows[n].Cells[2].Value = "DERROTA";

                        if (Monto < MontoSave)
                        {
                            //Se le resta al monto la apuesta
                            Monto = Monto - Apuesta;

                            //Como se perdio la Apuesta sube el doble
                            Apuesta = Apuesta + Apuesta;

                            //Aumenta en 1 el contador de derrotas
                            pierde = pierde + 1;

                            dataGridJuego.Rows[n].Cells[3].Value = Monto;
                            dataGridJuego.Rows[n].Cells[4].Value = Apuesta;
                        }
                        else
                        {
                            //Se le resta al monto la apuesta
                            Monto = Monto - Apuesta;

                            //Aumenta en 1 el contador de derrotas
                            pierde = pierde + 1;

                            dataGridJuego.Rows[n].Cells[3].Value = Monto;
                            dataGridJuego.Rows[n].Cells[4].Value = Apuesta;
                            if (Monto <= 0)
                            {
                                DisplayAlert("Mensaje","PESIMO!!","Ok");
                            }
                        }
                    }
                    //cuando gana
                    else if (Almacenar[i] > 0.5 && Almacenar[i] < 1)
                    {
                        dataGridJuego.Rows[n].Cells[2].Value = "VICTORIA";

                        //Se le suma al monto la apuesta
                        Monto = Monto + Apuesta;

                        if (Monto >= MontoSave)
                        {
                            bandera = true;
                        }
                        //Se le suma en 1 al contador de victorias
                        gana = gana + 1;

                        dataGridJuego.Rows[n].Cells[3].Value = Monto;
                        dataGridJuego.Rows[n].Cells[4].Value = Apuesta;
                    }
                }
                //desplegar resultados
                txtGanadas.Text = gana.ToString();
                txtPerdidas.Text = pierde.ToString();
                if (Monto > MontoSave)
                {
                    DisplayAlert("","!!","Ok");
                }
                else if (Monto == MontoSave)
                {
                    DisplayAlert("", "Intenta de nuevo", "Ok");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Mensaje", "Ingrese un numerico", "Ok");
            }
            //llenado de tabla
        }
        else
        {
            DisplayAlert("Mensaje", "Aun no se han generado los numeros pseudoaleatorios", "Ok");
        }
    }
}
 