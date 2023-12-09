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

			// hämtar instruktion till listan 
			using (GreenThumbDb context = new())
			{
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
		}

		private void btnGoBack_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Close();
		}

		//private bool IsPlantNameAvaliabel(string name)
		//{
		//	using (GreenThumbDb context = new())
		//	{
		//		GreenThumbRepository<Plant> PlantRepo = new GreenThumbRepository<Plant>(context);
		//		return PlantRepo.GetAll().Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		//	}
		//}
		//private void ValidatePlantName(string name)
		//{
		//	if (IsPlantNameAvaliabel(name))
		//	{
		//		MessageBox.Show("Name is already exist. choose another one!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
		//		return;
		//	}
		//}
		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			// vi spara växtens detaljer i database
			using (GreenThumbDb context = new())
			{
				// skapar en repo för instruktioner och växter
				GreenThumbRepository<Instruction> AddInstruction = new(context);
				GreenThumbRepository<Plant> AddPlant = new(context);
				// hämtar användarens inmatning
				string name = txtName.Text;
				//string plantname = txtName.Text.ToLower();	
				string Description = txtDescription.Text;
				//ValidatePlantName(name);

				List<Instruction> instructions = new();
				// kollar om alla unputs rutor är ifyllda
				if (string.IsNullOrWhiteSpace(name))
				{
					MessageBox.Show("Please enter a name.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
					return;
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
				// kollar genom tillagda instruktioner
				foreach (var inst in lstinstruction.Items)
				{
					ListViewItem listItem = (ListViewItem)inst;
					Instruction instInstruction = (Instruction)listItem.Tag;
					AddPlant.GetByID(instInstruction.Id);
					instructions.Add(instInstruction);
				}
				// skapar en ny plant med det info vi har fått in 
				Plant plant = new();
				plant.Name = name;
				plant.Description = Description;
				plant.Instructions = instructions;

				// lägger till det i database
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
			// lägger till en ny instruktion i listan 
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
