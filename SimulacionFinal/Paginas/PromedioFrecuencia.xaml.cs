namespace SimulacionFinal.Paginas;

public partial class PromedioFrecuencia : ContentPage
{
    public double[] Almacenar;
    public PromedioFrecuencia()
	{
		InitializeComponent();
        BindingContext = this;
        List<Alfa> alfas = new List<Alfa>()
        {
            new Alfa(){ valorAlfa = 0.995},
            new Alfa(){ valorAlfa = 0.990},
            new Alfa(){ valorAlfa = 0.975},
            new Alfa(){ valorAlfa = 0.950},
            new Alfa(){ valorAlfa = 0.500},
            new Alfa(){ valorAlfa = 0.050},
            new Alfa(){ valorAlfa = 0.250},
            new Alfa(){ valorAlfa = 0.010},
            new Alfa(){ valorAlfa = 0.005},
        };
        PickerAlfa.ItemsSource = alfas;

    }
    public static double cmbAlpha;

    private void OnPickerAlfaSelectedIndexChanged(object sender, EventArgs e)
    {
        Alfa alfaSeleccionado = (Alfa)PickerAlfa.SelectedItem;
        cmbAlpha = alfaSeleccionado.valorAlfa;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
	{
        Almacenar = Generador.Almacenar;
        if (Almacenar != null)
        {
            try
            {
                //Se divide la cantidad de numeros generados entre nuestra cantidad de grupos
                double Fe = Generador.Num / 4;
                //Chi cuadrada calculada
                double chi1 = 0, chi2 = 0, chi3 = 0, chi4 = 0, ChiCuadrada = 0;
                //variables para contar en el grupo que cae cada numero pseudoaleatorio
                int c1 = 0, c2 = 0, c3 = 0, c4 = 0;
                //chi de tablas segun el alpha que se eligio
                double ChiTablas = 0;

                int i = 0;
                txtFe1.Text = Fe.ToString();
                txtFe2.Text = Fe.ToString();
                txtFe3.Text = Fe.ToString();
                txtFe4.Text = Fe.ToString();

                //Se crea un ciclo hasta que la longitud del arreglo donde se estan almacenando los numeros
                //Como so 4 intervalos se divide 1/4 = 0.25 y se va acumulando para cada uno de los grupos
                while (i < Almacenar.Length)
                {
                    //Grupo1
                    if (Almacenar[i] >= 0 && Almacenar[i] < 0.25)
                        c1++;
                    //Grupo2
                    if (Almacenar[i] >= 0.25 && Almacenar[i] < 0.50)
                        c2++;
                    //Grupo3
                    if (Almacenar[i] >= 0.50 && Almacenar[i] < 0.75)
                        c3++;
                    //Grupo4
                    if (Almacenar[i] >= 0.75 && Almacenar[i] < 1)
                        c4++;

                    i++;
                }
                //La frecuencia observada se imprime en la pantalla 
                txtFo1.Text = c1.ToString();
                txtFo2.Text = c2.ToString();
                txtFo3.Text = c3.ToString();
                txtFo4.Text = c4.ToString();
                //Determinar la Chi cuadrada calculada
                chi1 = Math.Pow((c1 - Fe), 2) / Fe;
                chi2 = Math.Pow((c2 - Fe), 2) / Fe;
                chi3 = Math.Pow((c3 - Fe), 2) / Fe;
                chi4 = Math.Pow((c4 - Fe), 2) / Fe;
                //Imprime el valor de chi cuadrada calculada
                txtChi1.Text = chi1.ToString();
                txtChi2.Text = chi2.ToString();
                txtChi3.Text = chi3.ToString();
                txtChi4.Text = chi4.ToString();
                //Acumular los valores de chi obtenidos para buscar el valor de tablas con el alfa seleccionado
                ChiCuadrada = chi1 + chi2 + chi3 + chi4;
                //Imprime chi acumulada
                txtChiCuadrada.Text = ChiCuadrada.ToString();
                //Dependiendo del valor de alfa seleccionado depende del valor de tablas para chi
                if (cmbAlpha == 0.995)
                {
                    ChiTablas = 0.07;
                }
                else if (cmbAlpha == 0.990)
                {
                    ChiTablas = 0.11;
                }
                else if (cmbAlpha == 0.975)
                {
                    ChiTablas = 0.21;
                }
                else if (cmbAlpha == 0.950)
                {
                    ChiTablas = 0.35;
                }
                else if (cmbAlpha == 0.500)
                {
                    ChiTablas = 2.36;
                }
                else if (cmbAlpha == 0.050)
                {
                    ChiTablas = 7.81;
                }
                else if (cmbAlpha == 0.250)
                {
                    ChiTablas = 9.34;
                }
                else if (cmbAlpha == 0.010)
                {
                    ChiTablas = 11.34;
                }
                else if (cmbAlpha == 0.005)
                {
                    ChiTablas = 12.83;
                }
                //Imprime Chi de Tablas
                txtChiTablas.Text = ChiTablas.ToString();

                //despliegue de resultados
                if (double.Parse(txtChiCuadrada.Text) <= double.Parse(txtChiTablas.Text))
                {
                    DisplayAlert("Mensaje", "Los números SI estan distribuidos uniformemente", "Ok");
                }
                else
                {
                    DisplayAlert("Mensaje", "Los números NO estan distribuidos uniformemente", "Ok");
                }
            }

            catch
            {
                DisplayAlert("Mensaje", "Ingrese valores numericos", "Ok");
            }
        }
        else
        {
            DisplayAlert("Mensaje", "Aun no se han generado los numeros pseudoaleatorios", "Ok");
        }
    }

    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        txtChi1.Text = string.Empty;
        txtChi2.Text = string.Empty;
        txtChi3.Text = string.Empty;
        txtChi4.Text = string.Empty;
        txtChiCuadrada.Text = string.Empty;
        txtChiTablas.Text = string.Empty;
        txtFe1.Text = string.Empty;
        txtFe2.Text = string.Empty;
        txtFe3.Text = string.Empty;
        txtFe4.Text = string.Empty;
        txtFo1.Text = string.Empty;
        txtFo2.Text = string.Empty;
        txtFo3.Text = string.Empty;
        txtFo4.Text = string.Empty;
    }
}