using System;
using System.Collections.Generic;
using System.Text;
using CommonModel;

namespace SerilogLogger.Interface
{
    public interface IEvenLog
    {
        ErrorCommon Error(string exMessage, string userMesage, string site);
        void Error(string exMessage);
        ErrorCommon Error(string exMessage, string userMesage);
    }
}
