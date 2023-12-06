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
    /// Логика взаимодействия для SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        private HttpClient httpClient;
        private Sell? sell;
        public SellWindow(string token)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            Task.Run(() => Load());
        }
        

        private async Task Load()
        {
            List<Sell>? list = await httpClient.GetFromJsonAsync<List<Sell>>("http://localhost:5054/api/Sell");
            Dispatcher.Invoke(() =>
            {
                ListSell.ItemsSource = null;
                ListSell.Items.Clear();
                ListSell.ItemsSource = list;
            });
        }
        private async Task Save()
        {
            Sell sell = new Sell
            {
                Name = NameSell.Text,
                SellingDate = Convert.ToDateTime(SellingDateSell.Text),
                CountOfSold = Convert.ToInt32(CountOfSoldSell.Text),
                PriceOfSold = Convert.ToDouble(PriceOfSoldSell.Text),
                VenorCode = Convert.ToInt32(VenorCodeSell.Text)
            };
            JsonContent content = JsonContent.Create(sell);
            using var response = await httpClient.PostAsync("http://localhost:5054/api/Sell", content);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private async Task Edit()
        {
            sell!.Name = NameSell.Text;
            sell!.SellingDate = Convert.ToDateTime(SellingDateSell.SelectedDate);
            sell!.PriceOfSold = Convert.ToDouble(PriceOfSoldSell.Text);
            sell!.CountOfSold = Convert.ToInt32(CountOfSoldSell.Text);
            sell!.VenorCode = Convert.ToInt32(VenorCodeSell.Text);
            JsonContent content = JsonContent.Create(sell);
            using var response = await httpClient.PutAsync("http://localhost:5054/api/Sell", content);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }
        private async Task Delete()
        {
            using var response = await httpClient.DeleteAsync("http://localhost:5054/api/Sell/" + sell?.Id);
            string responseText = await response.Content.ReadAsStringAsync();
            await Load();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            await Save();
        }

        private void ListSell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sell = ListSell.SelectedItem as Sell;
            if (sell != null)
            {
                NameSell.Text = sell!.Name;
                SellingDateSell.SelectedDate = sell!.SellingDate;
                PriceOfSoldSell.Text = Convert.ToString(sell!.PriceOfSold);
                CountOfSoldSell.Text = Convert.ToString(sell!.CountOfSold);
                VenorCodeSell.Text = Convert.ToString(sell!.VenorCode);
            }
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            await Edit();
        }

        private async void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            await Delete();
        }
    }
}
