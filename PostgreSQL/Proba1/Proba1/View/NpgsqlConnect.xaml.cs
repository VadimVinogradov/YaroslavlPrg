using Npgsql;
using Proba1.ProjectCod;
using Proba1.ViewModel;
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

namespace Proba1.View
{
    public partial class NpgsqlConnect : Window
    {
        NpgsqlConnectVM vm = new NpgsqlConnectVM();

        public string ConnectionString = string.Empty;//return value


        public NpgsqlConnect(string ConnectionString = null)
        {
            InitializeComponent();

            if (ConnectionString != null)
            {
                this.ConnectionString = ConnectionString;
            }
        }

        private void WLoaded(object sender, RoutedEventArgs e)
        {
            string cs;
            if (ConnectionString == string.Empty
                || ConnectionString.Length == 0)
            {
                //--------------------------------------------------
                //расшифрованная строка подключения из реестра
                cs = ModelCsCL.ConnectionStringDB;
                //--------------------------------------------------
            }
            else
                cs = ConnectionString;

            if (string.IsNullOrEmpty(cs)
                || string.IsNullOrWhiteSpace(cs))
            {
                vm.Database = "KassaProba";
                vm.Host = "localhost";
                vm.Password = "Rewq1234";
                vm.Username = "postgres";
                vm.Port = 5432;
                vm.ClientEncoding = PrgCL.EnumClientEncoding.Utf8.ToString(); //"Utf8";
            }
            else
            {
                NpgsqlConnectionStringBuilder csb
                = new NpgsqlConnectionStringBuilder(cs);
                //vm.Server = csb.Server;
                //vm.Port = csb.Port;
                //vm.Database = csb.Database;
                //vm.UserID = csb.UserID;
                //vm.Password = csb.Password;

                vm.Database = csb.Database;// "KassaProba";
                vm.Host = csb.Host;// "localhost";
                vm.Password = csb.Password;// "Rewq1234";
                vm.Username = csb.Username;// "postgres";
                vm.Port = csb.Port;// 5432;
                vm.ClientEncoding = csb.ClientEncoding;// PrgCL.EnumClientEncoding.Utf8.ToString(); //"Utf8";
            }

            tbPassword.Password = vm.Password;

            DataContext = vm;
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        //-------------------------------------------------------------
        private void bCheck_Click(object sender, RoutedEventArgs e)
        {
            CheckPw();
        }
        private void bWright_Click(object sender, RoutedEventArgs e)
        {
            bool wright = true;
            CheckPw(wright);
        }
        private void CheckPw(bool wright = false)
        {
            string Host = vm.Host.Trim();
            if (Host.Length == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Host не указан !");
                return;
            }

            int Port = vm.Port;
            if (Port == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Порт не указан !");
                return;
            }

            string Database = vm.Database.Trim();
            if (Database.Length == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Имя базы данных не указано !");
                return;
            }

            string Username = vm.Username.Trim();
            if (Username.Length == 0)
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Имя пользователя не указано !");
                return;
            }

            //пароль может быть пустым (без пароля)
            string Password = tbPassword.Password.Trim();

            //if (Password.Length == 0)
            //{
            //    System.Media.SystemSounds.Exclamation.Play();
            //    MessageBox.Show("Пароль не указан !");
            //    return;
            //}

            NpgsqlConnectionStringBuilder csb
                = new NpgsqlConnectionStringBuilder();
            csb.Host = Host;
            csb.Port = Port;
            csb.Database = Database;
            csb.Username = Username;
            csb.Password = Password;
            csb.ClientEncoding = vm.ClientEncoding;

            //строка соединения
            string cs = csb.ConnectionString;
            //проверка соединения
            bool yn = CheckConnectCL.CheckConnect(cs);

            if (yn && wright) //запись пароля
            {
                ConnectionString = cs;//return value

                //--------------------------------------------------
                //зашифровать и записать строку подключения в реестр
                ModelCsCL.ConnectionStringDB = ConnectionString;
                //--------------------------------------------------

                this.DialogResult = true;
            }
            else if (yn)      //проверка пароля
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("OK!");
            }
            else      //проверка пароля
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Соединения НЕТ!");
            }
        }
        //-------------------------------------------------------------


        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
