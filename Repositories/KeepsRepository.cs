using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;

namespace keepr.Repositories
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
      throw new NotImplementedException();
    }

    internal Keep GetById(int id)
    {
      throw new NotImplementedException();
    }
     internal int Create(Keep newKeep)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Keep editKeep)
    {
      throw new NotImplementedException();
    }
  }
}