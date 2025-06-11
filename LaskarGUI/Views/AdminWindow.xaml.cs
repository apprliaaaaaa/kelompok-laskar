using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using Laskar.Shared.Models;
using ManajemenAkunGuru.Models;

namespace LaskarGUI.Views
{
    public partial class AdminWindow : Window
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5077/")
        };

        private List<GuruModel> guruList = new();

        public AdminWindow()
        {
            InitializeComponent();

            try
            {
                _ = LoadDataGuru(); // async
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Gagal inisialisasi Admin Window: " + ex.Message);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("✅ Admin Window berhasil dibuka.");
        }


        private async System.Threading.Tasks.Task LoadDataGuru()
        {
            try
            {
                var res = await client.GetAsync("api/guru");
                var json = await res.Content.ReadAsStringAsync();

                guruList = JsonSerializer.Deserialize<List<GuruModel>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<GuruModel>();

                GuruDataGrid.ItemsSource = null;
                GuruDataGrid.ItemsSource = guruList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Gagal memuat data guru: " + ex.Message);
            }
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.PostAsync("api/logout", null); // ⬅️ Reset backend state
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Gagal logout dari server: " + ex.Message);
            }

            this.Close(); // tutup window, LoginWindow akan muncul lagi
        }


        private void TambahButton_Click(object sender, RoutedEventArgs e)
        {
            var win = new TambahGuruWindow();
            if (win.ShowDialog() == true)
            {
                _ = LoadDataGuru();

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is GuruModel guru)
            {
                var win = new EditGuruWindow(guru);
                if (win.ShowDialog() == true)
                {
                    _ = LoadDataGuru();
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is GuruModel guru)
            {
                var result = MessageBox.Show($"Yakin ingin menghapus akun guru: {guru.Nama}?",
                    "Konfirmasi Hapus", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var res = await client.DeleteAsync($"api/guru/{guru.Id}");
                    var msg = await res.Content.ReadAsStringAsync();

                    if (res.IsSuccessStatusCode)
                        MessageBox.Show("✅ Akun berhasil dihapus.", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("❌ Gagal menghapus akun: " + msg, "Gagal", MessageBoxButton.OK, MessageBoxImage.Error);

                    await LoadDataGuru();
                }
            }
        }
    }
}
