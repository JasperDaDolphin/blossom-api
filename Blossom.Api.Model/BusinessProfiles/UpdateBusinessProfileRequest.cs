using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Api.Model.BusinessProfiles
{
	public class UpdateBusinessProfileRequest
	{
		public string Name { get; set; }

		public string Website { get; set; }

		public string Size { get; set; }

		public string PhoneNumber { get; set; }

		public string Type { get; set; }

		public string Location { get; set; }
	}
}
