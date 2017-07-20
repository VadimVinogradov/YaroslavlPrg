using Proba1.ProjectCod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1.ViewModel
{
    public class NpgsqlConnectVM : ViewModelBase
    {
        //csb.Database = "KassaProba";
        //csb.Host = "localhost";
        //csb.Password = "Rewq1234";
        //csb.Username = "postgres";
        //csb.Port = 5432;
        //csb.ClientEncoding = "Utf8";

        private string _ClientEncoding;
        public string ClientEncoding
        {
            get
            {
                return _ClientEncoding;
            }
            set
            {
                _ClientEncoding = value;
                OnPropertyChanged();
            }
        }

        //сервер (IP)
        private string _Host;
        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
                OnPropertyChanged();
            }
        }

        //порт
        private int _Port;
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
                OnPropertyChanged();
            }
        }

        //имя базы данных
        private string _Database;
        public string Database
        {
            get
            {
                return _Database;
            }
            set
            {
                _Database = value;
                OnPropertyChanged();
            }
        }

        //имя пользователя
        private string _Username;
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }

        //пароль
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }



    }
}
