using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShoretener.Core.Ports.RepositoryInterfaces;
using URLShortener.Core.Model;
using URLShortener.Core.Ports.ServiceInterfaces;

namespace URLShortener.Core.ServiceAdapters.Services
{
    public class URLService : IURLService
    {
        private readonly IURLRepository _urlRepository;

        public URLService(IURLRepository uRLRepository)
        {
            _urlRepository = uRLRepository;
        }

        public void Test()
        {
            _urlRepository.Test();
        }

        public void Register(string email)
        {
            User newUser = new User() { Email = email };
            _urlRepository.Register(newUser);
        }

        public void InsertLink(string email, string link, string shortLink)
        {
            bool exist = _urlRepository.LinkExist(link);
            if(!exist)
            {
                Link newLink = new Link() { Link1 = link, ShortLink = shortLink };
                _urlRepository.InsertLink(email, newLink);
            }
            else
            {
                _urlRepository.InsertUserLink(email, link);
            }
        }

        public string RedirectPath(string shortUrl)
        {
            return _urlRepository.RedirectPath(shortUrl);
        }
    }
}
