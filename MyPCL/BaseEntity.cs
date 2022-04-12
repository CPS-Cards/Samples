using System.ComponentModel.DataAnnotations;

namespace MyPCL
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}