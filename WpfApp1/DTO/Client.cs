using System;
using System.Collections.Generic;
using WpfApp1.Tools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
    [Table("client")]
    public class Client : BaseDTO
    {
        [Column("idclient")]
        public int IDClient { get; set; }
        [Column("clientFIO")]
        public string FIO { get; set; }
        [Column("clientbirthday")]
        public DateTime Birthday { get; set; }
        [Column("idoperator")]
        public int OperatorId { get; set; }
        [Column("oplata_idclient")]
        public int Oplata_idclient { get; set; }
    }
}



