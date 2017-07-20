using Proba1.Models;
using Proba1.ProjectCod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1.ModelsCL
{
    public class TovarCL
    {
        DbDataContext db = ModelEntityCL.GetEntities();
        Tovar dt = null;
        public bool isNull = false;

        public TovarCL(int TovarId = 0)
        {
            if (TovarId == 0)
            {
                dt = new Tovar();
                dt.TovarId = 0;
                db.Tovars.Add(dt);
            }
            else
            {
                //dt = db.Tovars
                //    .Where(a => a.TovarId == TovarId)
                //    .FirstOrDefault();

                dt = db.Tovars
                    .FirstOrDefault(a => a.TovarId == TovarId);
            }
            isNull = (dt == null);
        }

        public int TovarId
        {
            get
            {
                return dt.TovarId;
            }
        }

        //public int Npp
        //{
        //    get
        //    {
        //        return dt.Npp.HasValue ? dt.Npp.Value : 0;
        //    }
        //    set
        //    {
        //        dt.Npp = value;
        //    }
        //}

        public string Name
        {
            get
            {
                return dt.Name != null ? dt.Name.Trim() : "";
            }
            set
            {
                dt.Name = MyClassLibrary.Atributs.stringMaxLenth(value, 200);
                //dt.Name = value;
            }
        }

        public int Kod
        {
            get
            {
                return dt.Kod;
            }
            set
            {
                dt.Kod = value;
            }
        }

        public decimal Cena
        {
            get
            {
                return dt.Cena;
            }
            set
            {
                dt.Cena = value;
            }
        }


        //------------------------------------
        public bool Update()
        {
            //if (Npp == 0) Npp = maxNpp() + 1;

            //редактирование и небыло изменений - вернуть как будьто записал
            if (TovarId > 0 && !db.ChangeTracker.HasChanges()) return true;
            else return db.SaveChanges() == 1;
        }
        //------------------------------------
        public bool Delete()
        {
            db.Tovars.Remove(dt);
            return db.SaveChanges() == 1;
        }
        //------------------------------------

        //int maxNpp()
        //{
        //    int? npp = db.Tovars.Max(a => a.Npp).GetValueOrDefault();
        //    return npp.HasValue ? npp.Value : 0;
        //}



        //холодный запрос для проверки доступа к базе данных
        //при запуске программы
        public static bool FirstRun()
        {
            DbDataContext db = ModelEntityCL.GetEntities();
            var v = db.Tovars.FirstOrDefault();
            //var v = db.Tovars.Count();
            return true;
        }
    }
}
