using GreenThump.Database;
using GreenThump.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThump
{
    /// <summary>
    /// Interaction logic for AddPlant.xaml
    /// </summary>
    public partial class AddPlant : Window
    {
        public AddPlant()
        {
            InitializeComponent();

            using (GreenThumpDb context = new())
            {
                GreenThumpRepository<Instruction> greenThumpRepository = new(context);
                var items = greenThumpRepository.GetAll();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        ComboBoxItem comboBoxItem = new();
                        comboBoxItem.Tag = item;
                        comboBoxItem.Content = item.InstructionText;
                        cmbInstructions.Items.Add(comboBoxItem);
                    }
                }

            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumpDb context = new())
            {
                GreenThumpRepository<Instruction> AddInstruction = new(context);
                GreenThumpRepository<Plant> AddPlant = new(context);
                string name = txtName.Text;
                string Description = txtDescription.Text;
                List<Instruction> instructions = new();
                foreach (var inst in lstinstruction.Items)
                {
                    ListViewItem listItem = (ListViewItem)inst;
                    Instruction instInstruction = (Instruction)listItem.Tag;
                    AddPlant.GetByID(instInstruction.Id);
                    instructions.Add(instInstruction);
                }
                Plant plant = new();
                plant.Name = name;
                plant.Description = Description;
                plant.Instructions = instructions;


                AddPlant.Add(plant);
                AddPlant.Complete();
            }
            //string name = txtName.Text;
            ////string Instruction = txtInstructions.Text;
            //string Description = txtDescription.Text;

            //if (name != "" && Instruction != "" && Description != "")
            //{

            //}
            //else
            //{
            //    MessageBox.Show("You have to write in");
            //}
        }

        private void cmbInstructions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnAddIntsruction_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedinstruction = (ComboBoxItem)cmbInstructions.SelectedItem;
            if (selectedinstruction != null)
            {
                Instruction instructions = (Instruction)selectedinstruction.Tag;
                ListViewItem item = new();
                item.Tag = instructions;
                item.Content = instructions.InstructionText;
                lstinstruction.Items.Add(item);
                cmbInstructions.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Select instruction Albin !", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
