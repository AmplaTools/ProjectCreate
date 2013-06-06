using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class AreaCollection : ItemCollection<Area>
    {
        public AreaCollection(Item parent) : base(parent)
        {
        }
    }

    public class SiteCollection : ItemCollection<Site>
    {
        public SiteCollection(Item parent)
            : base(parent)
        {
        }
    }

    public class WorkCentreCollection : ItemCollection<WorkCentre>
    {
        public WorkCentreCollection(Item parent)
            : base(parent)
        {
        }
    }
}