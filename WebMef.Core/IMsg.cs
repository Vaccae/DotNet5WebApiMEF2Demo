using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMef.Core
{
    public interface IMsg
    {
        string InfName { get; }

        int InfCode { get; set; }

        void Send(string msg);

        string Send(string msg, int infcode);

        string Recv(int infcode);
    }
}
