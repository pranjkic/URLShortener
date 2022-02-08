using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShoretener.Core.Ports.RepositoryInterfaces;
using URLShortener.Core.Model;

namespace URLShortener.Repositories.DBRepository
{
    public class URLRepository : IURLRepository
    {
        public void Test()
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            using (URLShortenerDBEntities context = new URLShortenerDBEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool LinkExist(string link)
        {
            bool exist = false;
            using (URLShortenerDBEntities context = new URLShortenerDBEntities())
            {
                if (context.Links.FirstOrDefault(url => url.Link1 == link) != null)
                    exist = true;
            }
            return exist;
        }

        public void InsertLink(string email, Link link)
        {
            using (URLShortenerDBEntities context = new URLShortenerDBEntities())
            {
                context.Links.Add(link);

                User user = context.Users.FirstOrDefault(u => u.Email == email);
                UserLink userLink = new UserLink() { LinkId = link.Id, UserId = user.Id };

                context.UserLinks.Add(userLink);
                context.SaveChanges();
            }
        }

        public void InsertUserLink(string email, string link)
        {
            using (URLShortenerDBEntities context = new URLShortenerDBEntities())
            {
                try
                {
                    User user = context.Users.FirstOrDefault(u => u.Email == email);
                    Link link1 = context.Links.FirstOrDefault(u => u.Link1 == link);
                    UserLink userLink = new UserLink() { LinkId = link1.Id, UserId = user.Id };

                    context.UserLinks.Add(userLink);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public string RedirectPath(string shortUrl)
        {
            string url = "";
            using (URLShortenerDBEntities context = new URLShortenerDBEntities())
            {
                if (context.Links.Any(u => u.ShortLink == shortUrl))
                {
                    url = context.Links.FirstOrDefault(u => u.ShortLink == shortUrl).Link1;
                }
                else
                    throw new Exception();
            }
            return url;
        }
    }
}
