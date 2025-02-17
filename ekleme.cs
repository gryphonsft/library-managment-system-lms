using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static kütüphaneYonetimUygulamasi.listele;

namespace kütüphaneYonetimUygulamasi
{
    public partial class ekleme : Form
    {
        private readonly IMongoDatabase _database;
        public ekleme()
        {
            InitializeComponent();
            _database = MongoDbContext.Instance.Database;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
           
            string kitapAdı = ktpadıtxt.Text;
            string yazar = ktpyazartxt.Text;
            int sayfaSayısı = 0;

           
            if (!int.TryParse(ktpsayfatxt.Text, out sayfaSayısı))
            {
                MessageBox.Show("Sayfa sayısı geçerli bir sayı olmalıdır.");
                return;
            }

            string türü = ktpturutxt.Text;

            
            Kitaps yeniKitap = new Kitaps
            {
                kitapadi = kitapAdı,
                yazar = yazar,
                sayfasayisi = sayfaSayısı,
                turu = türü
            };

            
            var collection = _database.GetCollection<Kitaps>("Kitaplar");
            collection.InsertOne(yeniKitap);
            msgdialog.Show("Kitap başarıyla eklendi!");
            this.Close();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
