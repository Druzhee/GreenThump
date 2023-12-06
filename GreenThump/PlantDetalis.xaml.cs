using GreenThump.Database;
using GreenThump.Models;
using System.Windows;
using System.Windows.Controls;

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



            using (GreenThumbDb context = new())
            {

                GreenThumbRepository<Instruction> repository = new(context);
                foreach (Instruction instruction in plant.Instructions)
                {
                    ItemsControl itemsControl = itemitemcontrol;
                    itemsControl.Tag = instruction;
                    itemsControl.Items.Add(instruction.InstructionText);
                }
            }


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
