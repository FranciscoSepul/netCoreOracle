using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.Common.ICommon
{
    public interface ILogService
    {
        void GenerateLogErrorAsync(string ex, string methodName,string systema);
        void GenerateLogAsync(string methodName, string logResponse, string logTransaction,string systema);
    }
}
