using System.ComponentModel.DataAnnotations.Schema;

namespace ShopASP.Models
{
    public class BaseEntity
    {
        [Column("CreatedAt")]
        public DateTime? CreatedDate { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedDate { get; set; }
    }
}
