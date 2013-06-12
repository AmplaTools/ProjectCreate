using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class SiteCollection : ItemCollection<Site>
    {
        public SiteCollection(Item parent) : base(parent)
        {
        }

        /// <summary>
        ///     Adds a new Site with the specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Site AddSite(string name)
        {
            Site site = new Site(name);
            Add(site);
            return site;
        }
    }
}