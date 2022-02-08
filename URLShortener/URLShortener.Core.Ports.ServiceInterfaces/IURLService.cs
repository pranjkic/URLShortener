using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Core.Ports.ServiceInterfaces
{
    public interface IURLService
    {
        void Test();
        void Register(string email);
        void InsertLink(string email, string link, string shortLink);
        string RedirectPath(string shortUrl);
    }
}
