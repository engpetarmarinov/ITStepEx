using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBoook
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the contacts
            var parserPhone = new Phone.Parser(new IO.File("../../phone.txt"));
            var book = parserPhone.ParseBook();
            book = book;

            var parserCommands = new Phone.Parser(new IO.File("../../commands.txt"));
            var controller = parserCommands.ParseCommands();
            controller.InvokeAll(book);
        }
    }
}
