using System;

namespace Ecos.Xpo.Identity.Core
{
	public interface IXPOKey<TKey>
			 where TKey : IEquatable<TKey>
	{
		TKey Key { get; }
	}

	public interface IAssignable
	{
		void Assign(object source, int loadingFlags);
	}
}
