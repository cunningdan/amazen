using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;
using amazen_server.Services;
using amazen_server.Models;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _ps;
        private readonly WishlistService _ws;
        public ProfileController(ProfileService ps, WishlistService ws)
        {
            _ws = ws;
            _ps = ps;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Profile>>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{creatorId}/wishlists")]
        [Authorize]
        public ActionResult<IEnumerable<Wishlist>> GetByProfile(string creatorId)
        {
            try
            {
                return Ok(_ws.GetByProfile(creatorId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}