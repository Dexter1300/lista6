using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace lista6
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private string sciezka;
        public string idP;

        public Window3(string text)
        {
            string id = text;
            InitializeComponent();
            InitBinding(id);
        }

        private void InitBinding(string id)
        {
            
            MainWindow.Person oFoundPerson = MainWindow.m_oPersonList.Find(oElement => oElement.StudentId == Convert.ToInt32(id));
            imie.Text = oFoundPerson.FirstName;
            nazwisko.Text = oFoundPerson.LastName;
            wiek.Text = Convert.ToString(oFoundPerson.Age);
            Pesel.Text = Convert.ToString(oFoundPerson.Pesel);
            Uri image = new Uri(oFoundPerson.obraz);
            Picture.Source = new BitmapImage(image);
            idP = id;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imie.IsEnabled = true;
            nazwisko.IsEnabled = true;
            wiek.IsEnabled = true;
            Pesel.IsEnabled = true;
            obrazek.IsEnabled = true;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (imie.Text == "" || nazwisko.Text == "" || wiek.Text == "" || Pesel.Text == "")
            {
                MessageBox.Show("Wprowadz wszystkie dane");
            }
            else
            {
                MainWindow.Person oFoundPerson = MainWindow.m_oPersonList.Find(oElement => oElement.StudentId == Convert.ToInt32(idP));
                oFoundPerson.FirstName = imie.Text;
                oFoundPerson.LastName = nazwisko.Text;
                oFoundPerson.Age = Convert.ToInt32(wiek.Text);
                oFoundPerson.Pesel = Convert.ToInt64(Pesel.Text);
                MessageBox.Show("Edytowano dane");
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Filses(*.jpg; *.jpeg; *.gif; .bmp;)|.jpg; *.jpeg; *.gif; *.bmp; *.png;";

            if (openFileDialog.ShowDialog() == true)
            {
                sciezka = openFileDialog.FileName;
                Uri fileUri = new Uri(openFileDialog.FileName);
                Picture.Source = new BitmapImage(fileUri);
            }
            MainWindow.Person oFoundPerson = MainWindow.m_oPersonList.Find(oElement => oElement.StudentId == Convert.ToInt32(idP));
            oFoundPerson.obraz = Convert.ToString(Picture.Source);
        }

        private void imie_preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^0-9]+"))
            {
                MessageBox.Show("Nie można podawać liczb");
            }

        }

        private void Nazwisko_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^0-9]+"))
            {
                MessageBox.Show("Nie można podawać liczb");
            }
        }

        private void Wiek_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Nie można podawać liter");
            }
        }

        private void Pesel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Nie można podawać liter");
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            SqlDataReader dataReader;
            cnn.Open();

            command = new SqlCommand("pZmiana", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(idP);
            command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = imie.Text;
            command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = nazwisko.Text;
            command.Parameters.Add("@Age", SqlDbType.Int).Value = Convert.ToInt32(wiek.Text);
            command.Parameters.Add("@Pesel", SqlDbType.BigInt).Value = Convert.ToInt64(Pesel.Text);
            command.Parameters.Add("@Obraz", SqlDbType.VarChar).Value = sciezka;

            dataReader = command.ExecuteReader();
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            MessageBox.Show("Edytowano zmiane w bazie");
        }
    }
}
