namespace Ecos.Xpo.Identity
{
	public static class DxIdentityUserFlags
	{
		public const int FLAG_ROLES = 1;
		public const int FLAG_CLAIMS = 2;
		public const int FLAG_LOGINS = 4;
		public const int FLAG_USERS = 8;
		public const int FLAG_FULL = 254;
	}

	public static class DxIdentityRoleFlags
	{
		//public const int FLAG_ROLES = 1;
		//public const int FLAG_CLAIMS = 2;
		//public const int FLAG_LOGINS = 4;
		public const int FLAG_USERS = 8;
		public const int FLAG_FULL = 254;
	}

}
