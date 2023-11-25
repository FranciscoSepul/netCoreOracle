using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.Common.ICommon
{
    public interface IValidateService
    {
        string GetStatus(bool AuditNotDeleted,DateTime FechaDesde,DateTime FechaHasta,bool RepetirAnualmente);
    }
}
