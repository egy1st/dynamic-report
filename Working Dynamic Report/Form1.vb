Imports System.Diagnostics.Process
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports DynamicComponents.DynamicReport

Public Class Form1
    Public Theme As String = "grey.css"
    Public ds As New DataSet


    Private Sub Access_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Access_Button.Click

        Dim connetionString As String
        Dim connection As OleDbConnection
        Dim oledbAdapter As OleDbDataAdapter
        Dim sql As String


        ds.Clear()
        connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\nWind.accdb"

        ' you should order your data by the field you are willing to groub by
        sql = "select * from OrderDetails_Query order by OrderID"
        connection = New OleDbConnection(connetionString)

        Try

            connection.Open()
            oledbAdapter = New OleDbDataAdapter(sql, connection)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            connection.Close()

        Catch ex As Exception

            MsgBox("Can not open connection ! ")
            Exit Sub

        End Try

        ' Call method for generating report using Dynamic Report V. 3.5
        generateReport()
    End Sub

    Private Sub ExitButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedText = "grey.css"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Theme = ComboBox1.SelectedText
    End Sub

    Private Sub Sql_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sql_Button.Click
        Dim connetionString As String
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim sql As String


        ds.Clear()
        connetionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\nWindSQL.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        ' you should order your data by the field you are willing to groub by
        sql = "select * from OrderDetails_Query order by OrderID"
        connection = New SqlConnection(connetionString)

        Try

            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()

        Catch ex As Exception

            MsgBox("Can not open connection ! ")
            Exit Sub

        End Try

        ' Call method for generating report using Dynamic Report V. 3.5
        generateReport()

    End Sub

    Public Sub generateReport()
        ' initReport method should be your first assignment // False means left2right orientation
        Dim oRep As New DynamicComponents.DynamicReport()
        oRep.setRegistrationKey("0000-000-000-000-0000") ' replace with your purchased serial number once you get one
        oRep.initReport(ds, False)

        oRep.setTitle("Orders Report")
        oRep.setReportHeader("This is Dynamic Report v3.5", "Powered by EgyFirst Software, Inc.")

        oRep.groubBy("OrderID", "Order Id")

        ' Use setCaption to put proper caption for dataset fields names, 
        'otherwise fields names will be used as caption by default
        oRep.setCaption("Order ID", "Product ID", "Product Name", "Unit Price", "Quantity", "Value", "Discount %", "Discount", "Net Value")

        ' Fields to show summation
        oRep.sumFields("Quantity", "Value", "DiscountValue", "NetValue")

        'Set style name. True means show alternating color rows.
        oRep.useStyle(ComboBox1.Text, True)
        oRep.setReportFooter("This is your report footer Section", "you can add here as many lines as you want")

        ' generateReport method should be your last assignment
        oRep.generateReport("Sales", Application.StartupPath + "\")

        MsgBox("Report has been generated at " + Application.StartupPath + "\" + "Sales.xml" + vbCrLf + "Please open it using any browser i.e. Interent Explorer or Mozilla Firfox.")
        ' Load report automatically using internet explorer
        'Start("IExplore.exe", Application.StartupPath + "\Sales.xml") 
    End Sub
End Class

