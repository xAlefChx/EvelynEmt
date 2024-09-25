namespace Evelyn.Domain.Entities
{
    public class UserProject
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserTechId { get; set; }
        public Guid UserInChargeId { get; set; }
        public int ProjectId { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
    }
}