**DynamicComponents - Dynamic Report-----**

Powered by ![](Aspose.Words.243cc0cd-fe8f-469f-9819-4febfc653b1a.001.png)


**Overview**
-----
Dynamic Report is a breakthrough programming application that provides a front-end function for your application. It is the only program that lets you generate query reports in HTML from your database and design your own report page. With Dynamic Report, you can easily build an interactive application or website and better communicate your trade.

Automatic code generation
Using Dynamic Report is as easy as using WYSIWIG software. You don’t have to weave pa**ges** of code to control the design – simply enter your preferences in the program’s form fields, and Dynamic Report will generate the code for you. This way, all you have to worry about is maintaining your database in the backend.

Dynamic Report gives you full control over your report’s design, from the title text to the object captions. Add in graphics such as your company logo, a background image, or page and table borders. You even have the option to show the grouping data, group navigator, and data summaries.

Language support
Dynamic Report recognizes major Eastern languages, so your users can view their results in their native language. There’s no need to code in special characters, either – the program automatically adjusts the orientation and alignment to accommodate foreign type.

Runs on any application
You can easily integrate Dynamic Report into your project coding software. It works with all COM-based applications including Visual Basic, Visual basic C++, Delphi, and Borland C++.  Even a fully customized report generator takes up only a few lines of code, unlike other add-ons which you have to code in at every page.

Easy installation and setup
You do not need to be an advanced programmer in order to install and fully use Dynamic Report. Its setup program automatically registers the Dc\_DynamicReport10.dll file on your system. To integrate it into your project, simply select 'add reference' from the project menu.  Click the 'browse' button to locate your DC\_DynamicReport35.dll file.


**Features**
DC DynamicReport comes with a lot of functions that enables you get a full control of your report
just define few lines of code and get it works. That is all !!

**Example:**

Dim connetionString As String
Dim connection As SqlConnection
Dim command As SqlCommand
Dim adapter As New SqlDataAdapter
Dim sql As String
Dim oRep As New DynamicComponents.DynamicReport()

connetionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\nWindSQL.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

' you should order your data by the field you are willing to groub by
sql = "select \* from OrderDetails\_Query order by OrderID"
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

' initReport method should be your first assignment // False means left2right orientation
Dim oRep As New DynamicComponents.DynamicReport()
oRep.[initReport](#chmtopic8)(ds, False)

oRep.[setTitle](#chmtopic10)("Orders Report")
oRep.setReportHeader("This is Dynamic Report v3.5", "Powered by EgyFirst Software, Inc.")

oRep.[groubBy](#chmtopic12)("OrderID", "Order Id")

' Use setCaption to put proper caption for dataset fields names, 
'otherwise fields names will be used as caption by default
oRep.[setCaption](#chmtopic14)("Order ID", "Product ID", "Product Name", "Unit Price", "Quantity", "Value", "Discount %", "Discount", "Net Value")

' Fields to show summation
oRep.[sumFields](#chmtopic13)("Quantity", "Value", "DiscountValue", "NetValue")

'Set style name. True means show alternating color rows.
oRep.[useStyle](#chmtopic9)(ComboBox1.Text, True)
oRep.setReportFooter("This is your report footer Section", "you can add here as many lines as you want")

' generateReport method should be your last assignment
oRep.[generateReport](#chmtopic15)("Sales", Application.StartupPath + "\")

MsgBox("Report has been generated at " + Application.StartupPath + "\" + "Sales.xml" + vbCrLf + "Please open it using any browser i.e. Interent Explorer or Mozilla Firfox.")


' Load report automatically using internet explorer
Start("IExplore.exe", Application.StartupPath + "\Sales.xml") 


**System Requirements**
DC.DynamicReport runs as a COM class for included in any developing langauge support COM based application as  Visual Basic , Visual C++ , Borland C++ , Delphi  and others ..
**Installing DC.DynamicReport**
The DC.DynamicReport setup program will automatically register the DC\_DynamicReport35.dll file on your system. 

There is no need to manually run RegSvr32.exe on your development system. 
**Including DC.DynamicReport**
-----
To include DC.DynamicReport in your project  

1. From Project menu select add reference 
1. Push Browse button to locate your DC\_DynamicReport35.DLL file, now the specific DLL included in your references

**Deploying DC.DynamicReport**
Files need to be distributed with DC DynamicReport COM based applications

-DC\_Dynamic Report35.dll
-CSS Files(plain.css, red.css, blue.css, brown.css, green.css, grey.css and pink.css)


**InitReport Function**
InitReport Function, should be your first assignment , an error may occur if you do not. We support eastern languages in all of our components, so Dynamic Report comes with support for right to left orientation. You should order your data by the field you are willing to groub by. 

**Syntax:**
Public Sub initReport(ByRef ReportTable As DataSet, ByVal Right2Left As Boolean)


It takes 1 parameter
1- Your data recordset (SQL Statment) as dataset

2-Right2Left defines orientation, if true it will be Right2Left, while False means Left2Right (Default State)


**Example:** 

Dim connetionString As String
Dim connection As SqlConnection
Dim command As SqlCommand
Dim adapter As New SqlDataAdapter
Dim sql As String
Dim oRep As New DynamicComponents.DynamicReport()

connetionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\nWindSQL.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

' you should order your data by the field you are willing to groub by
sql = "select \* from OrderDetails\_Query order by OrderID"
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


oRep.initReport(ds, False)





**useStyle Function**
useStyle function enables you to set your report theme using predefinded css files.

**Syntax:**
Public Sub useStyle(ByVal str\_Style As String, ByVal AllternateRow As Boolean)
it takes 2  parameters 

1- str\_Style: The style name

2- AllternateRow: If true then an allternating color rows appea.

**Example:**
Dim oRep As New DynamicComponents.DynamicReport()

oRep.useStyle("grey.css", True)







**SetTitle Function**
SetTitle enables you set the title of the report

**Syntax:**
Public Sub setTitle(ByVal str\_Title As String)


**Example:**
Dim oRep As New DynamicComponents.DynamicReport()

oRep.setTitle("Orders Report")







**SetReportHeader Function**
SetReportHeader enables you set your report header lines , you can add as many lines as you want

**Syntax:**
Public Sub setReportHeader(ByVal ParamArray str\_Lines() As String)
It takes a  parameter array, so you can add as many header line as you want , delimetered by comma ","

**Example:**
Dim oRep As New DynamicComponents.DynamicReport()

oRep.setReportHeader("This is Dynamic Report v3.5", "Powered by EgyFirst Software, Inc.")





**GroupBy Function**
GroupBy function enables you set grouping data, you can add as many lines as you want. Use setCaption to put proper caption for dataset fields names, otherwise fields names will be used as caption by default.

**Syntax:**
Public Sub GroubBy(ByVal GroupField As String, ByVal GroupCaption As String)

It takes 2 parameters
1- GroupField parameter is the field used to grouping data
2- GroupCaption: The caption of grouping field


**Example:**
Dim oRep As New DynamicComponents.DynamicReport()

oRep.groubBy("OrderID", "Order Id")







**SumFields Function**
sumFields function enables you to sum defined fields** 

**Syntax:**

Public Sub sumFields(ByVal ParamArray str\_Line() As String)
It takes only one parameter
1- str\_Line  is a  parameter array , so you can add as many summed fields  as you want , delimetered by comma ","

**Example:** 

Dim oRep As New DynamicComponents.DynamicReport()

oRep.sumFields("Quantity", "Value", "DiscountValue", "NetValue") 




**SetCaption Function**
SetCaption  function enables you set caption for fields which may differ from its names
this mean a field named "ID" may get a new caption like "Customer ID"

**Syntax:**
Public Sub SetCaption(ByVal ParamArray str\_Line() As String)
it takes a  parameter array , so you can add as many caption as you want , delimetered by comma ","

**Example:**
Dim oRep As New DynamicComponents.DynamicReport()

oRep.setCaption("Order ID", "Product ID", "Product Name", "Unit Price", "Quantity", "Value", "Discount %", "Net Value")







**generateReport Function**
generateReport function is the function responsible for viewing report, so itshould be your last assignment after all report configuration methods.

**Syntax:**

Public Sub generateReport(ByVal ReportName As String, ByVal ReportPath As String)
it takes 2 parameters 

1- ReportName: Report name

2- ReportPath: Path to generated report



**Example:**


Dim connetionString As String
Dim connection As SqlConnection
Dim command As SqlCommand
Dim adapter As New SqlDataAdapter
Dim sql As String
Dim oRep As New DynamicComponents.DynamicReport()

connetionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\nWindSQL.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

' you should order your data by the field you are willing to groub by
sql = "select \* from OrderDetails\_Query order by OrderID"
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


oRep.initReport(ds, False)
oRep.setTitle("Orders Report")
oRep.setReportHeader("This is Dynamic Report v3.5", "Powered by EgyFirst Software, Inc.")
oRep.groubBy("OrderID", "Order Id")

` `oRep.useStyle(ComboBox1.Text, True)

oRep.generateReport("Sales", Application.StartupPath + "\")




**setRegistrationKey Function**
setRegistrationKey Function enables you to set your purchased serial number, to get a complete use of your software. if you deployed an application that use Dc DynamicREport without setting your registration key, this will result in an annoying popup screen.

**Syntax:**

Public Sub setRegistrationKey(ByVal myKey As String)

**Note:**

This function should be used immediately after your initiate your instance of DC ImageButton

**Example:**

Dim DR As New DynamicComponents.DynamicReport()

DR.setRegistrationKey("0000-000-000-000-0000") ' replace with your purchased serial number once you get one




# Tutorial
-----
This tutorial describe all  features supported by DC.DynamicReport

also you can refer to the project example which installed by default into C:\Program Files\Dynamic Components\Dynamic Report\Tutorials\

Dim connetionString As String
Dim connection As SqlConnection
Dim command As SqlCommand
Dim adapter As New SqlDataAdapter
Dim sql As String
Dim oRep As New DynamicComponents.DynamicReport()

connetionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\nWindSQL.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

' you should order your data by the field you are willing to groub by
sql = "select \* from OrderDetails\_Query order by OrderID"
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

' initReport method should be your first assignment // False means left2right orientation
Dim oRep As New DynamicComponents.DynamicReport()

oRep.setRegistrationKey("0000-000-000-000-0000") ' replace with your purchased serial number once you get one

oRep.[initReport](#chmtopic8)(ds, False)

oRep.[setTitle](#chmtopic10)("Orders Report")
oRep.setReportHeader("This is Dynamic Report v3.5", "Powered by EgyFirst Software, Inc.")

oRep.[groubBy](#chmtopic12)("OrderID", "Order Id")

' Use setCaption to put proper caption for dataset fields names, 
'otherwise fields names will be used as caption by default
oRep.[setCaption](#chmtopic14)("Order ID", "Product ID", "Product Name", "Unit Price", "Quantity", "Value", "Discount %", "Discount", "Net Value")

' Fields to show summation
oRep.[sumFields](#chmtopic13)("Quantity", "Value", "DiscountValue", "NetValue")

'Set style name. True means show alternating color rows.
oRep.[useStyle](#chmtopic9)(ComboBox1.Text, True)
oRep.setReportFooter("This is your report footer Section", "you can add here as many lines as you want")

' generateReport method should be your last assignment
oRep.[generateReport](#chmtopic15)("Sales", Application.StartupPath + "\")

MsgBox("Report has been generated at " + Application.StartupPath + "\" + "Sales.xml" + vbCrLf + "Please open it using any browser i.e. Interent Explorer or Mozilla Firfox.")


' Load report automatically using internet explorer
Start("IExplore.exe", Application.StartupPath + "\Sales.xml") 




**Contact me**
Company: EG1ST Software

Dynamic Components™ is trade mark ©2005-2021

Home Page: <https://zerobytes.one>

General Manager E-Mail <01@zerobytes.one>


# **License Agreement**
-----
