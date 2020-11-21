using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sistema.Las.Infra.Contextos
{
    public class IdentityContexto : IdentityDbContext
    {
        public IdentityContexto(DbContextOptions<IdentityContexto> options) : base(options) { }
    }
}
