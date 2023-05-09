using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace SimulacionFinal.Paginas;

public partial class Generador : ContentPage
{
    public static double[] Almacenar ;
    public static int Num;
    //List<GeneradorPseudo> generados = new List<GeneradorPseudo>();
    ViewModel viewModel = new ViewModel();


    public Generador()
	{
		InitializeComponent();
	}

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        txtA.Text = "";
        txtc.Text = "";
        txtm.Text = "";
        txtNumerosGenerar.Text = "";
        viewModel._generados = new ObservableCollection<GeneradorPseudo>();

        // Asignar la nueva instancia vacía al ItemsSource del CollectionView
        miCollectionView.ItemsSource = viewModel._generados;
    }
    private void btnGenerar_Clicked(object sender, EventArgs e)
    {
        try
        {
            double A = Convert.ToDouble(txtA.Text);
            double C = Convert.ToDouble(txtc.Text);
            double M = Convert.ToDouble(txtm.Text);
            Num = int.Parse(txtNumerosGenerar.Text);
            Almacenar = new double[Num];
            //Confirma que los valores sean mayores a 0
            if (Convert.ToDouble(txtA.Text) > 0 && Convert.ToDouble(txtc.Text) > 0 && Convert.ToDouble(txtm.Text) > 0)
            {
                if ( Convert.ToDouble(txtm.Text) > Convert.ToDouble(txtA.Text) && Convert.ToDouble(txtm.Text) > Convert.ToDouble(txtc.Text))
                {
                    long semilla = (uint)DateTime.Now.Ticks;


                    //Generador de numeros pseudoaleatorios
                    for (int i = 0; i < Num; i++)
                    {
                        semilla = Convert.ToInt64((A * semilla + C) % M);
                        double aleatorio = (double)semilla / M;
                       

                        Almacenar[i] = aleatorio;

                        // Agregar un nuevo elemento GeneradorPseudo a la lista en cada iteración del ciclo
                        viewModel._generados.Add(new GeneradorPseudo { Iteracion = i, numero = aleatorio });
                    }
                    miCollectionView.BindingContext = viewModel;
                }
                else
                {
                    DisplayAlert("Error", "No se cumplen los parametros de M > A, M > C y M > Xo", "Ok");
                }
            }
            else
            {
                DisplayAlert("Error", "No se cumplen los parametros de A > 0, C > 0 y Xn > 0", "Ok");
            }
            // PruebaPromedio pruebaPromedio = new PruebaPromedio();
            //pruebaPromedio.RecibirLista(Almacenar, Num);
            // DisplayAlert("Notificacion", $"Instancia de promedio valores {Almacenar.Length}", "Ok");
        }
        catch (FormatException)
        {
            DisplayAlert("Error", "No se ingreso algun dato correcto, recuerde que tiene que tener valores numericos", "Error");
        }


    }
}