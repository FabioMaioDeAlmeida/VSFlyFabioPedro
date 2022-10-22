using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFlyFabioPedro.Models
{
    public class Réservation
    {
        public int RéservationId { get; set; }
        public int RéservationPrix { get; set; }
        public virtual Vol Vol { get; set; }
        public virtual Passager Passager { get; set; }  
    }
}
