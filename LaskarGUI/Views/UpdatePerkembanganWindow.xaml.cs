using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using LaskarGUI.ViewModels;
using Laskar.Shared.Models;

namespace LaskarGUI.Views
{
    public partial class UpdatePerkembanganWindow : Window
    {
        private readonly PerkembanganViewModel _item;
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new System.Uri("http://localhost:5077/")
        };

        public UpdatePerkembanganWindow(PerkembanganViewModel item)
        {
            InitializeComponent();
            _item = item;
            DataContext = _item;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            // Build ulang dictionary kategori
            _item.CatatanPerKategori = new()
            {
                [KategoriPerkembangan.Kategori.NilaiAgama] = _item.Agama,
                [KategoriPerkembangan.Kategori.JatiDiri] = _item.JatiDiri,
                [KategoriPerkembangan.Kategori.LiterasiDanSTEM] = _item.Literasi,
                [KategoriPerkembangan.Kategori.ProyekPenguatanPancasila] = _item.P5
            };

            var content = new StringContent(
                JsonSerializer.Serialize<PerkembanganSiswa>(_item),
                Encoding.UTF8,
                "application/json"
            );

            var res = await client.PutAsync($"api/perkembangan/{_item.Id}", content);
            var msg = await res.Content.ReadAsStringAsync();
            MessageBox.Show(msg);

            DialogResult = true;
            Close();
        }
    }
}
