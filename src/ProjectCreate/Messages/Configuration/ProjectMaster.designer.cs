// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>AmplaTools.ProjectCreate.Messages.Configuration</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace AmplaTools.ProjectCreate.Messages.Configuration
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://github.com/AmplaTools/ProjectCreate")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate", IsNullable = false)]
    public partial class ProjectMaster
    {

        private EquipmentDefinition equipmentField;

        public ProjectMaster()
        {
            this.equipmentField = new EquipmentDefinition();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public EquipmentDefinition Equipment
        {
            get
            {
                return this.equipmentField;
            }
            set
            {
                this.equipmentField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate", IsNullable = true)]
    public partial class EquipmentDefinition
    {

        private ProjectHierarchy hierarchyField;

        private List<ClassDefinition> classesField;

        public EquipmentDefinition()
        {
            this.classesField = new List<ClassDefinition>();
            this.hierarchyField = new ProjectHierarchy();
        }

        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public ProjectHierarchy Hierarchy
        {
            get
            {
                return this.hierarchyField;
            }
            set
            {
                this.hierarchyField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Class", IsNullable = false)]
        public List<ClassDefinition> Classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate", IsNullable = true)]
    public partial class ProjectHierarchy
    {

        private string hrefField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate", IsNullable = true)]
    public partial class ClassDefinition
    {

        private string nameField;

        private string hrefField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://github.com/AmplaTools/ProjectCreate", IsNullable = true)]
    public partial class ListOfClasses
    {

        private List<ClassDefinition> classField;

        public ListOfClasses()
        {
            this.classField = new List<ClassDefinition>();
        }

        [System.Xml.Serialization.XmlElementAttribute("Class", Order = 0)]
        public List<ClassDefinition> Class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }
    }
}
