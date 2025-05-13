using System.ComponentModel.DataAnnotations;
using BlazorHybrid.Shared;

namespace BlazorHybrid.Api.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(250)]
        public string PasswordHash { get; set; } = string.Empty;
        [Length(10, 15)]
        public string Phone {  get; set; } = string.Empty;
        [MaxLength(15)]
        public string Role { get; set; } = nameof(UserRole.User);

        public bool IsApproved { get; set; }
    }
}
