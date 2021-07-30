using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMef.Core;

namespace WebMefDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MefController : ControllerBase
    {
        [HttpGet("Msg")]
        public string GetMsgs(string name)
        {
            if (name == null) return "找不到对应的组件";

            var msg = MefRegister.Msgs.FirstOrDefault(t => t.InfName == name);

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return msg.Send(now, 1);
        }

    }
}
