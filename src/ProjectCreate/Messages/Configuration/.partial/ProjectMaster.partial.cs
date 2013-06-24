namespace AmplaTools.ProjectCreate.Messages.Configuration
{
    public partial class ProjectMaster
    {
        public static string Namespace = "http://github.com/AmplaTools/ProjectCreate";

        public static ProjectMaster NewProject()
        {
            ProjectMaster project = new ProjectMaster
                {
                    Equipment = new EquipmentDefinition
                            {
                                Hierarchy = new ProjectHierarchy
                                    {
                                        format = ProjectFileFormat.Excel, 
                                        href = "Hierarchy.xlsx"
                                    }
                            }
                };

            return project;
        }
    }
}