using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using System.Data.SqlClient;

namespace GorselProgramlama_20703028
{
    /// <summary>
    /// YazarEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class YazarEkle : Window
    {
        public YazarEkle()
        {
            InitializeComponent();
        }

        public void YazarEkle_Button(object sender, RoutedEventArgs e)
        {
            string yazar = _yazar.Text;
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-2CUR2P6\\SQLEXPRESS; Initial Catalog = Kutuphane; Integrated Security = True");
            
            if(yazar != null)
            {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT Yazar VALUES ('" + yazar + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Yazar başarıyla eklendi!");
                this.Close();
            } else
            {
                MessageBox.Show("Lütfen yazar adı giriniz!");
            }
        }
    }
}
