using System.Linq;

namespace AmplaTools.ProjectCreate.Messages
{
    public partial class Hierarchy
    {
        public int Count
        {
            get
            {
                if (Enterprise == null)
                {
                    return 0;
                }
                else
                {
                    return Enterprise.Count;
                }
            }
        }
        
    }

    public partial class Enterprise
    {
        public int Count
        {
            get
            {
                return Site.Aggregate(1, (current, site) => current + site.Count);
            }
        }
    }

    public partial class Site
    {
        public int Count
        {
            get
            {
                return Area.Aggregate(1, (current, area) => current + area.Count);
            }
        }
    }

    public partial class Area
    {
        public int Count
        {
            get
            {
                return Area1.Aggregate(1, (current, area) => current + area.Count) + WorkCentre.Count();
            }
        }
    }
}