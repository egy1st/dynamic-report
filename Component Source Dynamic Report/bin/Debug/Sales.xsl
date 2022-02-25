<?xml version="1.0" encoding="ISO-8859-1"?>
<html dir="ltr" xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
<link type="text/css" rel="stylesheet" href="grey.css" />

<p align="center"> <h1> Orders Report </h1></p>
<p dir="ltr">  <p></p>This is Dynamic Report v3.5<p></p>Powered by EgyFirst Software, Inc. </p>

<xsl:for-each select="DCDR35/OrderID_Group">
<div dir="ltr"><b> Order Id  <xsl:value-of select="OrderID"/></b>   </div>

<div class="datagrid"><table>
<thead><tr><th>Product ID</th><th>Product Name</th><th>Unit Price</th><th>Quantity</th><th>Value</th><th>Discount %</th><th>Discount</th><th>Net Value</th></tr></thead>

<xsl:for-each select="OrderID">

<xsl:choose>
<xsl:when test="position() mod 2 = 0">
<tbody><tr class="alt">
<td> <xsl:value-of select='ProductID'/> </td>
<td> <xsl:value-of select='ProductName'/> </td>
<td> <xsl:value-of select='UnitPrice'/> </td>
<td> <xsl:value-of select='Quantity'/> </td>
<td> <xsl:value-of select='Value'/> </td>
<td> <xsl:value-of select='Discount'/> </td>
<td> <xsl:value-of select='DiscountValue'/> </td>
<td> <xsl:value-of select='NetValue'/> </td>

</tr></tbody>
</xsl:when>

<xsl:otherwise>
<tbody><tr>
<td> <xsl:value-of select='ProductID'/> </td>
<td> <xsl:value-of select='ProductName'/> </td>
<td> <xsl:value-of select='UnitPrice'/> </td>
<td> <xsl:value-of select='Quantity'/> </td>
<td> <xsl:value-of select='Value'/> </td>
<td> <xsl:value-of select='Discount'/> </td>
<td> <xsl:value-of select='DiscountValue'/> </td>
<td> <xsl:value-of select='NetValue'/> </td>

</tr></tbody>
</xsl:otherwise>
</xsl:choose>

</xsl:for-each>

<thead><tr><th> <xsl:value-of select='SubSum1'/> </th>
<th> <xsl:value-of select='SubSum2'/> </th>
<th> <xsl:value-of select='SubSum3'/> </th>
<th> <xsl:value-of select='SubSum4'/> </th>
<th> <xsl:value-of select='SubSum5'/> </th>
<th> <xsl:value-of select='SubSum6'/> </th>
<th> <xsl:value-of select='SubSum7'/> </th>
<th> <xsl:value-of select='SubSum8'/> </th>
</tr></thead>
</table></div>
<div style="background-color:white;color:white;padding:0px"> <span style="font-weight:bold">.</span></div>

</xsl:for-each>

<p dir="ltr" > <p></p>This is your report footer Section<p></p>you can add here as many lines as you want </p>

</html>
