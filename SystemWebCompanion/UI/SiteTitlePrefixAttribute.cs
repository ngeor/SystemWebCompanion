namespace System.Web.Companion.UI
{
	/// <summary>
	/// Specifies a common title prefix for all pages that use a <see cref="CompanionMasterPage"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Some web applications prefix the title of all of their pages with a common text prefix, usually the name of the app.
	/// For example, if an app is called 'MyApp', it is usual that the home page's title is 'MyApp',
	/// the about page's title is 'MyApp - About', etc.
	/// </para>
	/// <para>
	/// To do this, create a master page inheriting from <see cref="CompanionMasterPage"/> and annotate your master page
	/// with this attribute. All pages using that master page will have their title automatically prefixed.
	/// </para>
	/// </remarks>
	/// <example>
	/// The code of the master page will look like:
	/// <code>
	/// [SiteTitlePrefix("MyApp", " - ")]
	/// public class MasterPage : System.Web.UI.CompanionMasterPage { }
	/// </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class SiteTitlePrefixAttribute : Attribute
	{
		/// <summary>
		/// Creates a new instance of this class.
		/// </summary>
		/// <param name="prefix">The title prefix to use in all pages of a master page</param>
		/// <param name="separator">The text to insert between the <paramref name="prefix"/> and the actual title of the page</param>
		public SiteTitlePrefixAttribute(string prefix, string separator)
		{
			Prefix = prefix;
			Separator = separator;
		}

		/// <summary>
		/// The title prefix to use in every page using a master page annotated with this attribute
		/// </summary>
		public string Prefix { get; set; }

		/// <summary>
		/// The separator to use in order to separate the <see cref="Prefix"/> and the actual title of the page.
		/// </summary>
		public string Separator { get; set; }
	}
}
