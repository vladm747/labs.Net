using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            #region initialise
            List<Employee> employees = new List<Employee>()
            {
                new Employee(0, "Makogonenko Olexandr", "Middle Angular"),
                new Employee(1, "Pishchuk Maxym", "Senior C#"),
                new Employee(2, "Dukhovny Daniel", "Senior C#"),
                new Employee(3, "Moroz Vladyslav", "Junior C#"),
                new Employee(4, "Vyshnepolskiy Tima", "Junior QA")
            };
            List<Employee> emp1 = new List<Employee>();
            emp1.Add(employees[2]);
            emp1.Add(employees[1]);
            emp1.Add(employees[4]);

            List<Employee> emp2 = new List<Employee>();
            emp2.Add(employees[0]);
            emp2.Add(employees[1]);
            emp2.Add(employees[3]);
            emp2.Add(employees[4]);


            List<Employee> emp3 = new List<Employee>();
            emp3.Add(employees[2]);
            emp3.Add(employees[3]);
            emp3.Add(employees[4]);

            List<Project> projects = new List<Project>()
            {
                new Project(0, "Forum", 450, DateTime.Now, DateTime.Now.AddDays(21), emp1),
                new Project(1, "Knowledge Accounting System", 300, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(13), emp2),
                new Project(2, "File Storage", 277, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(22), emp3)
            };

            foreach (var emp in emp1)
            {
                emp.Projects.Add(projects[0]);
            }
            foreach (var emp in emp2)
            {
                emp.Projects.Add(projects[1]);
            }
            foreach (var emp in emp3)
            {
                emp.Projects.Add(projects[2]);
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("employees.xml", settings))
            {
                writer.WriteStartElement("employees");

                foreach (Employee emp in employees)
                {
                    writer.WriteStartElement("employee");
                    writer.WriteElementString("personId", emp.PersonId.ToString());
                    writer.WriteElementString("personName", emp.PersonName);
                    writer.WriteElementString("position", emp.Position);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("employees.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                int personId = Int32.Parse(node["personId"].InnerText);
                string personName = node["personName"].InnerText;
                string position = node["position"].InnerText;

                Console.WriteLine(string.Format("Користувач={0}, на ім'я {1}, позиція: {2}", personId, personName, position));
            }
            // XDocument, XElement
            Console.WriteLine();
            XDocument xmlDoc = XDocument.Load("employees.xml");
            foreach (XElement userElement in
            xmlDoc.Element("employees").Elements("employee"))
            {
                XElement personIdAttribute = userElement.Element("personId");
                XElement personNameElement = userElement.Element("personName");
                XElement positionElement = userElement.Element("position");
                if (personIdAttribute != null && personNameElement != null && positionElement != null)
                {
                    Console.WriteLine("Користувач: {0}", personIdAttribute.Value);
                    Console.WriteLine("Ім'я: {0}", personNameElement.Value);
                    Console.WriteLine("Позиція: {0}", positionElement.Value);
                }
                Console.WriteLine();
            }

            using (XmlWriter writer = XmlWriter.Create("projects.xml", settings))
            {
                writer.WriteStartElement("projects");

                foreach (Project proj in projects)
                {
                    writer.WriteStartElement("project");
                    writer.WriteElementString("projectId", proj.ProjectId.ToString());
                    writer.WriteElementString("projectName", proj.ProjectName);
                    writer.WriteElementString("cost", proj.Cost.ToString());
                    writer.WriteElementString("start", proj.Start.ToShortDateString());
                    writer.WriteElementString("finish", proj.Finish.ToShortDateString());
                    writer.WriteElementString("employees", proj.Employees.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("projects.xml");
            foreach (XmlNode node in doc1.DocumentElement)
            {
                int projectId = Int32.Parse(node["projectId"].InnerText);
                string projectName = node["projectName"].InnerText;
                decimal cost = Decimal.Parse(node["cost"].InnerText);
                DateTime start = DateTime.Parse(node["start"].InnerText);
                DateTime finish = DateTime.Parse(node["finish"].InnerText);

                Console.WriteLine(string.Format("Проект={0}, назва: {1}, ціна: {2}, початок: {3}, кінець: {4}", projectId, projectName, cost, start, finish));
            }
            // XDocument, XElement
            Console.WriteLine();
            XDocument xmlDoc1 = XDocument.Load("projects.xml");
            foreach (XElement userElement in xmlDoc1.Element("projects").Elements("project"))
            {
                XElement projectIdAttribute = userElement.Element("projectId");
                XElement projectNameElement = userElement.Element("projectName");
                XElement costElement = userElement.Element("cost");
                XElement startElement = userElement.Element("start");
                XElement finishElement = userElement.Element("finish");
                if (projectIdAttribute != null && projectNameElement != null && costElement != null && startElement != null && finishElement != null)
                {
                    Console.WriteLine("Проект: {0}", projectIdAttribute.Value);
                    Console.WriteLine("Назва: {0}", projectNameElement.Value);
                    Console.WriteLine("Ціна: {0}", costElement.Value);
                    Console.WriteLine("Початок: {0}", startElement.Value);
                    Console.WriteLine("Закінчення: {0}", finishElement.Value);
                }
                Console.WriteLine();
            }

            #endregion

            var projectNames = xmlDoc1.Descendants("project").Select(x => x.Element("projectName").Value).ToList();
            Console.WriteLine("List of project names:");
            foreach (var projectName in projectNames)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();

            var FprojectNames = xmlDoc1.Descendants("project").Where(y => y.Element("projectName").Value.StartsWith("F")).Select(x => x.Element("projectName").Value).ToList();
            Console.WriteLine("Output all project names that starts with 'F':");
            foreach (var projectName in FprojectNames)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();

            var prByDate = xmlDoc1.Descendants("project").Where(y => Convert.ToDateTime(y.Element("start").Value) <= DateTime.Now.AddDays(-1)).Select(x => x.Element("projectName").Value + " " + x.Element("start").Value).ToList();
            Console.WriteLine("Output projects that started earlier than 24/06/2022: ");
            foreach (var projectName in prByDate)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();


            Console.WriteLine("Output projects in ascending order of  the finish date : ");
            var prByDateAsc= xmlDoc1.Descendants("project")
                .OrderBy(x => Convert.ToDateTime(x.Element("finish").Value))
                .Select(x => x.Element("projectName").Value + " " + x.Element("finish").Value)
                .ToList();
            foreach (var projectName in prByDateAsc)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();

            Console.WriteLine("Group employees by their positions");
            var groupByQuery = xmlDoc.Descendants("employee").GroupBy(x => x.Element("position").Value);
            foreach (var x in groupByQuery)
            {
                Console.WriteLine(x.Key);
                foreach (var item in x)
                {
                    Console.WriteLine(item.Element("personName").Value);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Output projects in descending order of the start date: ");
            
            var prByDateDesc = xmlDoc1.Descendants("project")
                .OrderByDescending(x => Convert.ToDateTime(x.Element("start").Value))
                .Select(x => x.Element("projectName").Value + " " + x.Element("start").Value)
                .ToList();
            foreach (var projectName in prByDateDesc)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();


            Console.WriteLine("Output projects in descending order of the start date: ");

            var prByDateDescStrong = xmlDoc.Descendants("employee")
                .OrderByDescending(x => x.Element("personName").Value)
                .Select(x => x.Element("personName").Value)
                .ToList();
            foreach (var projectName in prByDateDescStrong)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();

            Console.WriteLine("Output all project names that doesn`t have any 'F' in the name: ");
            var oneMoreStrongQuery = xmlDoc1.Descendants("project")
                .Where(x => !x.Element("projectName").Value
                .Contains("F"))
                .Select(y=>y.Element("projectName").Value)
                .ToList();
            foreach (var projectName in oneMoreStrongQuery)
            {
                Console.WriteLine(projectName);
            }
            Console.WriteLine();

            Console.WriteLine("Show projects that cost more than 300 or equal");
            var queryByCost = xmlDoc1.Descendants("project").Where(x => Convert.ToDecimal(x.Element("cost").Value) >= 300).Select(p => p.Element("projectName").Value + "-" + p.Element("cost").Value);
            foreach (var x in queryByCost)
                Console.WriteLine(x);
            Console.WriteLine();


            Console.WriteLine("Show projects and their start and finish date: ");
            var queryDates = xmlDoc1.Descendants("project").Select(x => x.Element("projectName").Value + ": " + x.Element("start").Value + "-" + x.Element("finish").Value);
            foreach (var x in queryDates)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Output employees that don`t have 'senior' position");
            var notSeniors = xmlDoc.Descendants("employee").Where(emp => !emp.Element("position").Value.Contains("Senior")).Select(e => e.Element("personName").Value + "-" + e.Element("position").Value);
            foreach (var x in notSeniors)
                Console.WriteLine(x);
            Console.WriteLine();
        }
    }
}
