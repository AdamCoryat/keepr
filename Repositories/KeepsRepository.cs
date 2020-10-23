using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
      private readonly IDbConnection _db;

      private readonly string populateCreator = @"
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile on keep.creatorId = profile.id";

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = populateCreator + "WHERE keep.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id").FirstOrDefault();
    }

     internal IEnumerable<Keep> GetByProfileId(string profileId)
    {
      string sql = populateCreator + "WHERE creatorId = @queryProfileId";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id");
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