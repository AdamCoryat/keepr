using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vRepo;
      private readonly KeepsRepository _kRepo;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vRepo, KeepsRepository kRepo)
    {
      _repo = repo;
      _vRepo = vRepo;
      _kRepo = kRepo;
    }

    internal VaultKeep Create(Profile userInfo, VaultKeep newVaultKeep)
    {
      newVaultKeep.Id = _repo.Create(newVaultKeep);
      Vault vault = _vRepo.GetById(newVaultKeep.VaultId);
      if(vault.CreatorId != userInfo.Id)
      {
        throw new Exception("You do not own this Vault");
      }
      Keep data = _kRepo.GetById(newVaultKeep.KeepId);
      data.Keeps++;
      _kRepo.Edit(data);
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