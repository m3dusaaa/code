using System;
using System.Collections.Generic;
using WpfApp1.Tools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
        [Table("operator")]
        public class Operator : BaseDTO
        {
        [Column("operatorfio")]
        public string OperatorFIO { get; set; }
        [Column("phone")]
        public string PhoneNumber { get; set; }
        [Column("idoperator")]
        public int OperatorID { get; set; }
        [Column("tour_order_num")]
        public int Tour_order_num { get; set; }
        [Column("tour_idoperator")]
        public int Tour_idoperator { get; set; }

    }
    }

