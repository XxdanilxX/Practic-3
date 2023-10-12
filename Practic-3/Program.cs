using System.Xml.Serialization;
namespace Practic_3
{
    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Person person = new Person();
                Console.WriteLine("Name:");
                person.Name = Console.ReadLine();
                Console.WriteLine("SurName:");
                person.SurName = Console.ReadLine();
                Console.WriteLine("Age:");
                person.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(new string('=', 40));
                SerializeToXml(person, "Person.xml");
                Person newperson1 = DeserializeFromXml("Person.xml");
                Console.WriteLine("/nXML:");
                Console.WriteLine($"Name: {newperson1.Name}");
                Console.WriteLine($"SurName: {newperson1.SurName}");
                Console.WriteLine($"Age: {newperson1.Age}");
                Console.WriteLine(new string('=', 40));
            }
            catch
            {

            }
        }
        static void SerializeToXml(Person person, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, person);
            }
        }
        static Person DeserializeFromXml(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return (Person)serializer.Deserialize(stream);
            }
        }
    }
}