using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Api.Model;

public class Role
{
    [Key] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<User> Users { get; set; }
}