using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class WorkCentreCollection : ItemCollection<WorkCentre>
    {
        public WorkCentreCollection(Item parent) : base(parent)
        {
        }

        /// <summary>
        ///     Adds a new WorkCentre with the specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public WorkCentre AddWorkCentre(string name)
        {
            WorkCentre workCentre = new WorkCentre(name);
            Add(workCentre);
            return workCentre;
        }
    }
}