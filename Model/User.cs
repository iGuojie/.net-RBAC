using System.Collections.Generic;

namespace Web_Api.Model;

public class User
{
    public int Id { get; set; }
    public string NickName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Role> Roles { get; set; }
}
