using KaregoriEklemePanali.ORM.Context;
using KaregoriEklemePanali.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaregoriEklemePanali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();

        public void CategoryList()
        {
            lstKategoriler.Items.Clear();
            foreach (Category item in db.Categories.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ID.ToString();
                lvi.SubItems.Add(item.CategoryName);
                lvi.SubItems.Add(item.Description);

                lstKategoriler.Items.Add(lvi);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtAd.Text;
            category.Description = txtAcıklama.Text;

            db.Categories.Add(category);
            db.SaveChanges();

            txtAcıklama.Text = string.Empty;
            txtAd.Text = string.Empty;
            CategoryList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Urunler frm = new Urunler();
            frm.Show();
        }
    }
}
