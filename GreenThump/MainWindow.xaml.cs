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



            using (GreenThumpDb context = new())
            {
                GreenThumpRepository<Plant> greenThumpRepository = new(context);

                var plant = greenThumpRepository.GetAll();

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

            using (GreenThumpDb context = new())
            {
                GreenThumpRepository<Plant> plants = new(context);

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

            //var filteredPlants = AllPlants.Where(p => p.plant.ToLower().Contains(searchTerm));

            //foreach (var plant in filteredPlants)
            //{
            //    ListViewItem item = new();
            //    item.Tag = plant;
            //    item.Content = plant.Name;

            //    lstPlants.Items.Add(item);
            //}

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


        }
    }
};