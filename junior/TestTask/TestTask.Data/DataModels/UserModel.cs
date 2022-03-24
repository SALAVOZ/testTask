namespace TestTask.Data.DataModels
{
    public class UserModel
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int type_id { get; set; }
        public string last_visit_date { get; set; }
    }
}
