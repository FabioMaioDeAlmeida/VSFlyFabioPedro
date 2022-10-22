using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFlyFabioPedro.Models
{
    public class Compagnie
    {
        public int CompagnieId { get; set; }
        public string CompagnieNom { get; set; }
        public virtual ICollection<Vol> Vols { get; set; }
    }
}
