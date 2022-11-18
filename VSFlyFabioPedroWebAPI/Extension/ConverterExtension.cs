using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VSFlyFabioPedroWebAPI.Extension
{
    
    public static class ConverterExtension
    {
        public static ModelsAPI.Passager ConvertToPassagerM(this VSFlyFabioPedro.Models.Passager passager)
        {
            ModelsAPI.Passager passagerM = new ModelsAPI.Passager();
            passagerM.PassagerPrénom = passager.PassagerPrénom;
            passagerM.PassagerNom = passager.PassagerNom;
            passagerM.Vols = passager.Vols;
            passagerM.PassagerId = passager.PassagerId;
            return passagerM;
        }

        public static VSFlyFabioPedro.Models.Passager ConvertToPassager(this VSFlyFabioPedroWebAPI.ModelsAPI.Passager passager)
        {
            VSFlyFabioPedro.Models.Passager passagerM = new VSFlyFabioPedro.Models.Passager();
            passagerM.Vols = passager.Vols;
            passagerM.PassagerPrénom = passager.PassagerPrénom;
            passagerM.PassagerNom = passager.PassagerNom;
            passagerM.PassagerId = passager.PassagerId;
            return passagerM;
        }
    }
    
}
