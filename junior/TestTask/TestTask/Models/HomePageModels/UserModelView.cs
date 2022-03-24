using TestTask.Data.DataModels;
using TestTask.Data.Interfaces;

namespace TestTask.Models.HomePageModels
{
    public class UserModelView
    {
        private readonly IDataJsonReader _dataReader;
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string type_name { get; set; }
        public string last_visit_date { get; set; }
        public UserModelView(int id, 
                            string login, 
                            string password, 
                            string name, 
                            string type_name, 
                            string last_visit_name
                            )
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.type_name = type_name;
            this.last_visit_date = last_visit_date;
        }
    }
}
