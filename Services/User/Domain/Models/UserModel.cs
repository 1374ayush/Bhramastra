namespace Domain.Models;

public class UserModel
{
    /// <summary>
    /// Email address.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    public required string Password { get; set; }
}
