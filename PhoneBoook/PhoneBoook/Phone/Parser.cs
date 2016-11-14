using System;
using System.Text.RegularExpressions;
using PhoneBoook.IO;
namespace PhoneBoook.Phone
{
    public class Parser
    {
        protected File MyFile;

        public Parser(File file)
        {
            MyFile = file;
        }

        public Book ParseBook()
        {
            string line;
            var book = new Book();
            while ((line = MyFile.ReadLine()) != null)
            {
                var contact = ParseLine(line);
                book.Add(contact);
            }
            return book;
        }

        public Contact ParseLine(string line)
        {
            var columns = line.Split('|');
            //name, city, phone
            return new Contact(columns[0]?.Trim(), columns[1]?.Trim(), columns[2]?.Trim());
        }


        public Controller ParseCommands()
        {
            string line;
            var ctrl = new Controller();
            while ((line = MyFile.ReadLine()) != null)
            {
                var cmd = ParseCommandLine(line);
                ctrl.AddCommand(cmd);
            }
            return ctrl;
        }

        public Command ParseCommandLine(string line)
        {
            line = line.Trim();
            var func = Regex.Match(line, @"(\b[^()]+)\((.*)\)$");

            // Get function name
            var funcName = func.Groups[1].Value;
            var innerArgs = func.Groups[2].Value;
            // Get parameters
            var paramTags = Regex.Matches(innerArgs, @"([^,]+\(.+?\))|([^,]+)");
            var parameters = new string[paramTags.Count];
            for (var i = 0; i < paramTags.Count; i++)
            {
                parameters[i] = paramTags[i].Value.Trim(new [] { '"', ' ' } );
            }

            var cmdType = Command.Mapper[funcName];

            var cmd = new Command(cmdType, parameters);
            return cmd;
        }
    }
}