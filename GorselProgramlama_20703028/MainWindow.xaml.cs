using System;
using System.Collections.Generic;
using System.Data;
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

using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace GorselProgramlama_20703028
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-2CUR2P6\\SQLEXPRESS; Initial Catalog = Kutuphane; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sdr;
        ObservableCollection<Kitap> kutuphane;

        private void Kutuphane()
        {
            kutuphane = new ObservableCollection<Kitap>();
            cmd = new SqlCommand("SELECT Kitap.ID, Kitap.Isim, Sayfa, Yazar.Isim, Yazar.ID FROM Kitap INNER JOIN Yazar ON Yazar.ID = Kitap.YazarID", con);
            con.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Kitap kitap = new Kitap();
                kitap.ID = (int)sdr[0];
                kitap.Ad = sdr[1].ToString();
                kitap.Sayfa = sdr[2].ToString();
                kitap.Yazar = sdr[3].ToString();
                kitap.YazarID = (int)sdr[4];
                kutuphane.Add(kitap);
            }
            con.Close();
            Kitaplik.ItemsSource = kutuphane;
        }
        private void kitapAra(object sender, RoutedEventArgs e)
        {
            kutuphane.Clear();

            string No = KitapNo.Text;
            int Yazar = (Yazarlar.SelectedItem as dynamic).Value ? (Yazarlar.SelectedItem as dynamic).Value : "";
            string Ad = KitapAdi.Text;
            string Sayfa = SayfaSayisi.Text;

            cmd = new SqlCommand("SELECT Kitap.ID, Kitap.Isim, Sayfa, Yazar.Isim FROM Kitap INNER JOIN Yazar ON Yazar.ID = Kitap.YazarID WHERE Kitap.ID = '"+ No + "' OR Kitap.Isim = '" + Ad + "' OR Sayfa = '" + Sayfa + "' OR Yazar.ID = " + Yazar + "", con);
            con.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Kitap kitap = new Kitap();
                kitap.ID = (int)sdr[0];
                kitap.Ad = sdr[1].ToString();
                kitap.Sayfa = sdr[2].ToString();
                kitap.Yazar = sdr[3].ToString();
                kutuphane.Add(kitap);
            }
            con.Close();
            Kitaplik.ItemsSource = kutuphane;
        }
        private void kitapEkle(object sender, RoutedEventArgs e)
        {
            int Yazar = (Yazarlar.SelectedItem as dynamic).Value;
            string Ad = KitapAdi.Text;
            string Sayfa = SayfaSayisi.Text;

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT Kitap(YazarID, Isim, Sayfa) VALUES (" + Yazar + ", '" + Ad + "', " + Sayfa + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Kitap kütüphaneye eklenmiştir.");
            KitapNo.Clear();
            Yazarlar.SelectedIndex = -1;
            KitapAdi.Clear();
            SayfaSayisi.Clear();

        }

        private void tabloTemizle(object sender, RoutedEventArgs e)
        {
            KitapNo.Clear();
            Yazarlar.SelectedIndex = -1;
            KitapAdi.Clear();
            SayfaSayisi.Clear();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized) return;

            ComboBoxItem item = e.OriginalSource as ComboBoxItem;

            if (item != null)
            {
                new YazarEkle().ShowDialog();
            }
        }

        public void UpdateItems()
        {
            Yazarlar.Items.Clear();
            
            ComboBoxItem yeniYazar = new ComboBoxItem();
            yeniYazar.Content = "Yeni Yazar";
            yeniYazar.Selected += new RoutedEventHandler(ComboBoxItem_Selected);
            Yazarlar.Items.Add(yeniYazar);

            cmd = new SqlCommand("SELECT ID, Isim FROM Yazar", con);
            con.Open();
            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Yazarlar.Items.Add(new { Text = sdr[1].ToString(), Value = (int)sdr[0], Index = (int)sdr[0] });
            }

            con.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Kutuphane();
            UpdateItems();
        }

        private void kitapDuzenle(object sender, RoutedEventArgs e)
        {
            Kitap kitap = Kitaplik.SelectedItem as Kitap;

            string No = kitap.ID.ToString();
            int Yazar = kitap.YazarID;
            string Ad = kitap.Ad;
            string Sayfa = kitap.Sayfa;

            KitapNo.Text = No;
            Yazarlar.SelectedIndex = Yazar;
            KitapAdi.Text = Ad;
            SayfaSayisi.Text = Sayfa;

            EkleButton.Content = "Değiştir";
            EkleButton.Click -= kitapEkle;
            EkleButton.Click += new RoutedEventHandler(kitapDegistir);

        }

        private void kitapDegistir(object sender, RoutedEventArgs e)
        {
            string No = KitapNo.Text;
            int Yazar = (Yazarlar.SelectedItem as dynamic).Value;
            string Ad = KitapAdi.Text;
            string Sayfa = SayfaSayisi.Text;

            con.Open();
            cmd = new SqlCommand("UPDATE Kitap SET Isim='"+ Ad +"', Sayfa="+ Sayfa +", YazarID="+ Yazar +" WHERE ID="+ No +"", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kitap Düzenlenmiştir!");

            EkleButton.Content = "Ekle";
            EkleButton.Click -= kitapDegistir;
            EkleButton.Click += new RoutedEventHandler(kitapEkle);
            KitapNo.Clear();
            KitapAdi.Clear();
            SayfaSayisi.Clear();
        }

        private void kitapSil(object sender, RoutedEventArgs e)
        {
            Kitap kitap = Kitaplik.SelectedItem as Kitap;

            int kitapNo = kitap.ID;

            con.Open();
            cmd = new SqlCommand("DELETE FROM Kitap WHERE ID = "+ kitapNo + "", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Kitap listeden silinmiştir!");
        }
    }
}
