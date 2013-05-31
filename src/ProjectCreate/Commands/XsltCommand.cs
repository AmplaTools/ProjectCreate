using System;
using System.Xml;
using System.Xml.Xsl;

namespace AmplaTools.ProjectCreate.Commands
{
    /// <summary>
    ///     XsltCommand that applies an Xslt and outputs to a writer
    /// </summary>
    public abstract class XsltCommand : ICommand
    {
        private readonly XmlWriter outputWriter;

        protected XsltCommand(XmlWriter outputWriter)
        {
            this.outputWriter = outputWriter;
        }

        public void Execute()
        {
            XmlDocument xmlDoc = GetSourceDocument();
            XslCompiledTransform transform = GetXsltStylesheet();
            if (xmlDoc == null) throw new InvalidOperationException("No Source document");
            if (transform == null) throw new InvalidOperationException("No XslTransform document.");
            transform.Transform(xmlDoc, outputWriter);
        }

        protected abstract XslCompiledTransform GetXsltStylesheet();
        
        protected abstract XmlDocument GetSourceDocument();

    }
}