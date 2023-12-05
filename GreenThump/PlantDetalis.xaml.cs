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

            //var instructions = plant.Instructions.ToList();
            //foreach (var instr in instructions)
            //{
            //    ListViewItem item = new();
            //    item.Tag = instr;
            //    item.Content = instr.InstructionText;
            //    if (instr.InstructionText != null)
            //    {
            //        lstInstruction.Items.Add(item);
            //    }
            //}
            //txtPlantName.Text = plant.Name;
            //txtPlantInstruction.Text = plant.Instructions;

            txtPlantDescription.Text = plant.Description;
        }

        private void btnGoBackAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlant addPlant = new AddPlant();
            addPlant.Show();
            Close();
        }


    }
}
