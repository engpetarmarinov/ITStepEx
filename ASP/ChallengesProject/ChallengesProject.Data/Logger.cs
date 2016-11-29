using System.Net.Http;
using System.Web;

namespace ChallengesProject.Data
{
    public class DebugLogger : ILogger
    {
        // Log connection info and queries into the web console
        public void Log(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}