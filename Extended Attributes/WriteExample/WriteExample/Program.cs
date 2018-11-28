using System;
using System.IO;
using Aspose.Tasks;
using Aspose.Tasks.Saving;

namespace WriteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TestProject.mpp");

            Project myProject = new Project(filePath);


            ExtendedAttributeDefinition attribute = ExtendedAttributeDefinition.CreateLookupTaskDefinition(CustomFieldType.Text, ExtendedAttributeTask.Text1, "Test Attribute");

            Value value1 = new Value
            {
                Id = 1,
                StringValue = "Server/Database",
                Description = "DataBase of Server Side"
            };

            Value value2 = new Value
            {
                Id = 2,
                StringValue = "Server/Api",
                Description = "Api of Server Side"
            };

            Value value3 = new Value
            {
                Id = 3,
                StringValue = "Client/WebUI",
                Description = "WebUI of Client Side"
            };

            attribute.AddLookupValue(value1);

            attribute.AddLookupValue(value2);

            attribute.AddLookupValue(value3);

            myProject.ExtendedAttributes.Add(attribute);


            ExtendedAttribute serverDatabaseAttribute = attribute.CreateExtendedAttribute(value1);

            ExtendedAttribute serverApiAttribute = attribute.CreateExtendedAttribute(value2);

            ExtendedAttribute clientUIAttribute = attribute.CreateExtendedAttribute(value3);


            Task task1 = myProject.RootTask.Children.Add("Task 1");

            task1.ExtendedAttributes.Add(serverDatabaseAttribute);


            Task task2 = myProject.RootTask.Children.Add("Task 2");

            task2.ExtendedAttributes.Add(serverDatabaseAttribute);


            Task task3 = myProject.RootTask.Children.Add("Task 3");

            task3.ExtendedAttributes.Add(serverApiAttribute);


            Task task4 = myProject.RootTask.Children.Add("Task 4");

            task4.ExtendedAttributes.Add(clientUIAttribute);

            myProject.Save(filePath, SaveFileFormat.MPP);
        }
    }
}
