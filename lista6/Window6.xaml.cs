using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace lista6
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public static List<View> widoki = new List<View>();
        public Window6()
        {
            InitializeComponent();
            widok();
        }
        void widok()
        {
            widoki.Clear();
            Views.ItemsSource = null;
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, imie = "", nazwisko = "", kierunek = "";
            int id, nrk;

            sql = "SELECT * FROM widok;";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                id = dataReader.GetInt32(0);
                imie = dataReader.GetString(1);
                nazwisko = dataReader.GetString(2);
                nrk = dataReader.GetInt32(3);
                kierunek = dataReader.GetString(4);
                widoki.Add(new View(id, imie, nazwisko, nrk, kierunek));
            }
            Views.ItemsSource = widoki;
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
