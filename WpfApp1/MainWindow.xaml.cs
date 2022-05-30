using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window

    {
        ObservableCollection<MyObject> myObjects;
        public MainWindow()
        {
            InitializeComponent();
            myObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){C1 = "İce Tea", C2 = "İçecek",C3="13₺"},
                new MyObject(){C1 = "Coca Cola", C2 = "İçecek", C3="8₺"},
                new MyObject(){C1 = "Lays Sade Patates Cipsi", C2 = "Yiyecek",C3="9₺"}
            };
            this.dgContent.ItemsSource = myObjects;
            urun_kategori.Items.Add("İçecek");
            urun_kategori.Items.Add("Yemek");
            urun_kategori.Items.Add("Elektronik");
        }
        

        
        private void ad_tus_Click(object sender, RoutedEventArgs e)
        {
            if (urun_kategori.SelectedItem == null)
            {
                if (tbEleman.Text.Length > 0 && urun_kategori.Text.Length > 0 && text_fiyat.Text.Length > 0)
                {
                    MyObject myObject = new MyObject() { C1 = this.tbEleman.Text, C2 = this.urun_kategori.Text, C3 = this.text_fiyat.Text };
                    myObjects.Add(myObject);
                    urun_kategori.Items.Add(this.urun_kategori.Text);
                    MessageBox.Show("Ürün Başarıyla Eklendi ve Yeni Kategori eklendi!", "Uyarı Penceresi", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ürün Eklenemedi Lütfen Tüm Alanları Doldurun!", "HATA MEYDANA GELDİ!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MyObject myObject = new MyObject() { C1 = this.tbEleman.Text, C2 = this.urun_kategori.Text, C3 = this.text_fiyat.Text };
                myObjects.Add(myObject);
                MessageBox.Show("Ürün Başarıyla Eklendi!", "Uyarı Penceresi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public class MyObject
        {
            public string C1 { get; set; }
            public string C2 { get; set; }
            public string C3 { get; set; }
        }
        private void Guncelle(object sender, RoutedEventArgs e)
        {
            if (urun_kategori.SelectedItem == null)
            {
                if (tbEleman.Text.Length > 0 && urun_kategori.Text.Length > 0 && text_fiyat.Text.Length > 0)
                {
                    myObjects.Remove((MyObject)dgContent.SelectedItem);
                    MyObject myObject = new MyObject() { C1 = this.tbEleman.Text, C2 = (string)this.urun_kategori.Text, C3 = this.text_fiyat.Text };
                    myObjects.Add(myObject);
                    urun_kategori.Items.Add(this.urun_kategori.Text);
                    MessageBox.Show("Ürün Güncellendi Ve Yeni Kategori Eklendi!", "İşlem Tamam!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ürün GÜNCELLENEMEDİ! Lütfen Tüm Alanları Doldurun!", "HATA MEYDANA GELDİ!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                myObjects.Remove((MyObject)dgContent.SelectedItem);
                MyObject myObject = new MyObject() { C1 = this.tbEleman.Text, C2 = (string)this.urun_kategori.Text, C3 = this.text_fiyat.Text };
                myObjects.Add(myObject);
                MessageBox.Show("Ürün Güncellendi!", "İşlem Tamam!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //urun_kategori.Items.Add(this.urun_kategori.Text);
        }
        private void Sil22(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ürünü silmek istiyormusunuz? Bu işlem geri alınamaz!", "Devam Edilsin mi?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("İşlem İptal Edildi!", "İşlem Tamam!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                myObjects.Remove((MyObject)dgContent.SelectedItem);
                MessageBox.Show("Ürün Silindi!", "İşlem Tamam!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }


    }
}
