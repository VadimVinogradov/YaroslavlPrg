using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1.ProjectCod
{
    public class ModelCsCL
    {
        //расшифрованная строка подключения из реестра
        public static string _ConnectionStringDB =
            ReestrCL.DecryptCsDBFromReestr();


        //Задаваемое значение строки подключения
        public static string ConnectionStringDB
        {
            get
            {
                return _ConnectionStringDB;
            }
            set
            {
                _ConnectionStringDB = value;

                //--------------------------------------------------
                //задать строку подключения для основной базы данных
                ModelEntityCL.CurentConnectionString = value;
                //--------------------------------------------------

                //--------------------------------------------------
                //зашифровать и записать строку подключения в реестр
                ReestrCL.EncryptCsDBToReestr(value);
                //--------------------------------------------------
            }
        }

    }
}
