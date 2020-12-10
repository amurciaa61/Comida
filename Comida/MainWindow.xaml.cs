using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Comida
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Plato> platos = new ObservableCollection<Plato>();
        public MainWindow()
        {
            InitializeComponent();
            string ruta = @"E:\DAM2A\Desarrollo Interfaces\Proyectos\Comida\Comida\Imagenes";
            List<Plato> pl = Plato.GetSamples(ruta);
            foreach (Plato valor in pl)
            {
                platos.Add(valor);
            }
            ObservableCollection<string> tipoComida = new ObservableCollection<string> { "China", "Americana", "Mexicana" };
            paisesComboBox.DataContext = tipoComida;
            listaListBox.DataContext = platos;
        }

        private void listaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indice = (sender as ListBox).SelectedIndex;
            contenedor.DataContext = platos[indice];
            paisesComboBox.SelectedItem = platos[indice].Tipo;
        }
    }
}
