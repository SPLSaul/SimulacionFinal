using System.ComponentModel;

namespace SimulacionFinal.Paginas;

public partial class Info : ContentPage
{
	public Info()
	{
		InitializeComponent();

		Descripcion.Text = "Instituto Tecnologico de Tijuana\nMateria: Simulacion\nProfesor: Juan Jose Rogelio Orozco Garibay\n" +
			"Alumno: Saul Perez Lopez 21212020\nProyecto Individual\n\n   Aplicacion para la generacion y prueba de experimentos con numeros" +
			"pseudoaleatorios. Para mas informacion visite la documentacion oficial";
	}
}