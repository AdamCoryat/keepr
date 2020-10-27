using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vRepo;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vRepo)
    {
      _repo = repo;
      _vRepo = vRepo;
    }

    internal VaultKeep Create(Profile userInfo, VaultKeep newVaultKeep)
    {
      newVaultKeep.Id = _repo.Create(newVaultKeep);
      Vault vault = _vRepo.GetById(newVaultKeep.VaultId);
      if(vault.CreatorId != userInfo.Id)
      {
        throw new Exception("You do not own this Vault");
      }
      return newVaultKeep;
    }

    internal object Delete(int id, Profile userInfo)
    {
      VaultKeep data = _repo.GetById(id);
      if(data.CreatorId != userInfo.Id || data == null)
      {
        throw new Exception("Invalid Id, Or Invalid Permissions");
      }
      _repo.Delete(id);
      return "Successfully Deleted!";
    }
  }
}