using Microsoft.AspNetCore.Mvc;
using amazen_server.Services;
using System.Collections.Generic;
using amazen_server.Models;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _iserv;
        public ItemsController(ItemService iserv)
        {
            _iserv = iserv;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            try
            {
                return Ok(_iserv.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Item>> Create([FromBody] Item newItem)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newItem.CreatorId = userInfo.Id;
                Item created = _iserv.Create(newItem);
                created.Creator = userInfo;
                created.IsAvailable = true;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}