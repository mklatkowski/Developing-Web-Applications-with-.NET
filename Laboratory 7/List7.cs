using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lab07
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }

        public Topic(int topicId, string name)
        {
            TopicId = topicId;
            Name = name;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<int> TopicIds { get; set; }

        public Student(int id, int index, string name, Gender gender, bool active, int departmentId, List<int> topicIds)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.TopicIds = topicIds;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in TopicIds)
                result += str + ", ";
            return result;
        }
    }

    public static class TopicGenerator
    {
        public static List<Topic> GenerateTopics()
        {
            return new List<Topic>
        {
            new Topic(1, "web programming"),
            new Topic(2, "C#"),
            new Topic(3, "PHP"),
            new Topic(4, "algorithms"),
            new Topic(5, "C++"),
            new Topic(6, "fuzzy logic"),
            new Topic(7, "Basic"),
            new Topic(8, "Java"),
            new Topic(9, "JavaScript"),
            new Topic(10, "neural networks")
        };
        }
    }


    class ExampleEx04
    {
        public void printNTimes(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Hello");
            }
        }

        public int addNumbers(int a, int b)
        {
            return a + b;
        }
    }
    internal class List7
    {

        static void ex01(int size)
        {
            Generator.GenerateStudentsWithTopicsEasy()
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Index)
                .Select((student, index) => (student, index ))
                .GroupBy(x => x.index / size)
                .ToList()
                .ForEach(group => {
                    Console.WriteLine("Grupa:");
                    group.Select(x => x.student)
                        .ToList()
                        .ForEach(Console.WriteLine);
                    Console.WriteLine();
                });

        }

        static void ex02v1()
        {
            Generator.GenerateStudentsWithTopicsEasy()
            .SelectMany(student => student.Topics)
            .GroupBy(topic => topic)
            .OrderBy(group => group.Count())
            .Select(group => group.Key)
            .ToList()
            .ForEach(Console.WriteLine);
        }

        static void ex02v2()
        {
            var resultByGender = Generator.GenerateStudentsWithTopicsEasy()
            .GroupBy(student => student.Gender)
            .Select(genderGroup => genderGroup
                .SelectMany(student => student.Topics)
                .GroupBy(topic => topic)
                .OrderBy(group => group.Count())
                .Select(group => group.Key)
                .ToList())
            .ToList();

            foreach (var genderResult in resultByGender)
            {
                Console.WriteLine($"Tematy posortowane wg częstości występowania dla płci {genderResult}:");

                foreach (var topic in genderResult)
                {
                    Console.WriteLine($"- {topic}");
                }

                Console.WriteLine("----------------");
            }

        }

        static void ex03(List<StudentWithTopics> studentsWithTopics)
        {
            var topics = TopicGenerator.GenerateTopics();

            studentsWithTopics.Select(student =>
                new Student(student.Id, student.Index, student.Name, student.Gender, student.Active, student.DepartmentId, student.Topics.Select(topicName =>
                    topics.First(t => t.Name == topicName).TopicId).ToList()))
                .ToList()
                .ForEach(Console.WriteLine);


        }
        static void ex04()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object ob1 = assembly.CreateInstance("Lab07.ExampleEx04");
            object ob2 = assembly.CreateInstance("Lab07.ExampleEx04");

            MethodInfo printMethod = ob1.GetType().GetMethod("printNTimes");
            MethodInfo addMethod = ob2.GetType().GetMethod("addNumbers");

            Console.WriteLine(printMethod.Invoke(ob1, new object[] { 3 }));
            Console.WriteLine(addMethod.Invoke(ob2, new object[] { 1, 2 }));
        }

        static void Main(string[] args)
        {
            ex01(3);
            ex02v1();
            ex02v2();
            ex03(Generator.GenerateStudentsWithTopicsEasy());
            ex04();
        }
    }
}
