using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppService : IAppService
    {
        public string AddUrl(string url)
        {
            return Engine.Instance.AddUrl(url);
        }

        public string VisitUrl(string token)
        {
            return Engine.Instance.VisitUrl(token);
        }
    }
}
