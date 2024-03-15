using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> FilterByUser(int id);
    void UpdateUser(User p);
    void DeleteUser(User p);
    void CreateUser(User p);
    IEnumerable<User> GetAll();
}
