using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Content
{
	public class AplicationDbContext: DbContext
	{

		public DbSet<Usuario> Usuario { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
		{

		}
	}
}
