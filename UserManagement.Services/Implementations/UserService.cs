using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive)
    {
        if (isActive)
        {
            return _dataAccess.GetAll<User>().Where( p => p.IsActive ).ToList();
        }
        throw new NotImplementedException();
    }

    public IEnumerable<User> FilterByUser(int id)
    {
        return _dataAccess.GetAll<User>().Where(p => (p.Id == id)).ToList();
        
        throw new NotImplementedException();
    }

    public void UpdateUser(User p)
    {
        _dataAccess.Update<User>(p);
        return;

        throw new NotImplementedException();
    }

    public void DeleteUser(User p)
    {
        _dataAccess.Delete<User>(p);
        return;

        throw new NotImplementedException();
    }

    public void CreateUser(User p)
    {
        _dataAccess.Create<User>(p);
        return;

        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
}
