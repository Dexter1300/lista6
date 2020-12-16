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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public static List<Rejestr> Logs_list = new List<Rejestr>();
        public Window5()
        {
            InitializeComponent();
            Logi();
        }
        void Logi()
        {
            Logs_list.Clear();
            Logs.ItemsSource = null;
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, type = "", data = "";
            int id;

            sql = "SELECT * FROM student_log";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                id = dataReader.GetInt32(0);
                type = dataReader.GetString(1);
                data = dataReader.GetString(2);
                Logs_list.Add(new Rejestr(id, type, data));
            }
            Logs.ItemsSource = Logs_list;
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
