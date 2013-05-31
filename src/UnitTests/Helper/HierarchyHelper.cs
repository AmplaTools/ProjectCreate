using AmplaTools.ProjectCreate.Messages;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class HierarchyHelper
    {
        public static Hierarchy CreateDefaultHierarchy()
        {
            var hierarchy = new Hierarchy {Enterprise = new Enterprise {name = "Enterprise", id = "enterprise"}};
            hierarchy.Enterprise.Site.Add(new Site {name = "Site A"});

            Assert.That(hierarchy.GetCount(), Is.EqualTo(2));
                
            return hierarchy;
        }
    }
}