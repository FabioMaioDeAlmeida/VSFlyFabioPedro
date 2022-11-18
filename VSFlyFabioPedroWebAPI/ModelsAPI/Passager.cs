using VSFlyFabioPedro.Models;

namespace VSFlyFabioPedroWebAPI.ModelsAPI
{
    public class Passager
    {
        public int PassagerId { get; set; }

        //test converter cacher age
        //public int Age { get; set; }
        public string PassagerPrénom { get; set; }
        public string PassagerNom { get; set; }
        public virtual ICollection<Vol> Vols { get; set; }
    }
}
