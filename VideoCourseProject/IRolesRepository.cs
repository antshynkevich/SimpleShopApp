using VideoCourseProject.Areas.Admin.Models;
using VideoCourseProject.Models;

namespace VideoCourseProject;

public interface IRolesRepository
{
    List<Role> GetAll();
    Role TryGetByName(string name);
    void Add(Role role);
    void Remove(string name);
}
