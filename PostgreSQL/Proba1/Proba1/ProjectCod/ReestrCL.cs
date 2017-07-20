using Microsoft.Win32;
using System.Reflection;

namespace Proba1.ProjectCod
{
    public class ReestrCL
    {
        //----------------------------------------------------------------
        // работа с реестром
        public static string reestrKeyNameIn = @"Software\C#Prg\"
            + Assembly.GetEntryAssembly().GetName().Name;
        public static string reestrKeyName = reestrKeyNameIn;
        public static string reestrKeyNameNstr = reestrKeyNameIn + @"\Nstr";
        //----------------------------------------------------------------

        public static void DeleteSubKeyTreeReestr()
        {
            Registry.CurrentUser.DeleteSubKeyTree(reestrKeyName);
        }


        //----------------------------------------------------------------
        public static string NameCsDB = "csdb_"
            + Assembly.GetEntryAssembly().GetName().Name;
        public static string NameCsDBSpr = "csdbSpr_"
            + Assembly.GetEntryAssembly().GetName().Name;
        //расшифровать строку подключения сохранённую в реестре
        public static string DecryptCsDBFromReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return string.Empty;

                string s = (string)rk.GetValue(NameCsDB, string.Empty);
                //расшифровать строку подключения
                s = WpfAll.EnDecryptCSCL.GetDecriptString(s);
                return s;
            }
        }
        //расшифровать строку подключения сохранённую в реестре
        public static string DecryptCsDBSprFromReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return string.Empty;

                string s = (string)rk.GetValue(NameCsDBSpr, string.Empty);
                //расшифровать строку подключения
                s = WpfAll.EnDecryptCSCL.GetDecriptString(s);
                return s;
            }
        }
        //зашифровать строку подключения и записать в реестр
        public static bool EncryptCsDBToReestr(string cs)
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return false;

                //зашифровать строку подключения
                cs = WpfAll.EnDecryptCSCL.GetEncriptString(cs);
                rk.SetValue(NameCsDB, cs);
                return true;
            }
        }
        //зашифровать строку подключения и записать в реестр
        public static bool EncryptCsDBSprToReestr(string cs)
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return false;

                //зашифровать строку подключения
                cs = WpfAll.EnDecryptCSCL.GetEncriptString(cs);
                rk.SetValue(NameCsDBSpr, cs);
                return true;
            }
        }
        //----------------------------------------------------------------

        //----------------------------------------------------------------
        public static void readDataRabIdPrgFromReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return;

                //PrgCL.RabIdPrg = (int)rk.GetValue("RabIdPrg", 0);
            }
        }
        public static void saveDataRabIdPrgToReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return;

                //rk.SetValue("RabIdPrg", PrgCL.RabIdPrg);
            }
        }

        public static void readDataFromReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return;

                //PrgCL.SpecialnostId = (int)rk.GetValue("SpecialnostId", 0);
                //PrgCL.SpecialistId = (int)rk.GetValue("SpecialistId", 0);
                //PrgCL.DtPriem = Convert.ToDateTime(rk.GetValue("DtPriem", DateTime.Now));

                //PrgCL.RabGroupId = (int)rk.GetValue("RabGroupId", 0);
                //PrgCL.RabId = (int)rk.GetValue("RabId", 0);

                //PrgCL.idrab = (int)rk.GetValue("idrab", 0);
                //PrgCL.OrgRekId = (int)rk.GetValue("OrgRekId", 0);

                ////перечисление
                //PrgCL.ViborZapisNzUchRab =
                //    (NzUchRab.viborZap)rk.GetValue("NzUchRab.viborZap", NzUchRab.viborZap.onliNoYes);

                //PrgCL.yearMonthRep = Convert.ToBoolean(rk.GetValue("yearMonthRep", true));
                //PrgCL.allRabOneRabRep = Convert.ToBoolean(rk.GetValue("allRabOneRabRep", true));
            }
        }
        public static void saveDataToReestr()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(reestrKeyName))
            {
                if (rk == null) return;

                //rk.SetValue("SpecialnostId", PrgCL.SpecialnostId);
                //rk.SetValue("SpecialistId", PrgCL.SpecialistId);
                //rk.SetValue("DtPriem", PrgCL.DtPriem);

                //rk.SetValue("RabGroupId", PrgCL.RabGroupId);
                //rk.SetValue("RabId", PrgCL.RabId);

                //rk.SetValue("idrab", PrgCL.idrab);
                //rk.SetValue("OrgRekId", PrgCL.OrgRekId);

                ////перечисление
                //rk.SetValue("NzUchRab.viborZap", (int)PrgCL.ViborZapisNzUchRab);

                ////rk.SetValue("yearMonthRep", PrgCL.yearMonthRep);
                ////rk.SetValue("allRabOneRabRep", PrgCL.allRabOneRabRep);
            }
        }
        //----------------------------------------------------------------

        //----------------------------------------------------------------
        public static bool saveStrToReestr(string keyName, string keyValue)
        {
            return WpfAll.Reestr.saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        public static bool saveBoolToReestr(string keyName, bool keyValue)
        {
            return WpfAll.Reestr.saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        public static bool saveIntToReestr(string keyName, int keyValue)
        {
            return WpfAll.Reestr.saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        public static bool saveDoubleToReestr(string keyName, double keyValue)
        {
            return WpfAll.Reestr.saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        //----------------------------------------------------------------
        public static string readStrFromReestr(string keyName)
        {
            return WpfAll.Reestr.readValueStrFromReestr(reestrKeyName, keyName);
        }
        public static bool readBoolFromReestr(string keyName)
        {
            return WpfAll.Reestr.readValueBoolFromReestr(reestrKeyName, keyName);
        }
        public static int readIntFromReestr(string keyName)
        {
            return WpfAll.Reestr.readValueIntFromReestr(reestrKeyName, keyName);
        }
        public static double readDoubleFromReestr(string keyName)
        {
            return WpfAll.Reestr.readValueDoubleFromReestr(reestrKeyName, keyName);
        }
        //----------------------------------------------------------------

        //----------------------------------------------------------------
        public static bool saveSizeToReestr(string keyName,
            System.Windows.Size keyValue)
        {
            return WpfAll.Reestr.
                saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        public static System.Windows.Size readSizeFromReestr(string keyName)
        {
            return WpfAll.Reestr.
                readValueSizeFromReestr(reestrKeyName, keyName);
        }

        public static bool savePointToReestr(string keyName,
             System.Windows.Point keyValue)
        {
            return WpfAll.Reestr.
                saveValueToReestr(reestrKeyName, keyName, keyValue);
        }
        public static System.Windows.Point readPointFromReestr(string keyName)
        {
            return WpfAll.Reestr.
                readValuePointFromReestr(reestrKeyName, keyName);
        }
        //----------------------------------------------------------------


    }
}
