using Core.Entities.Abstract;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class UserRoleClaim : BaseEntity<int>, IEntity
    {
        public int UserId { get; set; }
        public int RoleClaimId { get; set; }

        public User User { get; set; }
        public RoleClaim RoleClaim { get; set; }
    }
}