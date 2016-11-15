namespace XmlExample
{
    public class StudentFactory
    {
        private static int id;

        public static Student Create()
        {
            var newId = GenerateNextId();
            return new Student() { Name = "Name " + newId, Id = newId };
        }

        private static int GenerateNextId()
        {
            id++;
            return id;
        }
    }
}