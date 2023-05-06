using System.Collections.ObjectModel;
using SkiaSharp;
using MathNet.Numerics.Distributions;




namespace SimulacionFinal.Paginas;

public partial class PruebaPromedio : ContentPage
{
    
    public PruebaPromedio()
	{
		InitializeComponent();
	}
    public double[] Almacenar2;
   /* public void RecibirLista(double[] Almacenar,int txtNumGen)
    {
        Almacenar2 = Almacenar;
        this.txtNumGen = txtNumGen;
       
    }*/
    
    private void btnCalcular_Clicked(object sender, EventArgs e)
	{        
        Almacenar2 = Generador.Almacenar;
       // txtc.Text = $"{Almacenar2.Length}";        
        
        double alpha, alpha2, prom, Zo, area, suma = 0, res = 0;
        if (Almacenar2 != null)
        {            
            try
            {
                alpha = Convert.ToDouble(txtc.Text);
                if (alpha > 0 && alpha < 1)
                {
                    int Num = Generador.Num;         //Numeros a generar en generador
                    //Division de alpha/2
                    alpha2 = alpha / 2;
                    txtc2.Text = alpha2.ToString();
                    //Suma de los numeros pseudoaleatorios
                    for (int i = 0; i < Almacenar2.Length; i++)
                    {
                        suma = suma + Almacenar2[i];
                    }
                    //Divide la suma entre la cantidad de los valores                    
                    prom = suma / Convert.ToDouble(Num);
                    //DisplayAlert("", $"{suma} / {Generador.Num} = {prom}", "Ok");
                    txtPromedio.Text = Math.Round(prom, 2).ToString();
                    //Formula para Zo
                    Zo = (prom - 0.5) * (Math.Sqrt(Num)) / Math.Sqrt(0.8333333333);
                    txtzo.Text = Zo.ToString();
                    //Calculando area bajo la curva en la tabla de distribucion normal
                    area = 1 - alpha2;
                    txtArea.Text = area.ToString();
                    //Calcular el valor de las tablas
                     res = MathNet.Numerics.Distributions.Normal.InvCDF(0, 1, area);
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
                    DisplayAlert("Mensaje","El valor de alpha debe estar dentro del rango de 0 y 1","Ok");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Mensaje", "Ingrese un valor de Alpha","Ok");
            }
        }
        else
        {
            DisplayAlert("Mensaje", "Aun no se han generado los numeros pseudoaleatorios","Ok");
        }
    }

    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        txtArea.Text = " ";
        txtc.Text = " ";
        txtc2.Text = " ";
        txtPromedio.Text = " ";
        txtzc2.Text = " ";
        txtzo.Text = " ";
    }
}