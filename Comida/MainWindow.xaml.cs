using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            paisesComboBox.ItemsSource = tipoComida;
            listaListBox.DataContext = platos;
        }

        private void listaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contenedor.DataContext = (sender as ListBox).SelectedItem;
        }
    }
}
