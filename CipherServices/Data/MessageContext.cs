using Microsoft.EntityFrameworkCore;

namespace CipherServices.Data
{
	public class MessageContext : DbContext
	{
		public MessageContext(DbContextOptions<MessageContext> options) : base(options)
		{
			DbInitializer.Initialize(context: this);
		}
		public DbSet<Models.Message> Messages { get; set; }
	}
}
