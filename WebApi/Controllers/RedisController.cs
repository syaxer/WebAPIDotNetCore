using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : Controller
    {
        RedisConnection obj = new RedisConnection();
        public string GetString()
        {
            string strValue = "";
            //Creating Redis database instance  
            IDatabase db = obj.Connection.GetDatabase();

            //Getting value of "datetime" key  
            strValue = db.StringGet("strValue");

            //If key not found in Redis database  
            if (strValue == null)
            {
                strValue = "Hello World";

                //Setting value for key with Expiry time of 5 Minutes  
                db.StringSet("strValue", strValue);
            }
            return strValue;
        }
    }
}
