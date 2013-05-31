using System.Xml;
using System.Xml.Xsl;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Commands.MasterData
{
    public class EquipmentHierarchyCommand : XsltCommand
    {
        private readonly Hierarchy hierarchy;

        public EquipmentHierarchyCommand(Hierarchy hierarchy, XmlWriter outputWriter) : base(outputWriter)
        {
            this.hierarchy = hierarchy;
        }

        protected override XslCompiledTransform GetXsltStylesheet()
        {
            return AssemblyResources.GetXsltStylesheet("AmplaTools.ProjectCreate.Resources.Stylesheets.B2MML.Equipment.B2MMLStylesheet.xslt");
        }

        protected override XmlDocument GetSourceDocument()
        {
            return XmlHelper.SerializeToXmlDocument(hierarchy);
        }
    
    }
}