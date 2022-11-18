namespace VSFlyFabioPedroWebApp.Services
{
    public interface IVSFlyFabioPedroServices
    {
        public Task<IEnumerable<VSFlyFabioPedroWebApp.Models.Passager>> GetPassagers();

    }
}
