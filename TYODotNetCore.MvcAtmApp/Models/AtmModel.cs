using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TYODotNetCore.MvcAtmApp.Models
{
    [Table("Tbl_Atm")]
    public class AtmModel
    {
        [Key]
        public int AtmId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
