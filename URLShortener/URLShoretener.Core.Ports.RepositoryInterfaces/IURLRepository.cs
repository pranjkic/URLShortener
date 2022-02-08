using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Core.Model;

namespace URLShoretener.Core.Ports.RepositoryInterfaces
{
    public interface IURLRepository
    {
        void Test();
        void Register(User user);
        //void InsertLink(Link newLink);
        bool LinkExist(string link);
        void InsertLink(string email, Link link);
        void InsertUserLink(string email, string link);
        string RedirectPath(string shortUrl);
    }
}
