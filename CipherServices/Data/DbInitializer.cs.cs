using System;
using System.Linq;
using CipherServices.Models;

namespace CipherServices.Data
{
	public class DbInitializer
	{
		public static void Initialize(MessageContext context)
		{
			context.Database.EnsureCreated();

			// Look for any messages
			if (context.Messages.Any())
			{
				return; // DB has been seeded
			}

			var Messages = new Message[]
			{
				new Message { Text="dwwdfn" }, // attack
                new Message { Text="khoor" },  // hello
                new Message { Text="flwlchq" },  // citizen
            };

			foreach (Message m in Messages)
			{
				context.Messages.Add(m);
			}

			context.SaveChanges();
		}
	}
}
