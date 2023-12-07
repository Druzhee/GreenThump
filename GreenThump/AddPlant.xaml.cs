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


			using (GreenThumbDb context = new())
			{
				//GreenThumpRepository<Instruction> greenThumpRepository = new(context);
				//var items = greenThumpRepository.GetAll();
				var items = new List<Instruction>();
				if (items != null)
				{
					foreach (var item in items)
					{
						ListViewItem listViewItem = new();
						listViewItem.Tag = item;
						listViewItem.Content = item.InstructionText;
						lstinstruction.Items.Add(listViewItem);
					}
				}
			}


			//using (GreenThumpDb context = new())
			//{
			//    GreenThumpRepository<Instruction> greenThumpRepository = new(context);
			//    var items = greenThumpRepository.GetAll();
			//    if (items != null)
			//    {
			//        foreach (var item in items)
			//        {
			//            ComboBoxItem comboBoxItem = new();
			//            comboBoxItem.Tag = item;
			//            comboBoxItem.Content = item.InstructionText;
			//            cmbInstructions.Items.Add(comboBoxItem);
			//        }
			//    }

			//}
		}

		private void btnGoBack_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Close();
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			using (GreenThumbDb context = new())
			{
				GreenThumbRepository<Instruction> AddInstruction = new(context);
				GreenThumbRepository<Plant> AddPlant = new(context);
				string name = txtName.Text;
				string Description = txtDescription.Text;
				List<Instruction> instructions = new();
				if (string.IsNullOrWhiteSpace(name))
				{
					MessageBox.Show("Please enter a name.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
					return; // Exit the method to prevent further execution
				}
				else if (string.IsNullOrWhiteSpace(Description))
				{
					MessageBox.Show("Please enter a description", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
					return;
				}
				else if (lstinstruction.Items.Count == 0)
				{
					MessageBox.Show("Please enter at least one intsruction", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
					return;
				}
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
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				Close();
			}
		}

		private void cmbInstructions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

		}

		private void btnAddIntsruction_Click(object sender, RoutedEventArgs e)
		{
			string Addinstruction = txtinstruction.Text;

			if (!string.IsNullOrEmpty(Addinstruction))
			{
				Instruction instruction = new Instruction { InstructionText = Addinstruction };

				ListViewItem item = new ListViewItem
				{
					Tag = instruction,
					Content = Addinstruction
				};
				lstinstruction.Items.Add(item);
				txtinstruction.Clear();
				MessageBox.Show("Instruction added!", "Successfully", MessageBoxButton.OK, MessageBoxImage.None);
			}
			else
			{
				MessageBox.Show("Enter instruction text!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

			}
		}
	}
}
