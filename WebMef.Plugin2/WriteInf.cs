using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMef.Core;

namespace WebMef.Plugin2
{
    [Export(typeof(IMsg))]
    public class WriteInf : IMsg
    {
        public string InfName => "写作";

        public int InfCode { get ; set; }

        public string Recv(int infcode)
        {
            string msg = "页面为：" + InfName + "  序号为：" + infcode;
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
            string retmsg = msg + "页面为：" + InfName + "  原号为：" + oldinfcode + "  现号为：" + InfCode + " 增加了" + infcode;
            return retmsg;
        }
    }
}
