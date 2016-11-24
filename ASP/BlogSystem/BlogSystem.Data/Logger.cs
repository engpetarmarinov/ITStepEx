using System.Web;

namespace BlogSystem.Data
{
    public class Logger
    {
        // Log connection info and queries into the web console
        public static void Log(string text)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Write("<script>console.log(`" + text + "`);</script>");
            }
        }
    }
}