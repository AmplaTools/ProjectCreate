using System.Xml;
using AmplaTools.ProjectCreate.Helper;
using AmplaTools.ProjectCreate.Messages;

namespace AmplaTools.ProjectCreate.Commands
{
    public class B2MMLEquipmentCommand : XsltCommand
    {
        private readonly Hierarchy hierarchy;

        public B2MMLEquipmentCommand(Hierarchy hierarchy, XmlWriter outputWriter) : base(outputWriter)
        {
            this.hierarchy = hierarchy;
        }

        protected override XmlDocument GetSourceDocument()
        {
            return XmlHelper.SerializeToXmlDocument(hierarchy);
        }

        protected override System.Xml.Xsl.XslCompiledTransform GetXsltStylesheet()
        {
            return AssemblyResources.GetXsltStylesheet("AmplaTools.ProjectCreate.Resources.Stylesheets.B2MMLStylesheet.xslt");
        }
    }
}