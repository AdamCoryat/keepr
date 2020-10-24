using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
      private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal void Create(Profile userInfo, VaultKeep newVaultKeep)
    {
       _repo.Create(newVaultKeep);
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