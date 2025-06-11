using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using Laskar.Shared.Models;
using ManajemenAkunGuru.Models;

namespace LaskarGUI.Views
{
    public partial class TambahGuruWindow : Window
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5077/")
        };

        public TambahGuruWindow()
        {
            InitializeComponent();
        }

        private async void SimpanButton_Click(object sender, RoutedEventArgs e)
        {
            var guru = new GuruModel
            {
                Nama = NamaBox.Text,
                Username = UsernameBox.Text,
                Password = PasswordBox.Password
            };

            var content = new StringContent(JsonSerializer.Serialize(guru), Encoding.UTF8, "application/json");
            var res = await client.PostAsync("api/guru", content);

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("✅ Akun guru berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                var err = await res.Content.ReadAsStringAsync();
                MessageBox.Show($"❌ Gagal menambahkan akun: {err}", "Gagal", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BatalButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
