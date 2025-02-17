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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var database = MongoDbContext.Instance.Database;
            listele listeleForm = new listele();

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            listele list = new listele();
            list.Show();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            ekleme ekle = new ekleme();
            ekle.Show();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class MongoDbContext
    {
        private static MongoDbContext _instance;
        private readonly IMongoDatabase _database;

        // Singleton: Tek bir instance ile çalışır
        private MongoDbContext()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("kutuphanedb");
        }

        public static MongoDbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MongoDbContext();
                }
                return _instance;
            }
        }

        public IMongoDatabase Database => _database;
    }
}
