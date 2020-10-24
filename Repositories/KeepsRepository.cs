using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
      private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT
      k.*,
      p.*
      FROM keeps k
      JOIN profiles p on k.creatorId = p.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT
      k.*,
      p.*
      FROM keeps k
      JOIN profiles p on k.creatorId = p.id
      WHERE k.id = @id";
      
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, new {id}, splitOn: "id").FirstOrDefault();
    }

     internal IEnumerable<Keep> GetKeepsByProfileId(string profileId)
    {
      string sql = @"
      SELECT
      k.*,
      p.*
      FROM keeps k
      JOIN profiles p on k.creatorId = p.id
      WHERE k.creatorId = @profileId";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, new {profileId}, splitOn: "id");
    }

     internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO Keeps
      (creatorId, name, description, img, views, shares, keeps)
      VALUES
      (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();";
    return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal Keep Edit(Keep editKeep)
    {
     string sql = @"
        UPDATE keeps
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
        WHERE id = @Id;";
        _db.Execute(sql, editKeep);
        return editKeep;
    }

     internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new {id});
    }
   
  }
}