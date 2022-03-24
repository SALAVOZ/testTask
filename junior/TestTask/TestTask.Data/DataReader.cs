namespace TestTask.Data
{
    using System.Text.Json;
    using TestTask.Data.DataModels;
    using TestTask.Data.Interfaces;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class DataReader : IDataJsonReader
    {
        private string pathUser = @"C:\testTask\junior\TestTask\TestTask.Data\Users.json";
        private string pathUserTypes = @"C:\testTask\junior\TestTask\TestTask.Data\UserTypes.json";

        public UserModel[] ReadUsersJson()
        {
            using (FileStream fstream = File.OpenRead(pathUser))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                UserModel[] data = JsonSerializer.Deserialize<UserModel[]>(textFromFile);
                return data;
            }
        }

        public UserTypeModel[] ReadUserTypes()
        {
            using (FileStream fstream = File.OpenRead(pathUserTypes))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                UserTypeModel[] data = JsonSerializer.Deserialize<UserTypeModel[]>(textFromFile);
                return data;
            }
        }

        public string GetUserTypeBy(int id)
        {
            using (FileStream fstream = File.OpenRead(pathUserTypes))
            {
                var text = new Regex(@$" ""id"": ${id} ");
                return "";
            }

        }
    }
}
