using Npgsql;

namespace Proba1.ProjectCod
{
    public class ModelEntityCL
    {
        public static Models.DbDataContext GetEntities()
        {
            return new Models.DbDataContext();
        }


        //строка соединения для выполнения миграций
        private static string GetConnectionString()
        {
            NpgsqlConnectionStringBuilder csb
                = new NpgsqlConnectionStringBuilder();
            csb.Database = "KassaProba";
            csb.Host = "localhost";
            csb.Password = "Rewq1234";
            csb.Username = "postgres";
            csb.Port = 5432;
            csb.ClientEncoding = PrgCL.EnumClientEncoding.Utf8.ToString(); //"Utf8";
            //csb.ClientEncoding = "WIN1251";

            return csb.ConnectionString;
        }

        //------------------------------------------------------
        //строка соединения используемая в процессе работы
        static string _ConnectionString = GetConnectionString();
        public static string CurentConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        //-------------------------------------------------------
    }
}
