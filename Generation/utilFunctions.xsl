<?xml version = '1.0' encoding = 'ASCII' ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:uFN="uFN" version="2.0">

<xsl:function name="uFN:first-upper">
  <xsl:param name="value"/>
  <xsl:sequence select="concat(upper-case(substring($value, 1, 1)), substring($value, 2))"/>
</xsl:function>

<xsl:function name="uFN:first-lower">
  <xsl:param name="value"/>
  <xsl:sequence select="concat(lower-case(substring($value, 1, 1)), substring($value, 2))"/>
</xsl:function>

<xsl:function name="uFN:default-init">
  <xsl:param name="value"/>
  <xsl:choose>
    <xsl:when test="$value = 'int'">
      <xsl:sequence select="'0'"/>
    </xsl:when>
    <xsl:when test="$value = 'double'">
      <xsl:sequence select="'0'"/>
    </xsl:when>
    <xsl:when test="$value = 'bool'">
      <xsl:sequence select="'false'"/>
    </xsl:when>
    <xsl:when test="$value = 'boolean'">
      <xsl:sequence select="'false'"/>
    </xsl:when>
    <xsl:when test="$value = 'Boolean'">
      <xsl:sequence select="'false'"/>
    </xsl:when>
    <xsl:when test="$value = 'string'">
      <xsl:sequence select="'string.Empty'"/>
    </xsl:when>
    <xsl:when test="$value = 'DateTime'">
      <xsl:sequence select="'new DateTime(0)'"/>
    </xsl:when>
    <xsl:when test="$value = 'NiveauASA'">
      <xsl:sequence select="'Domain.NiveauASA.INDETERMINE'"/>
    </xsl:when>
    <xsl:when test="$value = 'ReactionAntibiotique'">
      <xsl:sequence select="'Domain.ReactionAntibiotique.INDETERMINE'"/>
    </xsl:when>
    <xsl:when test="$value = 'NiveauMcCabe'">
      <xsl:sequence select="'Domain.NiveauMcCabe.INDETERMINE'"/>
    </xsl:when>
    <xsl:otherwise>
      <xsl:sequence select="'null'"/>
    </xsl:otherwise>
  </xsl:choose>
</xsl:function>

</xsl:stylesheet>
