using Core.Entities.Abstract;

namespace Core.Entities.Concrete.ProcessGroups
{
    public class StatusLookup : BaseEntity<int>, IEntity
    {
        public int ProcessGroupId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ProcessGroup ProcessGroup { get; set; }
    }
}
