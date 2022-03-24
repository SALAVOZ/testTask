using System.Threading.Tasks;
using TestTask.Data.DataModels;

namespace TestTask.Data.Interfaces
{
    public interface IDataJsonReader
    {
        UserModel[] ReadUsersJson();
        string GetUserTypeBy(int id);
        UserTypeModel[] ReadUserTypes();
    }
}
