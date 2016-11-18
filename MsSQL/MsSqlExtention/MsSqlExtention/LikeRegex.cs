using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

public partial class UserDefinedFunctions
{
    /// <summary>
    /// A simple LIKE that accepts a regex
    /// </summary>
    /// <param name="column"></param>
    /// <param name="regex"></param>
    /// <returns>True or false if there are matches</returns>
    [SqlFunction]
    public static bool LikeRegex(string column, string regex)
    {
        string input = column;
        string pattern = @""+regex+"";
        try
        {
            var rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = rgx.Matches(input);            
            if (matches.Count > 0)
            {
                return true;
            }
        }
        catch
        {
        }        
        return false;
    }
}
