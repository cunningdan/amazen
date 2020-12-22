using System;
using System.Collections.Generic;
using amazen_server.Services;
using amazen_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _ps;
        public ProfileController(ProfileService ps)
        {
            _ps = ps;
        }

    }
}