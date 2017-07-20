using Npgsql;
using Proba1.ProjectCod;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace Proba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bCheckConnect_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlConnectionStringBuilder csb
                = new NpgsqlConnectionStringBuilder();
            csb.Database = "Proba";
            csb.Host = "localhost";
            csb.Password = "Rewq1234";
            csb.Username = "postgres";
            csb.Port = 5432;
            csb.ClientEncoding = "Utf8";
            //csb.ClientEncoding = "WIN1251";

            string pgConnectionString
                = csb.ConnectionString;

            string mesError = string.Empty;
            bool yn = CheckConnectCL.CheckConnect(pgConnectionString, out mesError);

            string s = "";
            if (yn)
            {
                using (NpgsqlConnection conn
                    = new NpgsqlConnection(pgConnectionString))
                {
                    conn.Open();

                    NpgsqlCommand command
                        = new NpgsqlCommand(@"SELECT * FROM tovars", conn);
                    int i = 0;
                    try
                    {
                        NpgsqlDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                            ++i;
                            s += (i > 1 ? Environment.NewLine : "")
                                + (string)dr["Name"];
                            }

                        dr.Close();
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                s = "No"
                    + Environment.NewLine
                    + mesError;
            }
            MessageBox.Show(s);
        }


        private void NewConnect()
        {
            //база данных - основная
            string sSql = ModelCsCL.ConnectionStringDB;
            //MessageBox.Show(sSql);
            View.NpgsqlConnect w =
                            new View.NpgsqlConnect(sSql);
            w.ShowDialog();
            //f.MainHeader = "ФОРМИРОВАНИЕ   СТРОКИ   ПОДКЛЮЧЕНИЯ   ДЛЯ   ОСНОВНОЙ   БАЗЫ   ДАННЫХ";
            if (w.DialogResult.HasValue && w.DialogResult.Value)
            {
                ModelCsCL.ConnectionStringDB = w.ConnectionString;
            }
        }



    }
}
