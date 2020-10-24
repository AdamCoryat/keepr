using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

  [HttpGet("{id}")]
  public async Task<ActionResult<IEnumerable<Vault>>> Get(int id)
  {
    try
    {
    Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    return Ok(_vs.GetById(userInfo.Id, id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  } 

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> Post([FromBody] Vault newVault)
  {
   try
   {
     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
     newVault.CreatorId = userInfo.Id;
     Vault created = _vs.Create(newVault);
     created.Creator = userInfo;
     return Ok(created);
   }
   catch (Exception e)
   {
     return BadRequest(e.Message);
   }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Delete(int id)
  {
    try
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      return Ok(_vs.Delete(id, userInfo.Id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  }

}