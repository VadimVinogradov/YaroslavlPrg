using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proba1.ProjectCod
{
    public class CheckConnectCL
    {
        /*public static bool CheckConnectServer(string ConnectionString = null)
        {
            if (ConnectionString == null) return false;

            bool yn = true;

            try
            {
                using (NpgsqlConnection conn
                    = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                }
            }
            catch (NpgsqlException ex)
            {
                yn = false;

                System.Media.SystemSounds.Exclamation.Play();
                String s = "ОШИБКА СОЕДИНЕНИЯ С СЕРВЕРОМ ДАННЫХ";
                MessageBox.Show(s
                    + Environment.NewLine
                    + Environment.NewLine
                    + ex.Message);
            }
            return yn;
        }*/

        public static bool CheckConnect(string ConnectionString, out string messageError)
        {
            messageError = string.Empty;
            if (ConnectionString == null)
            {
                messageError = "Строка соединения не указана";
                return false;
            }

            bool yn = true;

            try
            {
                using (NpgsqlConnection conn
                    = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                }
            }
            catch (NpgsqlException ex)
            {
                messageError = ex.Message;
                yn = false;
            }
            return yn;
        }
        public static bool CheckConnect(string ConnectionString = null)
        {
            if (ConnectionString == null) return false;

            bool yn = true;

            try
            {
                using (NpgsqlConnection conn
                    = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                }
            }
            catch
            {
                yn = false;
            }
            return yn;
        }


        public static bool Start()
        {
            /*//-------------------------------------
            //проверка соединения с интернет
            //простая проверка
            bool yesNoWWW = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            //гарантированная проверка
            if (yesNoWWW) yesNoWWW = MyClassLibrary.InternetConnection.yesNoWWW();
            if (!yesNoWWW)
            {
                string s = "Нет соединения с Интернетом !";
                MessageBox.Show(s);
                return false;
            }
            //-------------------------------------*/

            //проверка соединения с основной базой
            bool yesConnect = true;
            //форма для задания строки подключения
            //не открывалась
            bool DialogConnectYesNo = false;
            while (true)
            {
                //расшифрованная строка подключения из реестра
                string sSql = ModelCsCL.ConnectionStringDB;

                //bool OnlyYesNo = true;
                //проверка соединения с основной базой данных
                //if (!MySqlLib.ProjectCod.CheckConnectCL.CheckConnectServer(sSql, OnlyYesNo))
                if (!CheckConnect(sSql))
                {
                    if (MessageBox.Show("Нет соединения с основной базой данных!" +
                        Environment.NewLine +
                        Environment.NewLine +
                        "Предложить формирование строки подключения ?", "ВЫБОР",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.Yes) == MessageBoxResult.Yes)
                    {
                        View.NpgsqlConnect w =
                            new View.NpgsqlConnect(sSql);
                        w.ShowDialog();

                        if (w.DialogResult.HasValue && w.DialogResult.Value)
                        {
                            //зашифровать и записать строку подключения в реестр
                            ModelCsCL.ConnectionStringDB = w.ConnectionString;
                            DialogConnectYesNo = true;
                        }

                        //в начало цикла проверки соединения
                    }
                    else
                    {
                        yesConnect = false; break;//отказались от установки соединения
                    }
                }
                else//есть соединение
                {
                    ////передать строку подключения
                    ////основной базе данных
                    //ModelCsCL.SetConnectionStringToDB();
                    break;
                }

            }


            if (!yesConnect)//соединения нет
            {
                return false;
            }

            //строка соединения могла быть задана
            //при открытии формы задания строки подключения
            if (!DialogConnectYesNo)
            {
                //задать строку подключения для основной базы данных
                ModelEntityCL.CurentConnectionString = ModelCsCL.ConnectionStringDB;
            }

            //холодный запрос
            string message = "Проверка соединения";
            LibraryResource.WWait ww =
                new LibraryResource.WWait(message, WindowStartupLocation.CenterScreen);
            ww.Show();

            bool yes = true;
            //холодный запрос к основной базе данных
            try
            {
                ModelsCL.TovarCL.FirstRun();
            }
            catch
            {
                yes = false;
                ww.Close();//закрыть окно перед выводом сообщения
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Ошибка !"
                    + Environment.NewLine
                    + "Холодный запрос к основной базе данных не прошёл.");
            }

            if (!yes)
            {
                return false;
            }
            else ww.Close();


            return yes;
        }


    }
}
