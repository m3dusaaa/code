using System;
using System.Collections.Generic;
using WpfApp1.Tools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{ 
[Table("operator")]
public class Oplata : BaseDTO
{
    [Column("datazakaza")]
        public DateTime Zakaza { get; set; }
        [Column("client_id")]
        public string idclient { get; set; }
        [Column("tour_idoperator")]
        public int IDOperator { get; set; }
        [Column("price")]
        public string Price { get; set; }
        
    }
}
