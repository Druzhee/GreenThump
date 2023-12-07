using GreenThump.Database;
using GreenThump.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThump
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private List<Plant>? AllPlants;
		public MainWindow()
		{
			InitializeComponent();
			using (GreenThumbDb context = new())
			{
				GreenThumbRepository<Plant> greenThumpRepository = new(context);
				GreenThumbRepository<Instruction> instructionRepository = new(context);

				var plant = greenThumpRepository.GetAll();
				var instructions = instructionRepository.GetAll();

				foreach (var plants in plant)
				{
					ListViewItem listViewItem = new();
					listViewItem.Tag = plants;
					listViewItem.Content = plants.Name;
					lstPlants.Items.Add(listViewItem);
				}
			}
		}

		private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			string searchTerm = txtSearch.Text.ToLower(); // Användarens inmatning

			using (GreenThumbDb context = new())
			{
				GreenThumbRepository<Plant> plants = new(context);

				var allPlants = plants.GetAll();

				lstPlants.Items.Clear();
				var filterPlants = allPlants.Where(p => p.Name.ToLower().Contains(searchTerm));
				foreach (var plant in filterPlants)
				{
					ListViewItem item = new();
					item.Tag = plant;
					item.Content = plant.Name;

					lstPlants.Items.Add(item);
				}
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			AddPlant addPlant = new();
			addPlant.Show();
			Close();
		}

		private void btnDetalis_Click(object sender, RoutedEventArgs e)
		{
			ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
			if (selectedItem != null)
			{
				Plant selectedPlant = (Plant)selectedItem.Tag;

				// Öppna detalis widow
				PlantDetalis plantDetalis = new PlantDetalis(selectedPlant);
				plantDetalis.Show();
				Close();
			}
			else
			{
				MessageBox.Show("Select a plant to see detalis", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
			}


		}

		private void btnRemove_Click(object sender, RoutedEventArgs e)
		{
			if (lstPlants.SelectedItem != null)
			{
				ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
				Plant selectedPlant = (Plant)selectedItem.Tag;

				for (int i = 0; i < lstPlants.Items.Count; i++)
				{
					if (lstPlants.Items[i] == selectedItem)
					{
						using (GreenThumbDb context = new GreenThumbDb())
						{
							GreenThumbRepository<Plant> greenThumpRepository = new GreenThumbRepository<Plant>(context);
							var plantToDelete = greenThumpRepository.GetByID(selectedPlant.Id);
							MessageBoxResult result = MessageBox.Show("Are you Sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
							if (result == MessageBoxResult.Yes && plantToDelete != null)
							{
								greenThumpRepository.Remove(plantToDelete.Id);
								context.SaveChanges();
								lstPlants.Items.RemoveAt(i);
							}
							else
							{
								//MessageBox.Show()
							}
						}
						break;
					}
				}
			}
			else
			{
				MessageBox.Show("Select a plant to remove", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}


	}
};