using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject;

public class UsersManager : IUsersManager
{
    private readonly List<UserAccount> _users = new();

    public List<UserAccount> GetAll()
    {
        return _users;
    }

    public void Add(UserAccount user)
    {
        _users.Add(user);
    }

    public UserAccount TryGetByName(string name)
    {
        return _users.FirstOrDefault(x => x.Name == name);
    }
}
