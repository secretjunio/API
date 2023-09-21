using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Insfracstructure.Entities
{
    [PrimaryKey(nameof(RoleId), nameof(AccountId))]
    public class AccountRole
    {
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
    }
}
