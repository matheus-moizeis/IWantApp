using Microsoft.AspNetCore.Identity;

namespace IWantApp.EndPoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int page, int rows, UserManager<IdentityUser> userManager)
    {
        var users = userManager.Users.Skip((page - 1 ) * rows).Take(rows).ToList();

        var employees = users.Select(u => new EmployeeResponse( u.Email, "Teste" ));

        return Results.Ok(employees);
    }
}
