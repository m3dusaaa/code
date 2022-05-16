    using System;
using System.Collections.Generic;
using WpfApp1.Tools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
        [Table("tour")]
        public class Tour : BaseDTO
        {
            [Column("country")]
            public string Country { get; set; }
            [Column("city")]
            public string City { get; set; }
            [Column("order_num")]
            public int NomerZakaza { get; set; }
            [Column("time")]
            public string Dlitelnost { get; set; }
            [Column("hotel")]
            public string hotel { get; set; }
            [Column("price")]
            public string Price { get; set; }
            [Column("idoperator")]
            public int IDOperator { get; set; }
        [Column("oplata_idclient")]
        public int Oplata_idclient { get; set; }
        [Column("oplata_price")]
        public int Oplata_price { get; set; }
    }
    }

