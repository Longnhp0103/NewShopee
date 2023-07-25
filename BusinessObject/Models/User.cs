namespace BusinessObject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
