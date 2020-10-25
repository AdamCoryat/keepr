using System;
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
    [Authorize]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVaultKeep.CreatorId = userInfo.Id;
        return Ok(_vks.Create(userInfo, newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vks.Delete(id, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}