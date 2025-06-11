using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Laskar.Shared.Models;
using LaskarGUI.ViewModels;

namespace LaskarGUI.Views
{
    public partial class PerkembanganListWindow : Window
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5011/")
        };

        private List<PerkembanganViewModel> _data = new();

        public PerkembanganListWindow()
        {
            InitializeComponent();
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var response = await client.GetAsync("api/perkembangan");
                var json = await response.Content.ReadAsStringAsync();

                var list = JsonSerializer.Deserialize<List<PerkembanganSiswa>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _data = new List<PerkembanganViewModel>();

                foreach (var item in list!)
                {
                    var vm = new PerkembanganViewModel
                    {
                        Id = item.Id,
                        NamaSiswa = item.NamaSiswa,
                        NomorInduk = item.NomorInduk,
                        Kelas = item.Kelas,
                        Semester = item.Semester,
                        TahunAjaran = item.TahunAjaran,
                        Tanggal = item.Tanggal,
                        CatatanPerKategori = item.CatatanPerKategori
                    };

                    // Ekstrak kategori ke properti untuk binding langsung
                    vm.Agama = item.CatatanPerKategori.TryGetValue(KategoriPerkembangan.Kategori.NilaiAgama, out var a) ? a : "";
                    vm.JatiDiri = item.CatatanPerKategori.TryGetValue(KategoriPerkembangan.Kategori.JatiDiri, out var j) ? j : "";
                    vm.Literasi = item.CatatanPerKategori.TryGetValue(KategoriPerkembangan.Kategori.LiterasiDanSTEM, out var l) ? l : "";
                    vm.P5 = item.CatatanPerKategori.TryGetValue(KategoriPerkembangan.Kategori.ProyekPenguatanPancasila, out var p) ? p : "";

                    _data.Add(vm);
                }

                PerkembanganGrid.ItemsSource = null;
                PerkembanganGrid.ItemsSource = _data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private PerkembanganViewModel? GetItemFromSender(object sender)
        {
            if (sender is FrameworkElement fe && fe.DataContext is PerkembanganViewModel vm)
                return vm;

            return null;
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var item = GetItemFromSender(sender);
            if (item == null) return;

            var detailWindow = new DetailPerkembanganWindow(item);
            detailWindow.ShowDialog();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var item = GetItemFromSender(sender);
            if (item == null) return;

            var updateWindow = new UpdatePerkembanganWindow(item);
            if (updateWindow.ShowDialog() == true)
            {
                _ = LoadDataAsync(); // reload data kalau update berhasil
            }
        }

        private async void HapusButton_Click(object sender, RoutedEventArgs e)
        {
            var item = GetItemFromSender(sender);
            if (item == null) return;

            var result = MessageBox.Show($"Yakin ingin menghapus data {item.NamaSiswa}?",
                "Konfirmasi Hapus", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var res = await client.DeleteAsync($"api/perkembangan/{item.Id}");
                    var msg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show(msg);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message);
                }
            }
        }
    }
}
