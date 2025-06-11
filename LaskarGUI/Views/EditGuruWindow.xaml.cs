using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using Laskar.Shared.Models;
using ManajemenAkunGuru.Models;

namespace LaskarGUI.Views
{
    public partial class EditGuruWindow : Window
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5077/")
        };

        private readonly GuruModel _guru;

        public EditGuruWindow(GuruModel guru)
        {
            InitializeComponent();
            _guru = guru;

            NamaBox.Text = guru.Nama;
            UsernameBox.Text = guru.Username;
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var updated = new GuruModel
            {
                Id = _guru.Id,
                Nama = NamaBox.Text,
                Username = UsernameBox.Text,
                Password = string.IsNullOrWhiteSpace(PasswordBox.Password) ? _guru.Password : PasswordBox.Password
            };

            var content = new StringContent(JsonSerializer.Serialize(updated), Encoding.UTF8, "application/json");
            var res = await client.PutAsync($"api/guru/{_guru.Id}", content);

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("✅ Data guru berhasil diperbarui!", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                var err = await res.Content.ReadAsStringAsync();
                MessageBox.Show($"❌ Gagal update: {err}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BatalButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
