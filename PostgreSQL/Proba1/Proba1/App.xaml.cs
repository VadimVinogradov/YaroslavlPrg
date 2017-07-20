using Proba1.ProjectCod;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Proba1
{
    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
            this.Exit += App_Exit;
        }


        private void App_Startup(object sender, StartupEventArgs e)
        {
            //----------------------------------------------------
            //не закрывать приложение если будут открыты и закрыты
            //какие либо окна при инициализации
            ShutdownMode mode = this.ShutdownMode;
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //----------------------------------------------------

            //----------------------------------------------------
            //начальная инициализация - (чтение данных из реестра)
            //получение начальных данных,
            //которые не требуют соединения с базами данных
            //задаётся строка подключения для базы справочников (контрагенты)
            StartCL.StartProgram(sender, e);
            //----------------------------------------------------


            bool YesNoPw = false;//пароль не верен

            //----------------------------------------------------
            //проверка соединения с интернетом (если он требуется)
            //проверка соединения с базами данных
            if (CheckConnectCL.Start())
            {
                //----------------------------------------------------
                //дополнительная инициализация после
                //проверки соединения с базами данных
                //StartCL.SetData();
                //----------------------------------------------------

                YesNoPw = true;
                /*//проверка пароля на вход в программу
                YesNoPw = CheckPw();

                //проверка на разрешение работы с программой
                if (YesNoPw)//пароль верен
                {
                    bool y = RabWorkCL.YesNoRabWork(PrgCL.RabIdPrg);
                    if (!y)
                    {
                        YesNoPw = false;//выйти

                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("У Вас нет разрешения на работу с программой !"
                            + System.Environment.NewLine
                            + System.Environment.NewLine
                            + "Обратитесь за разрешением к старшему по регистратуре!");
                    }
                }*/

                //вернуть начальный режим выхода из приложения
                this.ShutdownMode = mode;

            }
            else
            {
                this.Shutdown();
            }
            //----------------------------------------------------

            //выход если не верен пароль
            //или нет разрешения на работу с программой
            if (!YesNoPw) Shutdown();

            //StartCL.InitData();//Инициализация справочников и других данных

            //запуск приложения!!!
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            ExitCL.ExitProgram();
        }


        //проверка пароля на вход в программу
        //bool CheckPw()
        //{
        //    bool YesNo = false;
        //    CheckPassword w = new CheckPassword();
        //    var rez = w.ShowDialog();
        //    if (rez.HasValue && rez.Value)
        //    {
        //        YesNo = w.YesPassword;
        //        //MessageBox.Show(w.YesPassword.ToString());
        //    }
        //    return YesNo;
        //}



    }
}
