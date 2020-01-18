namespace System.Web.Companion
{
	/// <summary>
	/// Offers extension methods for the <see cref="HttpApplication"/> class.
	/// </summary>
	public static class HttpApplicationExtensions
	{
		/// <summary>
		/// Using log4net, it logs the latest exception.
		/// </summary>
		/// <param name="application">This application</param>
		/// <remarks>The latest exception is taken from <see cref="HttpContext.Error"/></remarks>
		public static void LogException(this HttpApplication application)
		{
			if (application.Context != null)
			{
				application.Context.LogException();
			}
		}
	}
}
