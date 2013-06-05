<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns="http://www.wbf.org/xml/b2mml-v0400"
  xmlns:pc="http://github.com/AmplaTools/ProjectCreate"
  exclude-result-prefixes="pc"
  >

  <xsl:output method="xml" indent="yes" />

  <xsl:param name="modelDateTime">2013-01-01T12:00:00Z</xsl:param>

  <xsl:variable name="invalidChars">./?:&amp;\*&gt;&lt;[]|#%="</xsl:variable>

  <xsl:variable name="master-data-file" select="/"/>
  <!--
        This is the entry point for the transformation. It sets up the header information before finding all of the root nodes.
    -->
  <xsl:template match="/">
    <ShowEquipmentInformation releaseID="" 
                              xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
                              xmlns:xsd="http://www.w3.org/2001/XMLSchema" 
                              xmlns="http://www.wbf.org/xml/b2mml-v0400">
      <ApplicationArea>
        <CreationDateTime>
          <xsl:value-of select="$modelDateTime" />
        </CreationDateTime>
      </ApplicationArea>
      <DataArea>
        <Show />
        <EquipmentInformation>
          <PublishedDate>
            <xsl:value-of select="$modelDateTime" />
          </PublishedDate>
          <xsl:apply-templates select="/pc:Hierarchy/pc:Enterprise"/>
        </EquipmentInformation>
      </DataArea>
    </ShowEquipmentInformation>
  </xsl:template>

  <xsl:template name="add-equipment">
    <xsl:param name="name" select="@name"/>
    <xsl:param name="fullname">
      <xsl:call-template name="get-full-name"/>
    </xsl:param>
    <xsl:param name="children" select="./pc:*"/>
    <xsl:param name="equipmentLevel" select="name()"/>
    <Equipment>
      <ID schemeName="Fullname">
        <xsl:value-of select="$fullname"/>
      </ID>
      <xsl:call-template name="add-equipment-property">
        <xsl:with-param name="name">Ampla.Name</xsl:with-param>
        <xsl:with-param name="value" select="$name"/>
      </xsl:call-template>
      <xsl:apply-templates select="$children"/>
      <Location>
        <EquipmentID>
          <xsl:value-of select="@id"/>
        </EquipmentID>
        <EquipmentElementLevel>
          <xsl:value-of select="$equipmentLevel"/>
        </EquipmentElementLevel>
      </Location>
    </Equipment>
  </xsl:template>


  <xsl:template match="pc:Enterprise">
    <xsl:call-template name="add-equipment"/>
  </xsl:template>

  <xsl:template match="pc:Site">
    <xsl:call-template name="add-equipment"/>
  </xsl:template>

  <xsl:template match="pc:Area">
    <xsl:call-template name="add-equipment"/>
  </xsl:template>

  <xsl:template match="pc:WorkCentre">
    <xsl:call-template name="add-equipment">
      <xsl:with-param name="equipmentLevel">Other</xsl:with-param>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="pc:Folder">
    <xsl:call-template name="add-equipment">
      <xsl:with-param name="equipmentLevel">Other</xsl:with-param>
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="@* | node()"/>

  <xsl:template name="add-equipment-property">
    <xsl:param name="name" select="@name"/>
    <xsl:param name="value"></xsl:param>
    <xsl:param name="datatype">string</xsl:param>
    <EquipmentProperty>
      <ID>
        <xsl:value-of select="$name"/>
      </ID>
      <Value>
        <ValueString>
          <xsl:value-of select="$value"/>
        </ValueString>
        <DataType>
          <xsl:value-of select="$datatype"/>
        </DataType>
        <UnitOfMeasure />
      </Value>
    </EquipmentProperty>
  </xsl:template>

  <xsl:template name="get-full-name">
    <xsl:param name="node" select="."/>
    <xsl:for-each select="$node/ancestor-or-self::*[@name]">
      <xsl:if test="position() > 1">.</xsl:if>
      <xsl:value-of select="@name"/>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
