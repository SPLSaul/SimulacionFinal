using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionFinal
{
    public class ViewModel
    {
        public ObservableCollection<GeneradorPseudo> _generados { get; set; }
        public ViewModel()
        {
            _generados = new ObservableCollection<GeneradorPseudo>
            {

            };            
        }
    }
}
