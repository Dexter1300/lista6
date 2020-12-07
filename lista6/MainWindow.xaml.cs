using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;

namespace lista6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Person> m_oPersonList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("Brak pliku do załadowania!", "Uwaga", MessageBoxButton.OK);
            }

           


            lstPersons.ItemsSource = m_oPersonList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3(id.Text);
            win3.Show();
        }

        //Refresh
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            lstPersons.ItemsSource = null;
            lstPersons.ItemsSource = m_oPersonList;
        }

        //Load
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            InitBinding();
        }

        //Connect
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select TutorialID, TutorialName from demotb";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        public class Person
        {
            [XmlAttribute("id")]
            public int StudentId { get; set; }

            [XmlAttribute("imie")]
            public string FirstName { get; set; }

            [XmlAttribute("nazwisko")]
            public string LastName { get; set; }

            [XmlAttribute("wiek")]
            public int Age { get; set; }

            [XmlAttribute("pesel")]
            public long Pesel { get; set; }

            [XmlElement("Obraz")]
            public string obraz { get; set; }

            public Person(int nStudentId, string sFirstName, string sLastName, int nAge, long lPesel, string Obraz)
            {
                StudentId = nStudentId;
                FirstName = sFirstName;
                LastName = sLastName;
                Age = nAge;
                Pesel = lPesel;
                obraz = Obraz;
            }

            public Person()
            {
                StudentId = 0;
                FirstName = "Janusz";
                LastName = "Januszewski";
                Age = 120;
                Pesel = 999909090;
                obraz = "image";
            }
        }

        private void Id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

       
    }
}
