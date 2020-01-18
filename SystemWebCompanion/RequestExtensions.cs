namespace System.Web.Companion
{
	/// <summary>
	/// Offers extension methods for the <see cref="HttpRequest"/> class.
	/// </summary>
	public static class RequestExtensions
	{
		/// <summary>
		/// Returns the Application Path (<see cref="HttpRequest.ApplicationPath"/>).
		/// The resulting value will always end with a slash (/).
		/// </summary>
		/// <param name="request">This Http Request</param>
		/// <returns>The Application Path of the given Http Request object</returns>
		/// <example>
		/// <para>if the current application is the the web site root, the result will be '/'.</para>
		/// <para>if the current application is a web app under a web site, the result will something like '/app/'.</para>
		/// </example>
		public static string SlashedAppPath(this HttpRequest request)
		{
			string appPath = request.ApplicationPath;
			if (!appPath.EndsWith("/"))
			{
				appPath += "/";
			}

			return appPath;
		}

		/// <summary>
		/// Returns an absolute URL pointing to the root of the current application.
		/// The URL will always end with a slash (/).
		/// </summary>
		/// <param name="request">This Http Request object</param>
		/// <returns>The absolute URL of the root of the current application</returns>
		/// <remarks>
		/// The method reconstructs the application URL using the properties of the
		/// <see cref="HttpRequest.Url"/> object and appends the application path
		/// returned by the <see cref="SlashedAppPath"/> method.
		/// </remarks>
		public static string AbsoluteAppPath(this HttpRequest request)
		{
			string result = request.Url.Scheme + "://" + request.Url.Host;
			if (!request.Url.IsDefaultPort)
			{
				result += ":" + request.Url.Port;
			}

			return result + request.SlashedAppPath();
		}
	}
}
