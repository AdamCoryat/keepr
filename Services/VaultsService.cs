using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
      private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault GetById(Profile userInfo, int id)
    {
      Vault data = _repo.GetById(id);
      if(data.IsPrivate == true && data.CreatorId != userInfo.Id)
      {
        throw new Exception("This Vault is private");
      }
      if(data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
     internal IEnumerable<Vault> GetVaultsByProfileId(string userId, string profileId)
    {
      IEnumerable<Vault> vaults = _repo.GetVaultsByProfileId(profileId);
      return vaults.ToList().FindAll(v => v.CreatorId == userId || !v.IsPrivate);
    }

    internal Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal object Delete(int id, string creatorId)
    {
      Vault data = _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Invalid Id");
      }
      if(data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      _repo.Delete(id);
      return "Successfully Deleted!";
    }

   
  }
}