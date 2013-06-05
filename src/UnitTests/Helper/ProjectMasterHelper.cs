using AmplaTools.ProjectCreate.Messages.Configuration;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Helper
{
    public class ProjectMasterHelper
    {
        public static ProjectMaster CreateDefaultProject()
        {
            ProjectMaster master = new ProjectMaster
                {
                    Equipment = new EquipmentDefinition() {Hierarchy = new ProjectHierarchy() {href = "Hierarchy.xml"}}
                };

            Assert.That(master.Equipment.Hierarchy.href, Is.Not.Null);

            return master;
        }
 
    }
}