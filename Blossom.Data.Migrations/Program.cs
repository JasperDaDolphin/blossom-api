using Microsoft.EntityFrameworkCore;
using Blossom.Data.Model;

namespace Blossom.Data.Migrations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var bcf = new BlossomContextFactory();
			var a = bcf.CreateDbContext(args);
			a.Database.Migrate();
		}
	}
}
