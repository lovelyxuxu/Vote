using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFPowerVote.Services;
using EFPowerVote.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EFPowerVote.Controllers
{
    [Route("api")]
    [EnableCors("all")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IOperation _operation;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IOperation operation, IHttpContextAccessor httpContextAccessor)
        {
            _operation = operation;
            _httpContextAccessor = httpContextAccessor;
        }

        #region 通过OpenId获取User  /api/user   get
        /// <summary>
        /// 通过OpenId获取User
        /// </summary>
        /// <returns>返回用户的部分信息</returns>
        [HttpGet]
        [Route("user")]
        public IActionResult GetUser()
        {
            string openid = null;
            string jsonstr = _httpContextAccessor.HttpContext.Request.Headers["X-Local-Userid"].ToString();
            if (!string.IsNullOrWhiteSpace(jsonstr))
            {
                openid = ((JObject)JsonConvert.DeserializeObject(jsonstr))["openid"].ToString();
            }
            if (string.IsNullOrEmpty(openid))
            {
                return Ok(new
                {
                    success = false,
                    msg = "openid为空"
                });
            }
            return Ok(new
            {
                data = _operation.GetUser(openid),
                success = true
            });
        }
        #endregion

        #region 投票 /api/vote  post
        /// <summary>
        /// 投票  每个人只有一个记录 投票会先看看投过没。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("vote")]
        public IActionResult PostVote([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return Ok(new
                {
                    success = false,
                    msg = "没有传递投票信息参数"
                });
            }
            string openid = null;
            string jsonstr = _httpContextAccessor.HttpContext.Request.Headers["X-Local-Userid"].ToString();
            if (!string.IsNullOrWhiteSpace(jsonstr))
            {
                openid = ((JObject)JsonConvert.DeserializeObject(jsonstr))["openid"].ToString();
            }
            if (string.IsNullOrEmpty(openid))
            {
                return Ok(new
                {
                    success = false,
                    msg = "openid为空"
                });
            }
            return Ok(new
            {
                success = true,
                data = _operation.SetVote(openid, ticket)
            }) ;
        }
        #endregion

        #region 获取投票信息 /api/vote  get
        /// <summary>
        /// 返回库中软实力硬实力的票数 
        /// </summary>
        /// <returns>返回成一个数组 ["软实力（0）","硬实力（1）"]</returns>
        [HttpGet]
        [Route("vote")]
        public IActionResult GetVote()
        {
            return Ok(new {
                success=true,
                data= _operation.GetVote()
            });
        }
        #endregion

    }
}
