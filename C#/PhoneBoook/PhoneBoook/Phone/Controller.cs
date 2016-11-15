using System.Collections.Generic;

namespace PhoneBoook.Phone
{
    public class Controller
    {
        protected List<Command> Commands = new List<Command>();

        public void AddCommand(Command cmd)
        {
            Commands.Add(cmd);
        }

        public void InvokeAll(Book bookObj)
        {
            foreach (var cmd in Commands)
            {
                cmd.Invoke(bookObj);
            }
        }
    }
}
