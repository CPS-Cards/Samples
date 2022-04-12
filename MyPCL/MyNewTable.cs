using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPCL
{
    [Table("MyNewTable")]
    public class MyNewTable : BaseEntity
    {
        public string MyField { get; set; }

    }
}
