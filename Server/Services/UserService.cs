using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Services;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Server.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // private readonly RoleManager<IdentityRole> _roleManager;
    private readonly BaseDbContext _context;
    private readonly HttpContext _httpContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UserService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, BaseDbContext context, HttpContext httpContext,IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        // _roleManager = roleManager;
        _context = context;
        _httpContext = httpContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<ServiceResponse<ApplicationUser>> GetUser()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> GetCurrentUser()
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ApplicationUser>();
        // var user = await _userManager.GetUserAsync(_httpContext.User) ?? throw new Exception("User not found");
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User) ?? throw new Exception("User not found");
        
        response.Data = user;
        return response;
    }
    

    public Task<ServiceResponse<ApplicationUser>> GetUserById(string id)
    {
        throw new NotImplementedException();
        
    }

    public Task<ServiceResponse<ApplicationUser>> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<ApplicationUser>> GetUserByStudentId(string studentId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<ApplicationUser>> UpdateUser(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<ApplicationUser>> DeleteUser(string id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ServiceResponse<Register>> RegisterUser(Register newUser)
    {
        var response = new ServiceResponse<Register>();
        var user = new ApplicationUser()
        {
            Id = newUser.StudentId,
            UserName = $"{newUser.Lastname}{newUser.Firstname}",
            Firstname = newUser.Firstname,
            Lastname = newUser.Lastname,
            Email = newUser.Email,
            PhoneNumber = newUser.PhoneNumber,
        };

        var result = await _userManager.CreateAsync(user, newUser.Password);
        if (result.Succeeded)
        {
            response.Success = true;
            response.Message = "User created.";
            return response;
        }
        else
        {
            response.Success = false;
            response.Message = string.Join(", ", result.Errors.Select(e => e.Description));
            return response;
        }

        return response;
    }


    public async Task<ServiceResponse<Login>> LoginUser(Login user)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<Login>();
        var student = await _userManager.FindByIdAsync(user.StudentId);

        if (student == null)
        {
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        // Checking if the user is locked out
        if (await _userManager.IsLockedOutAsync(student))
        {
            response.Success = false;
            response.Message = "User is locked out";
            return response;
        }
        
        // Check if the email is confirmed
        if (!await _userManager.IsEmailConfirmedAsync(student))
        {
            response.Success = false;
            response.Message = "Email is not confirmed";
            return response;
        }
        
        var result = await _signInManager.PasswordSignInAsync(
            userName: student.UserName, 
            password: user.Password, 
            isPersistent: false, 
            lockoutOnFailure: false
        );
        Console.Write("printing the result "+result);
        if (result.Succeeded)
        {
            response.Success = true;
            response.Message = "Login success";
            return response;
        }

        response.Success = false;
        response.Message = result.ToString();
        return response;


    }
}