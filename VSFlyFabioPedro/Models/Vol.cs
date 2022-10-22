using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFlyFabioPedro.Models
{
    public class Vol
    {
        public int VolId { get; set; } 
        public int CompagnieID { get; set; }
        public double VolPrix { get; set; }
        public DateTime DépartHeureVol { get; set; }
        public string DépartLieuVol { get; set; }
        public string DestinationVol { get; set; }  
        public int PlaceDisponibleVol { get; set; }
        public virtual ICollection<Réservation> Réservations { get; set; }
    }
}
