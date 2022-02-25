<?xml version="1.0" encoding="ISO-8859-1"?>

<html dir="$DIRECTION$" xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
<link type="text/css" rel="stylesheet" href="$STYLE$" />
    
<p align="center"> <h1> $TITLE$ </h1></p>
<p dir="$DIRECTION$">  $HEADER$ </p>

	<xsl:for-each select="MAA/$GROUP$_Group">
      <div dir="$DIRECTION$"><b> $GROUPCAPTION$  <xsl:value-of select="$GROUP$"/></b>   </div>
	  
	  <div class="datagrid"><table>
	  <thead><tr>$TABLE_HEADER$</tr></thead>
	  
   
    <xsl:for-each select="$GROUP$">
	 
	 <xsl:choose>
     <xsl:when test="position() mod 2 = 0">
     <tbody><tr> 
     $FIELDS$
	 </tr></tbody>
     </xsl:when>
      
	 <xsl:otherwise>
     <tbody><tr class="alt"> 
	 $FIELDS$
	 </tr></tbody>
	 </xsl:otherwise>
     </xsl:choose>

	  </xsl:for-each>
      
	  <thead><tr>$SUBSUM$</tr></thead>
	  </table></div>
      <div style="background-color:white;color:white;padding:0px"> <span style="font-weight:bold">.</span></div>
			
    </xsl:for-each>
	
	<p dir="$DIRECTION$" > $FOOTER$ </p>
  
</html>