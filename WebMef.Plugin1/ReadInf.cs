using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMef.Core;

namespace WebMef.Plugin1
{
    [Export(typeof(IMsg))]
    public class ReadInf : IMsg
    {
        public string InfName { get=> "阅读"; }
        public int InfCode { get ; set; }

        public string Recv(int infcode)
        {
            string msg = "当前页面为：" + InfName + "  序号为：" + infcode;
            return msg;
        }

        public void Send(string msg)
        {
            InfCode++;
        }

        public string Send(string msg, int infcode)
        {
            int oldinfcode = InfCode;
            InfCode += infcode;
            string retmsg = "当前页面为：" + InfName + "  原序号为：" + oldinfcode + "  现序号为：" + InfCode + " 增加了" + infcode;
            return retmsg;
        }
    }
}
