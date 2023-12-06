using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private HttpClient httpClient;
        private MainWindow mainWindow;
        private Admission? admission;
        private string token;
        public Main(Response response)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + response.access_token);
            token = response.access_token;
            Task.Run(() => Load());
        }
        public async Task Load()
        {
            List<Admission>? list = await httpClient.GetFromJsonAsync<List<Admission>>("http://localhost:5054/api/Admission");
            int i = 0;
            Dispatcher.Invoke(() =>
            {
                ListAdmission.ItemsSource = null;
                ListAdmission.Items.Clear();
                ListAdmission.ItemsSource = list;
            });
        }
        private async Task Delete()
        {
            using var response = await httpClient.DeleteAsync("http://localhost:5054/api/Admission/" + admission?.VenorCode);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            this.mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SellWindow sellWindow = new SellWindow(token);
            sellWindow.ShowDialog();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow(token!);
            if (productWindow.ShowDialog() == true)
            {
                Admission sell = new Admission
                {
                    Name=productWindow.NameProperty,
                    Price=productWindow.PriceProperty,
                    VenorCode= productWindow.VenorCodeProperty
                };
                JsonContent content = JsonContent.Create(sell);
                using var response = await httpClient.PostAsync("http://localhost:5054/api/Admission", content);
                string responseText = await response.Content.ReadAsStringAsync();
                await Load();
            }
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Admission? st = ListAdmission.SelectedItem as Admission;
            ProductWindow productWindow = new ProductWindow(token!, st!);
            if (productWindow.ShowDialog() == true)
            {
                st!.VenorCode = productWindow.VenorCodeProperty;
                st!.Name = productWindow.NameProperty;
                st!.Price = productWindow.PriceProperty;
                JsonContent content = JsonContent.Create(st);
                using var response = await httpClient.PutAsync("http://localhost:5054/api/Admission", content);
                string responseText = await response.Content.ReadAsStringAsync();
                await Load();
            }
        }

        private async void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Admission? st = ListAdmission.SelectedItem as Admission;
            JsonContent content = JsonContent.Create(st);
            using var response = await httpClient.DeleteAsync("http://localhost:5054/api/Admission/" + st!.VenorCode);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
    }
}
