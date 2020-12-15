using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public static List<MainWindow.Person> Lista_tab = new List<MainWindow.Person>();

        private char l;

        public Window4(string letter)
        {
            l = Convert.ToChar(letter);
            InitializeComponent();
            InitBinding();
        }

        void InitBinding()
        {
            Lista_tab.Clear();
            Tabelaryczna.ItemsSource = null;
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, imie = "", nazwisko = "", obraz = "";
            int id, wiek;
            long pesel;

            sql = "SELECT * FROM fNazwiskoNa(@LastName)";

            command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = l;

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                id = dataReader.GetInt32(0);
                imie = dataReader.GetString(1);
                nazwisko = dataReader.GetString(2);
                wiek = dataReader.GetInt32(3);
                obraz = dataReader.GetString(5);
                pesel = dataReader.GetInt64(4);
                Lista_tab.Add(new MainWindow.Person(id, imie, nazwisko, wiek, pesel, obraz));
            }
            Tabelaryczna.ItemsSource = Lista_tab;
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
