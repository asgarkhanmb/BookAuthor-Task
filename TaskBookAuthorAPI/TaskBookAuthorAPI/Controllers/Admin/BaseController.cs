﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskBookAuthorAPI.Controllers.Admin
{
    [Route("api/admin[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
