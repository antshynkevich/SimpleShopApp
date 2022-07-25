using VideoCourseProject.Models;

namespace VideoCourseProject.Interfaces;

public interface IUsersManager
{
    List<UserAccount> GetAll();
    void Add(UserAccount user);
    UserAccount TryGetByName(string name);
}
