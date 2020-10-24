using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
      private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT
      v.*,
      p.*
      FROM vaults v
      JOIN profiles p on v.creatorId = p.id
      WHERE v.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {vault.Creator = profile; return vault;}, new {id}, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Vault newVault)
    {
      string sql = @"
      INSERT into vaults
      (creatorId, name, description, isPrivate)
      VALUES
      (@CreatorId, @Name, @Description, @isPrivate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal IEnumerable<Vault> GetVaultsByProfileId(string profileId)
    {
      string sql = @"
      SELECT
      v.*,
      p.*
      FROM vaults v
      JOIN profiles p on v.creatorId = p.id
      WHERE v.creatorId = @profileId";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {vault.Creator = profile; return vault;}, new {profileId}, splitOn: "id");
      
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new {id});
    }
  }
}