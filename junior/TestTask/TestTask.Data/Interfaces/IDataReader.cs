using System.Threading.Tasks;
using TestTask.Data.DataModels;

namespace TestTask.Data.Interfaces
{
    public interface IDataJsonReader
    {
        //UserModel[] ReadUsersJson();
        //UserTypeModel[] ReadUserTypes();
        string GetUserTypeById(int id);
        string[] getUserTypesString();
        UserModel[] GetFiltredUsersByTypeId(int type_id, string login, string password, string name);
        T[] ReadFromJson<T>(string path) where T : class;
    }
}
