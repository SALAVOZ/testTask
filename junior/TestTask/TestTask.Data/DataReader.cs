namespace TestTask.Data
{
    using System.Text.Json;
    using TestTask.Data.DataModels;
    using TestTask.Data.Interfaces;
    using System.IO;
    using System.Text;
    using System.Linq;

    public class DataReader : IDataJsonReader
    {
        private string pathUser = @"C:\testTask\junior\TestTask\TestTask.Data\Users.json";
        private string pathUserTypes = @"C:\testTask\junior\TestTask\TestTask.Data\UserTypes.json";
        public UserTypeModel[] userTypes = null;
        public UserModel[] users = null;
        public DataReader()
        {
            userTypes = this.ReadFromJson<UserTypeModel>(pathUserTypes);
        }

        //public UserModel[] ReadUsersJson()
        //{
        //    using (FileStream fstream = File.OpenRead(pathUser))
        //    {
        //        byte[] buffer = new byte[fstream.Length];
        //        fstream.Read(buffer, 0, buffer.Length);
        //        string textFromFile = Encoding.Default.GetString(buffer);
        //        UserModel[] data = JsonSerializer.Deserialize<UserModel[]>(textFromFile);
        //        return data;
        //    }
        //}

        //public UserTypeModel[] ReadUserTypes()
        //{
        //    using (FileStream fstream = File.OpenRead(pathUserTypes))
        //    {
        //        byte[] buffer = new byte[fstream.Length];
        //        fstream.Read(buffer, 0, buffer.Length);
        //        string textFromFile = Encoding.Default.GetString(buffer);
        //        UserTypeModel[] data = JsonSerializer.Deserialize<UserTypeModel[]>(textFromFile);
        //        return data;
        //    }
        //}

        public T[] ReadFromJson<T>(string path) where T: class
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                T[] data = JsonSerializer.Deserialize<T[]>(textFromFile);
                return data;
            }
        }
        public string GetUserTypeById(int id)
        {
            return this.userTypes.Where(type => type.id == id).Select(type => type.name).FirstOrDefault();
        }

        public string[] getUserTypesString()
        {
            return this.userTypes.Select(type => type.name).ToArray();
        }

        public UserModel[] GetFiltredUsersByTypeId(int type_id, string login, string password, string name)
        {
            switch (type_id)
            {
                case 0: return this.ReadFromJson<UserModel>(pathUser);
                default: return this.ReadFromJson<UserModel>(pathUser).Where(user => user.type_id == type_id).ToArray();
            }
        }
    }
}
