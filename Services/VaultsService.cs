using keepr.Repositories;

namespace keepr.Services
{
    public class VaultsService
    {
      private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
  }
}