using log4net;

namespace System.Web.Companion
{
	/// <summary>
	/// Offers extension methods for the <see cref="HttpContext"/> class.
	/// </summary>
	public static class HttpContextExtensions
	{
		/// <summary>
		/// Using log4net, it logs the latest exception.
		/// </summary>
		/// <param name="context">This Http Context</param>
		/// <remarks>The latest exception is taken from <see cref="HttpContext.Error"/></remarks>
		public static void LogException(this HttpContext context)
		{
			for (Exception ex = context.Error; ex != null; ex = ex.InnerException)
			{
				LogManager.GetLogger(context.GetType()).Error(ex.Message, ex);
			}
		}
	}
}
