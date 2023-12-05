using GreenThump.Models;
using System.Windows;

namespace GreenThump
{
    /// <summary>
    /// Interaction logic for PlantDetalis.xaml
    /// </summary>
    public partial class PlantDetalis : Window
    {
        public PlantDetalis(Plant plant)
        {
            InitializeComponent();

            txtPlantName.Text = plant.Name;
            txtPlantInstruction.Text = // hut göt jag för att se plantens instruction.
            txtPlantDescription.Text = plant.Description;
        }

        private void btnGoBackAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlant addPlant = new AddPlant();
            addPlant.Show();
            Close();
        }

        private void btnGobacktoMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
