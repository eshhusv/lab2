using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User { EMail = login.Text, Password = password.Password };
                JsonContent content = JsonContent.Create(user);
                using var response = await client.PostAsync("http://localhost:5054/login", content);
                string responseText = await response.Content.ReadAsStringAsync();
                Response? resp = JsonSerializer.Deserialize<Response>(responseText);
                if (resp != null)
                {
                    Main main = new Main(resp);
                    main.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
