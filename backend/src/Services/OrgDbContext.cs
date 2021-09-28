using Microsoft.EntityFrameworkCore;
using Pz.Cheeseria.Api.Data;
using Pz.Cheeseria.Api.Models;

namespace Pz.Cheeseria.Api.Services
{
    internal class OrgDbContext : IOrgDbContext
    {
        private readonly DbContextOptions<OrgDB> _options;

        public OrgDbContext(DbContextOptions<OrgDB> options)
        {
            _options = options;
        }

        public OrgDB DbContext()
        {
            var context = new OrgDB(_options);
            return context;
        }
    }
}
