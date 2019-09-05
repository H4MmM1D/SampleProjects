using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LinkBusiness
    {
        public string AddUrl(AppDbContext context, string url)
        {
            var newLink = new Link()
            {
                Id = 0,
                NOVisit = 0,
                OriginalUrl = url,
                Token = Guid.NewGuid()
            };

            context.Links.Add(newLink);
            context.SaveChanges();

            return newLink.Token.ToString();

        }

        public string VisitUrl(AppDbContext context, string token)
        {
            var link = context.Links.FirstOrDefault(x => x.Token.ToString() == token);

            if (link == null)
            {
                return string.Empty;
            }

            context.Links.Attach(link);
            link.NOVisit++;
            context.SaveChanges();

            return link.OriginalUrl;
        }
    }
}
