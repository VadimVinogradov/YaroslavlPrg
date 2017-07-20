using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proba1.ProjectCod
{
    public class StartCL
    {
        public static void StartProgram(object sender, StartupEventArgs e)
        {
            ////сброс начальных значений строк соединения
            //string resetCS2 = @"server = ; user id = ; persistsecurityinfo = ; database = ; port = ";
            //ModelCsCL.ConnectionStringDB = resetCS2;

            //обработка параметров программы
            bool YesNoReset = false;
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "/ics")//init connection string
                {
                    System.Media.SystemSounds.Question.Play();
                    if (MessageBox.Show(
                        "Выполнить сброс строки подключения к базам данных ?"
                        , "СБРОС   СТРОКИ   ПОДКЛЮЧЕНИЯ"
                        , MessageBoxButton.YesNo
                        , MessageBoxImage.Question
                        , MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        //сброс начальных значений строк соединения
                        string resetCS = @"server = ; user id = ; persistsecurityinfo = ; database = ; port = ";
                        ModelCsCL.ConnectionStringDB = resetCS;

                        MessageBox.Show("Сброс строки подключения выполнен!");
                        YesNoReset = true;
                    };
                    continue;
                }
                if (e.Args[i] == "/ir")//init reestr
                {
                    System.Media.SystemSounds.Question.Play();
                    if (MessageBox.Show(
                        "Выполнить сброс данных сохранённых в реестре ?"
                        , "СБРОС   ДАННЫХ   В   РЕЕСТРЕ"
                        , MessageBoxButton.YesNo
                        , MessageBoxImage.Question
                        , MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Сброс данных сохранённых в реестре выполнен!");
                        YesNoReset = true;
                    };
                    continue;
                }
            }
            if (YesNoReset) Application.Current.Shutdown();

            //чтение данных из реестра
            ReestrCL.readDataFromReestr();
        }


    }
}
