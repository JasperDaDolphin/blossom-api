using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Api.Model.Authentication
{
	public class Policies
	{
		#region Policies

		#region User
		public const string CreateUser = "create:user";

		public const string ReadUser = "read:user";

		public const string ReadUserAll = "read:userall";

		public const string UpdateUser = "update:user";

		public const string UpdateUserAll = "update:userall";

		public const string DeleteUser = "delete:user";
		#endregion

		#region Business
		public const string CreateBusiness = "create:business";

		public const string ReadBusiness = "read:business";

		public const string ReadBusinessAll = "read:businessall";

		public const string UpdateBusiness = "update:business";

		public const string UpdateBusinessAll = "update:businessall";

		public const string DeleteBusiness = "delete:business";
		#endregion

		#region Student
		public const string CreateStudent = "create:student";

		public const string ReadStudent = "read:student";

		public const string ReadStudentAll = "read:studentall";

		public const string UpdateStudent = "update:student";

		public const string UpdateStudentAll = "update:studentall";

		public const string DeleteStudent = "delete:student";
		#endregion

		#endregion

		#region List

		static List<string> list;

		public static List<string> All
		{
			get
			{
				if (list == null)
				{
					list = typeof(Policies)
						.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
						.Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
						.Select(x => (string)x.GetRawConstantValue())
						.ToList();
				}
				return list;
			}
		}

		#endregion
	}
}
