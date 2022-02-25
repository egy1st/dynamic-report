Public Class SourceXSLT



    Public Function getXSLT() As String
        Dim str As String = ""

        str += "<?xml version='1.0' encoding='ISO-8859-1'?>" + vbCrLf
        str += "<html dir='$DIRECTION$' xsl:version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform' xmlns='http://www.w3.org/1999/xhtml'>" + vbCrLf
        str += "<link type='text/css' rel='stylesheet' href='$STYLE$' />" + vbCrLf
        str += vbCrLf
        str += "<h1><p align='center'> $TITLE$ </p></h1>" + vbCrLf
        str += "<p dir='$DIRECTION$'>  $HEADER$ </p>" + vbCrLf
        str += vbCrLf
        str += "<xsl:for-each select='DCDR35/$GROUP$_Group'>" + vbCrLf
        str += "<div dir='$DIRECTION$'><b> $GROUPCAPTION$  $GROUP2$</b>   </div>" + vbCrLf
        str += vbCrLf
        str += "<div class='datagrid'><table>" + vbCrLf
        str += "<thead><tr>$TABLE_HEADER$</tr></thead>" + vbCrLf
        str += vbCrLf
        str += "<xsl:for-each select='$GROUP$'>" + vbCrLf
        str += vbCrLf
        str += "<xsl:choose>" + vbCrLf
        str += "<xsl:when test='position() mod 2 = 0'>" + vbCrLf
        str += "<tbody><tr $ALLTERNATEROW$>" + vbCrLf
        str += "$FIELDS$" + vbCrLf
        str += "</tr></tbody>" + vbCrLf
        str += "</xsl:when>" + vbCrLf
        str += vbCrLf
        str += "<xsl:otherwise>" + vbCrLf
        str += "<tbody><tr>" + vbCrLf
        str += "$FIELDS$" + vbCrLf
        str += "</tr></tbody>" + vbCrLf
        str += "</xsl:otherwise>" + vbCrLf
        str += "</xsl:choose>" + vbCrLf
        str += vbCrLf
        str += "</xsl:for-each>" + vbCrLf
        str += vbCrLf
        str += "<thead><tr>$SUBSUM$</tr></thead>" + vbCrLf
        str += "</table></div>" + vbCrLf
        str += "<div style='background-color:white;color:white;padding:0px'> <span style='font-weight:bold'>.</span></div>" + vbCrLf
        str += vbCrLf
        str += "</xsl:for-each>" + vbCrLf
        str += vbCrLf
        str += "<p dir='$DIRECTION$' > $FOOTER$ </p>" + vbCrLf
        str += vbCrLf
        str += "</html>" + vbCrLf




        Return str.Replace("'", Chr(34))
    End Function

End Class
