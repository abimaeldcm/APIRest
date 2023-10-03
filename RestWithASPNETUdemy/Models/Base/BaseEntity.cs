using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
