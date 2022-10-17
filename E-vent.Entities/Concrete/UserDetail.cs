using E_vent.Entities.Abstract;

namespace E_vent.Entities.Concrete
{
    public partial class UserDetail : IEntity
    {
        public UserDetail()
        {
            Users = new HashSet<User>();
        }

        public int DetailId { get; set; }
        public string? FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; } = null!;

        public virtual ICollection<User>? Users { get; set; }
    }
}