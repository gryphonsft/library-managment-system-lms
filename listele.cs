using MongoDB.Bson;
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

namespace kütüphaneYonetimUygulamasi
{
    public partial class listele : Form
    {
        private readonly IMongoDatabase _database;


        public listele()
        {
            InitializeComponent();
            _database = MongoDbContext.Instance.Database;

        }

        private void listele_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }
        private void VerileriYukle()
        {
            var collection = _database.GetCollection<Kitaps>("Kitaplar");
            var kitaplar = collection.Find(k => true).ToList();
            dataGridView1.DataSource = kitaplar;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Refresh();
        }

        public class Kitaps
        {
            public ObjectId Id { get; set; }
            public string kitapadi { get; set; }
            public string yazar { get; set; }
            public int sayfasayisi { get; set; }
            public string turu { get; set; }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
