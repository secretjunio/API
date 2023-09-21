using System.ComponentModel.DataAnnotations;

namespace WebApi.Insfracstructure.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
