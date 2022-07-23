using VideoCourseProject.Models;

namespace VideoCourseProject;

public class RolesInMemoryRepository : IRolesRepository
{
    private readonly List<Role> _roles = new List<Role>();
    public List<Role> GetAll()
    {
        return _roles;
    }

    public Role TryGetByName(string name)
    {
        return _roles.FirstOrDefault(x => x.Name == name);
    }

    public void Add(Role role)
    {
        _roles.Add(role);
    }

    public void Remove(string name)
    {
        _roles.RemoveAll(x => x.Name == name);
    }
}
