using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ConsoleLang.Lang
{
    public class FilePrinter : MyPrinter
    {
        public void print()
        {
            // txt
            //loadTxtFile();

            // xml
            loadXmlFile();
        }

        private void loadXmlFile()
        {
            string path = @"E:\test_file\mytext.xml";

            // 创建XML文件
            XmlDocument document = new XmlDocument();
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", Encoding.UTF8.BodyName, "");
            document.AppendChild(declaration);

            XmlElement user = document.CreateElement("Student");
            user.SetAttribute("Type", "University");

            XmlElement userId = document.CreateElement("Id");
            userId.InnerText = "1";
            XmlElement userName = document.CreateElement("Name");
            userName.InnerText = "Aaric";
            XmlElement userAge = document.CreateElement("Age");
            userAge.InnerText = "18";

            user.AppendChild(userId);
            user.AppendChild(userName);
            user.AppendChild(userAge);
            document.AppendChild(user);

            document.Save(path);
            
            // 读取XML文件
            document = new XmlDocument();
            document.Load(path);
            XmlElement root = document.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                Console.WriteLine(node["Id"].InnerText);
            }
        }

        private void loadTxtFile()
        {
            string path = @"E:\test_file\mytext.txt";

            try
            {
                // 创建文本文件
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("hello world");
                    sw.WriteLine("hello microsoft");
                    sw.WriteLine("hello c");
                    sw.WriteLine("hello cpp");
                    sw.WriteLine("hello csharp");
                }

                // 读取文本文件
                string content = File.ReadAllText(path, Encoding.UTF8);
                Console.WriteLine($"{content}");

                // 读取文本文件
                int index = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        index++;
                        Console.WriteLine($"{index}: {sr.ReadLine()}");
                    }
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }
        }
    }
}