using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Engine
    {
        private static readonly Lazy<Engine> _instance = new Lazy<Engine>(() => new Engine());

        private readonly Lazy<LinkBusiness> _linkBusiness = new Lazy<LinkBusiness>();

        private Engine()
        {
        }

        public static Engine Instance
        {
            get { return _instance.Value; }
        }

        public string AddUrl(string url)
        {
            using (var cnx = new AppDbContext())
            {
                return _linkBusiness.Value.AddUrl(cnx, url);
            }
        }

        public string VisitUrl(string token)
        {
            using (var cnx = new AppDbContext())
            {
                return _linkBusiness.Value.VisitUrl(cnx, token);
            }
        }
    }
}
