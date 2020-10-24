using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
    }

    internal Keep GetById(int id)
    {
      Keep data = _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal IEnumerable<Keep> GetKeepsByProfileId(string userId, string profileId)
    {
      IEnumerable<Keep> keeps = _repo.GetKeepsByProfileId(profileId);
      if(keeps == null)
      {
        throw new Exception("Invalid Id");
      }
      return keeps;
    }
    internal IEnumerable<KeepVaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal object Edit(Keep editKeep, string creatorId)
    {
      Keep data = _repo.GetById(editKeep.Id);
      if(data == null)
      {
        throw new Exception("Invalid Id");
      }
      if(data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      editKeep.Name = editKeep.Name == null ? data.Name : editKeep.Name;
      editKeep.Description = editKeep.Description == null ? data.Description : editKeep.Description;
      editKeep.Img = editKeep.Img == null ? data.Img : editKeep.Img;
      return _repo.Edit(editKeep);
    }

    

    internal object Delete(int id, string creatorId)
    {
      Keep data = _repo.GetById(id);
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