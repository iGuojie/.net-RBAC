using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Api.Model;

public class Resource
{
    [Key]
    public string Url { get; set; } = null!;
    public string? Descrpition { get; set; }
    
    public virtual ICollection<Role> Roles { get; set; }
}