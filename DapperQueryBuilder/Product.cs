using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperQueryBuilder
{

    [Table("Products", Schema = "Example")]
    public class Product
    {
        public int Id { get; set; }
        [Column("ProductName")]
        public string Name { get; set; }    
    }
}
