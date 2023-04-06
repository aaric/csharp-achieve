using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleLang.Lang
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }

        public User(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class JsonPrinter : MyPrinter
    {
        /**
         * https://github.com/JamesNK/Newtonsoft.Json
         */
        public void print()
        {
            //JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            JsonConvert.DefaultSettings = () =>
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyy-MM-dd HH:mm:ss";
                setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                return setting;
            };

            User u1 = new User("张三", 25);
            u1.Salary = 10000;
            u1.Birthday = new DateTime(1998, 9, 25);

            string jsonString = JsonConvert.SerializeObject(u1);
            Console.WriteLine(jsonString);

            User u2 = JsonConvert.DeserializeObject<User>(jsonString);
            Console.WriteLine(u2.Name);
        }
    }
}