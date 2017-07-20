using System.ComponentModel.DataAnnotations;

namespace Proba1.Models
{
    public class Tovar
    {
        [Key]
        public int TovarId { get; set; }


        //наименование товара
        [MaxLength(200)]
        public string Name { get; set; }

        public int Kod { get; set; }

        public decimal Cena { get; set; }
    }
}
