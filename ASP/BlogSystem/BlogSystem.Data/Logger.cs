using System.Web;

namespace BlogSystem.Data
{
    public class Logger
    {
        public static void Log(string text)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Write("<script>console.log(`" + text + "`);</script>");
            }
        }
    }
}