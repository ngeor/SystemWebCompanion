using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace System.Web.Companion.UI.WebControls
{
	/// <summary>
	/// Renders the Google Analytics javascript code.
	/// </summary>
	[DefaultProperty("SiteId")]
	[ToolboxData("<{0}:GoogleAnalytics runat=server></{0}:GoogleAnalytics>")]
	public class GoogleAnalytics : WebControl
	{
		private const string SyncCode = @"
<!-- begin Google Analytics -->
<script type=""text/javascript"">
	var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
	document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
</script>

<script type=""text/javascript"">
	try {
		var pageTracker = _gat._getTracker(""SITEID"");
		pageTracker._trackPageview();
	} catch (err) { }</script>
<!-- end Google Analytics -->
";

		private const string AsyncCode = @"<script type=""text/javascript"">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'SITEID']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
";

		/// <summary>
		/// The id of the site in Google Analytics.
		/// </summary>
		[DefaultValue("")]
		public string SiteId
		{
			get;
			set;
		}

		/// <summary>
		/// Determines if the Google Analytics script should be rendered for local requests.
		/// </summary>
		[DefaultValue(false)]
		public bool ShowOnLocalhost
		{
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether the asynchronous script code should be used or not.
		/// </summary>
		[DefaultValue(false)]
		public bool UseAsyncScript 
		{
			get;
			set;
		}

		/// <summary>
		/// Renders the Google Analytics script.
		/// </summary>
		/// <param name="writer">The writer to use for rendering.</param>
		protected override void Render(HtmlTextWriter writer)
		{
			if ((ShowOnLocalhost || !IsLocalhost()) && !string.IsNullOrEmpty(SiteId))
			{
				string fmt = UseAsyncScript ? AsyncCode : SyncCode;
				writer.Write(fmt.Replace("SITEID", SiteId));
			}
		}

		private bool IsLocalhost()
		{
			string host = Page.Request.Url.Host;
			return Page.Request.IsLocal || host == "localhost" || host == "127.0.0.1";
		}
	}
}
