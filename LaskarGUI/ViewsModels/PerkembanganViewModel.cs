using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laskar.Shared.Models;

namespace LaskarGUI.ViewModels
{
    public class PerkembanganViewModel : PerkembanganSiswa
    {
        public string Agama
        {
            get => CatatanPerKategori.GetValueOrDefault(KategoriPerkembangan.Kategori.NilaiAgama, "");
            set => CatatanPerKategori[KategoriPerkembangan.Kategori.NilaiAgama] = value;
        }

        public string JatiDiri
        {
            get => CatatanPerKategori.GetValueOrDefault(KategoriPerkembangan.Kategori.JatiDiri, "");
            set => CatatanPerKategori[KategoriPerkembangan.Kategori.JatiDiri] = value;
        }

        public string Literasi
        {
            get => CatatanPerKategori.GetValueOrDefault(KategoriPerkembangan.Kategori.LiterasiDanSTEM, "");
            set => CatatanPerKategori[KategoriPerkembangan.Kategori.LiterasiDanSTEM] = value;
        }

        public string P5
        {
            get => CatatanPerKategori.GetValueOrDefault(KategoriPerkembangan.Kategori.ProyekPenguatanPancasila, "");
            set => CatatanPerKategori[KategoriPerkembangan.Kategori.ProyekPenguatanPancasila] = value;
        }
    }

}
