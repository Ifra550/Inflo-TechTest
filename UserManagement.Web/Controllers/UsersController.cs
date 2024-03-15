using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    public ViewResult List()
    {
        var items = _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }
    [HttpGet("active")]
    public ViewResult ActiveUsers()
    {
        var activeItems = _userService.GetAll().Where(p => p.IsActive).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth

        });

        var model = new UserListViewModel
        {
            Items = activeItems.ToList()
        };

        return View("List", model);
    }
    [HttpGet("inactive")]
    public ViewResult InactiveUsers()
    {
        var inactiveItems = _userService.GetAll().Where(p => !p.IsActive).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = inactiveItems.ToList()
        };

        return View("List", model);
    }
    [HttpGet("viewUser")]
    public ViewResult viewUser(int id)
    {
        var items = _userService.FilterByUser(id).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth

        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpGet("editUser")]
    public ViewResult editUser(int id)
    {
        var items = _userService.FilterByUser(id).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth

        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpPost("editUser")]
    [ValidateAntiForgeryToken]
    public ActionResult editUser(int Id, [Bind("Id", "Forename", "Surname", "Email", "IsActive", "DateOfBirth")] Models.User user)
    {
        if(ModelState.IsValid)
        {
            _userService.UpdateUser(user);
            return Redirect("viewUser?id=" + Id);
        }
        return editUser(Id);
    }


    [HttpGet("deleteUser")]
    public ViewResult deleteUser(int id)
    {
        var items = _userService.FilterByUser(id).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth

        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpPost("deleteUser")]
    [ValidateAntiForgeryToken]
    public ActionResult deleteUser(int Id, [Bind("Id", "Forename", "Surname", "Email", "IsActive", "DateOfBirth")] Models.User user)
    {
        try
        {
            _userService.DeleteUser(user);
        }
        catch
        {
            return View("Error");
        }

        return Redirect(".");
    }

    [HttpGet("createUser")]
    public ViewResult createUser()
    {
        var items = _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth

        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpPost("createUser")]
    [ValidateAntiForgeryToken]
    public ActionResult createUser(int Id, [Bind("Id", "Forename", "Surname", "Email", "IsActive", "DateOfBirth")] Models.User user)
    {
        if (ModelState.IsValid)
        {
            _userService.CreateUser(user);
            return Redirect("viewUser?id=" + Id);
        }
        return createUser();
    }

}
