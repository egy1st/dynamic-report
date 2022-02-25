Imports System.Xml
Imports System.IO

Namespace DynamicComponents
    Public Class DynamicReport

        Private ds As New DataSet
        Private FieldsCount As Integer
        Private HeaderLines As String
        Private FooterLines As String
        Private m_GroupField As String = "ALL"
        Private m_GroupPos As Integer = -1
        Private aGroupVal() As Decimal
        Private aCaption As New Collection()
        Private aName As New Collection()
        Private aSumFields As New Collection()
        Private aSumFieldsPos As New Collection()
        Private m_LogoFile As String
        Private m_LogoPath As String
        Private m_HeaderText As String
        Private m_StrSumFields As String = "*"
        Private m_PageBreak As Boolean
        Private m_Alignment As String
        Private m_Direction As String = "ltr"
        Private m_ShowGroupNavigator As Boolean = False
        Private m_Style As String
        Private m_GroupCaption As String
        Private m_SumCaption As String
        Private m_AllternateRow As Boolean = True
        Private i As Long = 0
        Public Shared Internal_Registration_Key As String = "0000-000-000-000-0000"
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        Private Sub MYExnHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            Dim EX As Exception
            EX = e.ExceptionObject
            Dim str_error As String = "http://www.mygoldensoft.com/notify.php?error=" + EX.StackTrace
            Dim result_error As String = GetPageHTML(str_error)
        End Sub
        Private Sub MYThreadHandler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
            Dim str_error As String = "http://www.mygoldensoft.com/notify.php?error=" + e.Exception.StackTrace
            Dim result_error As String = GetPageHTML(str_error)
        End Sub
        Private Function GetPageHTML(ByVal URL As String) As String
            Dim objWC As New System.Net.WebClient()
            Return New System.Text.UTF8Encoding().GetString(objWC.DownloadData(URL))
        End Function
        Public Sub useStyle(ByVal str_Style As String, ByVal AllternateRow As Boolean)
            m_Style = str_Style
            m_AllternateRow = AllternateRow
        End Sub
        Public Sub groubBy(ByVal GroupField As String, ByVal GroupCaption As String)
            Dim X As Integer

            m_GroupField = GroupField
            m_GroupCaption = GroupCaption

            For X = 0 To ds.Tables(0).Columns.Count - 1
                If UCase(ds.Tables(0).Columns(X).Caption) = UCase(GroupField) Then
                    m_GroupPos = X
                    Exit For
                End If
            Next X
        End Sub
        Public Sub initReport(ByRef ReportTable As DataSet, ByVal Right2Left As Boolean)

            ds = ReportTable
            If Right2Left = False Then
                m_Alignment = "ltr"
            Else
                m_Alignment = "rtl"
            End If

        End Sub
        Public Sub setTitle(ByVal str_Title As String)
            m_HeaderText = str_Title
        End Sub
        Public Sub sumFields(ByVal ParamArray str_Line() As String)
            Dim cLine As String
            Dim X As Integer

            For Each cLine In str_Line
                aSumFields.Add(cLine)
                For X = 0 To ds.Tables(0).Columns.Count - 1
                    If UCase(ds.Tables(0).Columns(X).Caption) = UCase(cLine) Then
                        aSumFieldsPos.Add(X)
                        m_StrSumFields += X.ToString + "*"
                        Exit For
                    End If
                Next X
            Next cLine
        End Sub
        Public Sub setReportHeader(ByVal ParamArray str_Lines() As String)
            Dim cLine As String
            Dim str As String = ""

            For Each cLine In str_Lines
                str += "<p></p>" + cLine
            Next cLine
            HeaderLines = str
        End Sub
        Public Sub setReportFooter(ByVal ParamArray str_Lines() As String)
            Dim cLine As String
            Dim str As String = ""

            For Each cLine In str_Lines
                str += "<p></p>" + cLine
            Next cLine
            FooterLines = str
        End Sub
        Public Sub setCaption(ByVal ParamArray str_Line() As String)
            Dim cLine As String
            aCaption.Clear()
            For Each cLine In str_Line
                aCaption.Add(cLine)
            Next cLine

        End Sub
        Private Sub getNames()
            aName.Clear()
            For x = 0 To FieldsCount - 1
                aName.Add(ds.Tables(0).Columns(x).Caption.Replace(" ", "_"))
            Next x


        End Sub

        Public Sub generateReport(ByVal ReportName As String, ByVal ReportPath As String)
            Dim MyProtect As New MyProtection()
            Dim _ProductId As String
            Dim _CompanyId As String
            Dim _CompanyInfo As String
            Dim _ProductVersion As String
            Dim _buynow_URL As String

            ' Define a handler for unhandled exceptions.
            AddHandler currentDomain.UnhandledException, AddressOf MYExnHandler

            ' Define a handler for unhandled exceptions for threads behind forms.
            AddHandler Application.ThreadException, AddressOf MYThreadHandler

            _CompanyId = "EgyFirst Software"
            _ProductId = "DynamicReport"
            _ProductVersion = "V. 3.5"

            _CompanyInfo = "Dynamic Report V. 3.5" + vbCrLf
            _CompanyInfo += "Powered by EgyFirst Software, Inc." + vbCrLf
            _CompanyInfo += "Free 30 Days Trial Version"

            _buynow_URL = "http://www.mygoldensoft.com/ordernow.html"

            MyProtect.SetProductKeys(_CompanyId, _ProductId, _ProductVersion)
            MyProtect.SetAlgorithms(1971, 16, 35)
            MyProtect.SetInformation(_buynow_URL, _CompanyInfo)
            MyProtect.SetLicense(30)
            MyProtect.ShowAuthor()
            If MyProtect.NotLicensed Then
                Exit Sub
            End If


            Dim str As String = ""
            Dim str2 As String = ""
            Dim str3 As String = ""
            Dim str4 As String = ""
            Dim xslt As New SourceXSLT

            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim count As Integer = 1
            Dim _groupid As String = ""
            Dim old_groupid As String = ""
            Dim settings As New Xml.XmlWriterSettings()
            settings.Indent = True
            settings.NewLineOnAttributes = True
            'settings.ConformanceLevel = ConformanceLevel.Fragment

            FieldsCount = ds.Tables(0).Columns.Count
            If FieldsCount > 0 Then

                ReDim aGroupVal(FieldsCount)
                getNames()

                If aCaption.Count = 0 Then
                    For x = 0 To FieldsCount - 1
                        aCaption.Add(ds.Tables(0).Columns(x).Caption)
                    Next

                End If

                Using writer As XmlWriter = XmlWriter.Create((ReportPath + ReportName + ".xml"), settings)

                    writer.WriteStartDocument()

                    ' Write the Processing Instruction node.
                    Dim PItext As String = " type=""text/xsl"" href=""" + ReportName + ".xsl"" "
                    writer.WriteProcessingInstruction("xml-stylesheet", PItext)

                    'Write a Comment node.
                    writer.WriteComment("Powered By Dyanmic Report V. 3.5")

                    ' Write the root element.
                    writer.WriteStartElement("DCDR35")
                    writer.WriteStartElement(m_GroupField + "_Group")
                    If m_GroupField <> "ALL" Then
                        _groupid = ds.Tables(0).Rows(0).Item(m_GroupPos).ToString
                        writer.WriteElementString(m_GroupField, _groupid)
                    End If


                    Dim Row As DataRow
                    For Each Row In ds.Tables(0).Rows

                        old_groupid = _groupid
                        If m_GroupField <> "ALL" Then
                            _groupid = Row.Item(m_GroupPos).ToString
                        End If

                        If _groupid <> old_groupid Then
                            For y = 0 To FieldsCount - 1
                                If m_StrSumFields.Contains("*" + y.ToString + "*") Then
                                    writer.WriteElementString("SubSum" + y.ToString, aGroupVal(y).ToString)
                                End If
                            Next

                            writer.WriteEndElement()
                            writer.WriteStartElement(m_GroupField + "_Group")
                            writer.WriteElementString(m_GroupField, Row.Item(m_GroupPos).ToString)
                            For y = 1 To aSumFields.Count
                                aGroupVal(aSumFieldsPos(y)) = 0
                            Next
                        End If


                        writer.WriteStartElement(m_GroupField)
                        For x = 0 To FieldsCount - 1
                            If x <> m_GroupPos Then
                                writer.WriteElementString(aName(x + 1), Row.Item(x).ToString)
                            End If
                        Next x
                        writer.WriteEndElement()

                        For y = 1 To aSumFields.Count
                            aGroupVal(aSumFieldsPos(y)) += Row.Item(aSumFieldsPos(y))
                        Next


                    Next
EndMe:
                    For y = 0 To FieldsCount - 1
                        If m_StrSumFields.Contains("*" + y.ToString + "*") Then
                            writer.WriteElementString("SubSum" + y.ToString, aGroupVal(y).ToString)
                        End If
                    Next


                    writer.WriteEndDocument()
                    writer.Close()


                    str = xslt.getXSLT()

                    str = str.Replace("$DIRECTION$", m_Alignment)
                    str = str.Replace("$STYLE$", m_Style)
                    str = str.Replace("$TITLE$", m_HeaderText)
                    str = str.Replace("$HEADER$", HeaderLines)
                    str = str.Replace("$GROUP$", m_GroupField)
                    str = str.Replace("$GROUPCAPTION$", m_GroupCaption)
                    If m_AllternateRow = True Then
                        str = str.Replace("$ALLTERNATEROW$", "class=""alt""")
                    Else
                        str = str.Replace("$ALLTERNATEROW$", "")
                    End If
                    If m_GroupField = "ALL" Then
                        str = str.Replace("$GROUP2$", "")
                    Else
                        str = str.Replace("$GROUP2$", "<xsl:value-of select=""" + m_GroupField + """/>")
                    End If

                    str2 = ""

                    For x = 0 To aCaption.Count - 1
                        If x <> m_GroupPos Then
                            str2 += "<th>" + aCaption(x + 1) + "</th>" 'aCaption starts with 1
                        End If
                    Next x

                    str = str.Replace("$TABLE_HEADER$", str2)

                    str3 = ""
                    For x = 0 To FieldsCount - 1
                        If x <> m_GroupPos Then
                            str3 += "<td> <xsl:value-of select='" + ds.Tables(0).Columns(x).Caption + "'/> </td>" + vbCrLf
                        End If
                    Next x
                    str = str.Replace("$FIELDS$", str3)

                    str4 = ""
                    For x = 0 To FieldsCount - 1
                        If x <> m_GroupPos Then
                            str4 += "<th> <xsl:value-of select='SubSum" + x.ToString + "'/> </th>" + vbCrLf
                        End If
                    Next x
                    str = str.Replace("$SUBSUM$", str4)


                    str = str.Replace("$FOOTER$", FooterLines)


                    Dim objWriter As New System.IO.StreamWriter(Application.StartupPath + "\" + ReportName + ".xsl")
                    objWriter.Write(str)
                    objWriter.Close()

                End Using

            Else
                MsgBox("Dataset Is Empty")
            End If

        End Sub

        Public Sub setRegistrationKey(ByVal myKey As String)
            Internal_Registration_Key = myKey
        End Sub

    End Class
End Namespace