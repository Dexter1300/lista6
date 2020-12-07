using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace lista6
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string sciezka = "";

        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (imie.Text == "" || nazwisko.Text == "" || wiek.Text == "" || Pesel.Text == "")
            {
                MessageBox.Show("Wprowadz wszystkie dane");
            }
            else
            {
                MainWindow.m_oPersonList.Add(new MainWindow.Person() { StudentId = MainWindow.m_oPersonList.Count + 1, FirstName = imie.Text, LastName = nazwisko.Text, Age = Convert.ToInt16(wiek.Text), Pesel = Convert.ToInt64(Pesel.Text), obraz = sciezka });

                string connetionString;
                SqlConnection cnn;
                connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                sql = "INSERT INTO Studenci (Id, FirstName, LastName, Age, Pesel, Obraz)VALUES(3, 'Michał', 'Wieczorek', 25, 90934349090, 'obraz')";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                MessageBox.Show("Dodano nową osobę");
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
        }

        private void Pesel_Preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Nie można podawać liter");
            }
        }

        private void wiek_previews(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Nie można podawać liter");
            }
        }

        private void nazwisko_preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^0-9]+"))
            {
                MessageBox.Show("Nie można podawać liczb");
            }
        }

        private void imie_preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-zA-Z]").IsMatch(e.Text);

            if (!Regex.IsMatch(e.Text, "[^0-9]+"))
            {
                MessageBox.Show("Nie można podawać liczb");
            }
        }
    }
}
