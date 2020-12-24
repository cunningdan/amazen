using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistsController : ControllerBase
    {
        private readonly WishlistService _ws;
        public WishlistsController(WishlistService ws)
        {
            _ws = ws;
        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Wishlist> GetById(int id)
        {
            try 
            {
                return Ok(_ws.GetById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Wishlist>> Create([FromBody] Wishlist newWishlist)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newWishlist.CreatorId = userInfo.Id;
                Wishlist created = _ws.Create(newWishlist);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}