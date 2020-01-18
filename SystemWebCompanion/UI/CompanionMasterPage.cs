using System.Linq;
using System.Web.UI;

namespace System.Web.Companion.UI
{
	/// <summary>
	/// A master page that handles some common web application tasks.
	/// </summary>
	/// <seealso cref="SiteTitlePrefixAttribute"/>
	public class CompanionMasterPage : MasterPage
	{
		/// <summary>
		/// If the master page is annotated with <see cref="SiteTitlePrefixAttribute"/>,
		/// it prefixes the title of the current page accordingly. See <see cref="SiteTitlePrefixAttribute"/>
		/// for more information.
		/// </summary>
		/// <param name="e">The event arguments</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			SiteTitlePrefixAttribute siteTitlePrefixAttribute =
				GetType().GetCustomAttributes(typeof(SiteTitlePrefixAttribute), true)
				.OfType<SiteTitlePrefixAttribute>()
				.FirstOrDefault();

			if (siteTitlePrefixAttribute != null)
			{
				string pageTitle = Page.Title;
				if (string.IsNullOrEmpty(pageTitle))
				{
					Page.Title = siteTitlePrefixAttribute.Prefix;
				}
				else
				{
					Page.Title = siteTitlePrefixAttribute.Prefix +
						siteTitlePrefixAttribute.Separator +
						pageTitle;
				}
			}
		}
	}
}
