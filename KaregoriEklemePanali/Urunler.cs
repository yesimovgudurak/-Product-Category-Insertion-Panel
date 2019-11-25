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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }

        //NumericUpDown Maximum Değer arttırılmalı.
        ProjectContext db = new ProjectContext();
        void ProductList()
        {
            lstUrunler.Items.Clear();
            foreach (Product item in db.Products.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ID.ToString();
                lvi.SubItems.Add(item.ProductName);
                lvi.SubItems.Add(item.UnitInStock.ToString());
                lvi.SubItems.Add(item.UnitPrice.ToString());
                lvi.SubItems.Add(item.Category.CategoryName);
                lvi.Tag = item.ID;
                lstUrunler.Items.Add(lvi);
            }
        }

        void CategoryList()
        {
            cmbKategoriler.DataSource = db.Categories.ToList();
            cmbKategoriler.DisplayMember = "CategoryName";
            cmbKategoriler.ValueMember = "ID";
            cmbKategoriler.SelectedIndex = -1;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtUrunAd.Text;
            product.UnitInStock = (short)nmrStokAdet.Value;
            product.UnitPrice = nmrFiyat.Value;
            product.CategoryID = (int)cmbKategoriler.SelectedValue;

            db.Products.Add(product);
            db.SaveChanges();

            txtUrunAd.Text = default(string);
            nmrFiyat.Value = nmrFiyat.Minimum;
            nmrStokAdet.Value = nmrStokAdet.Minimum;
            cmbKategoriler.SelectedIndex = -1;

            ProductList();

        }

        private void Urunler_Load_1(object sender, EventArgs e)
        {
            CategoryList();
            ProductList();
        }



        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItems.Count <= 0) return;

            int id = Convert.ToInt32(lstUrunler.SelectedItems[0].Tag);
            Product deleted = db.Products.Find(id);
            db.Products.Remove(deleted);
            db.SaveChanges();
            ProductList();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

                if (lstUrunler.SelectedItems.Count <= 0 && updated == null) return;
                updated.ProductName = txtUrunAd.Text;
                updated.UnitPrice = nmrFiyat.Value;
                updated.UnitInStock = (short)nmrStokAdet.Value;
                updated.CategoryID = (int)cmbKategoriler.SelectedValue;

                db.Entry(db.Products.Find(updated.ID)).CurrentValues.SetValues(updated);
                db.SaveChanges();

                txtUrunAd.Text = default(string);
                nmrFiyat.Value = nmrFiyat.Minimum;
                nmrStokAdet.Value = nmrStokAdet.Minimum;
                cmbKategoriler.SelectedIndex = -1;

                ProductList();
            
        }

        Product updated;
        private void lstUrunler_DoubleClick_1(object sender, EventArgs e)
        {
            //FullRowSelect property=>true yapılmalı!.
            int id = Convert.ToInt32(lstUrunler.SelectedItems[0].Tag);
            updated = db.Products.Find(id);
            txtUrunAd.Text = updated.ProductName;
            nmrFiyat.Value = (decimal)updated.UnitPrice;
            nmrStokAdet.Value = (decimal)updated.UnitInStock;
            cmbKategoriler.SelectedValue = updated.CategoryID;
        }

        
    }
}
