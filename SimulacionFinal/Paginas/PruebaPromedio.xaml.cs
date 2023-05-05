using System.Collections.ObjectModel;

namespace SimulacionFinal.Paginas;

public partial class PruebaPromedio : ContentPage
{
	public PruebaPromedio()
	{
		InitializeComponent();
	}

    public void RecibirLista(ObservableCollection<GeneradorPseudo> lista, double[] Almacenar)
    {
        foreach (GeneradorPseudo numeroGenerado in lista)
        {
            // Hacer algo con el número generado
            double numero = numeroGenerado.numero;
            // ...
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
	{
        double alpha, alpha2, prom, Zo, area, suma = 0, res = 0;
        if (Almacenar != null)
        {
            try
            {
                alpha = Convert.ToDouble(txtc.Text);
                if (alpha > 0 && alpha < 1)
                {
                    int Num = int.Parse(txtNumGen.Text);
                    //Division de alpha/2
                    alpha2 = alpha / 2;
                    txtc2.Text = alpha2.ToString();
                    //Suma de los numeros pseudoaleatorios
                    for (int i = 0; i < Almacenar.Length; i++)
                    {
                        suma = suma + Almacenar[i];
                    }
                    //Divide la suma entre la cantidad de los valores
                    prom = suma / Num;
                    txtPromedio.Text = Math.Round(prom, 2).ToString();
                    //Formula para Zo
                    Zo = (prom - 0.5) * (Math.Sqrt(Num)) / Math.Sqrt(0.8333333333);
                    txtzo.Text = Zo.ToString();
                    //Calculando area bajo la curva en la tabla de distribucion normal
                    area = 1 - alpha2;
                    txtArea.Text = area.ToString();
                    //Calcular el valor de las tablas
                    var chart1 = new Chart();
                    res = chart1.DataManipulator.Statistics.InverseNormalDistribution(area);
                    txtzc2.Text = Math.Round(res, 2).ToString();

                    //despliegue de resultados
                    if (double.Parse(txtzo.Text) <= double.Parse(txtc2.Text))
                    {
                        DisplayAlert("Mensaje","Los números SI estan distribuidos uniformemente","Ok");
                    }
                    else
                    {
                        DisplayAlert("Mensaje", "Los numeros NO estan distribuidos uniformemente", "Ok");                        
                    }
                }

                else
                {
                    DisplayAlert("El valor de alpha debe estar dentro del rango de 0 y 1");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Ingrese un valor de Alpha");
            }
        }
        else
        {
            DisplayAlert("Aun no se han generado los numeros pseudoaleatorios");
        }
    }
}