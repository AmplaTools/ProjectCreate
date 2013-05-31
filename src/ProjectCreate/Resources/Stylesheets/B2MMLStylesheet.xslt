<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:pc="http://github.com/AmplaTools/ProjectCreate"
                xmlns:b2mml = "http://www.mesa.org/xml/B2MML-V0500"
                >

  <xsl:output method="xml" indent="yes" />

  <xsl:template match="/">
    <b2mml:Response>
      <xsl:apply-templates select="pc:Enterprise"/>
    </b2mml:Response>
  </xsl:template>

  <xsl:template match="pc:Enterprise">
    <b2mml:Enterprise>
      <xsl:if test="@name">
        <xsl:attribute name="name">
          <xsl:value-of select="@name"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates select="pc:Site"/>
    </b2mml:Enterprise>
  </xsl:template>

  <xsl:template match="pc:Site">
    <b2mml:Site>
      <xsl:if test="@name">
        <xsl:attribute name="name">
          <xsl:value-of select="@name"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates select="pc:Area"/>
    </b2mml:Site>
  </xsl:template>

  <xsl:template match="pc:Area">
    <b2mml:Area>
      <xsl:if test="@name">
        <xsl:attribute name="name">
          <xsl:value-of select="@name"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates select="pc:Workcentre"/>
    </b2mml:Area>
  </xsl:template>

  <xsl:template match="pc:Workcentre">
    <b2mml:Workcentre>
      <xsl:if test="@name">
        <xsl:attribute name="name">
          <xsl:value-of select="@name"/>
        </xsl:attribute>
      </xsl:if>
    </b2mml:Workcentre>
  </xsl:template>

</xsl:stylesheet>