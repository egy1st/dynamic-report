[Setup]
#define DC_Path "Dynamic Components\Dynamic Report"  

AppName=DynamicComponents Dynamic Report v4.0
AppVerName=DC Dynamic Report v4.0
AppPublisher=EgyFirst Software, LLC.
AppPublisherURL=http://www.egy1st.com
AppSupportURL=support@egy1st.com
DefaultDirName={pf}\Dynamic Components\Dynamic Report\
DefaultGroupName=Dynamic Components\Dynamic Report\
LicenseFile=License.txt
OutputBaseFilename=dynamic_report
VersionInfoCompany=EgyFirst Software, LLC.
VersionInfoDescription=Dynamic Components Dynamic Report
VersionInfoVersion=4.0.0.0
InfoAfterFile=How to order.txt
RestartIfNeededByRun = True
WizardImageFile = Big02.bmp
WizardSmallImageFile=logo.bmp
BackColorDirection =toptobottom
BackColor = clBlue
BackColor2= clgreen
BackSolid=false
WindowStartMaximized=yes
WindowVisible=yes
WindowShowCaption=no
AppCopyright=EgyFirst Software 2005-2017 Copyright


[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked


[Files]
Source: "DC_DynamicReport40.dll"; DestDir: "{sys}"
Source: "DC_DynamicReport40.dll"; DestDir: "{app}"


; Application Files ////////////////////////////////////////////////////////
Source: "DC Dynamic Report v4.0.chm"; DestDir: "{app}"
Source: "License.txt"; DestDir: "{app}"
Source: "License Agreement.doc"; DestDir: "{app}"
Source: "egyfirst.url"; DestDir: "{app}"
Source: "Order Now.url"; DestDir: "{app}"


; Executable Demo ////////////////////////////////////////////////////////
Source: "DC_DynamicReport.exe"  ; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "DC_DynamicReport40.dll"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "nWind.accdb"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "nWindSQL.mdf"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "nWindSQL_log.ldf"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "blue.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "brown.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "green.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "grey.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "pink.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "plain.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"
Source: "red.css"; DestDir: "{userdocs}\{#DC_Path}\Demo"



; Visual Studio 2010 ////////////////////////////////////////////////////////
Source: "Tutorials\Visual Studio 2010\*.*"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\"
Source: "Tutorials\Visual Studio 2010\My Project\*.*"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\My Project"
Source: "DC_DynamicReport40.dll"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "nWind.accdb"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "nWindSQL.mdf"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "nWindSQL_log.ldf"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "blue.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "brown.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "green.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "grey.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "pink.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "plain.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "red.css"; DestDir: "{userdocs}\{#DC_Path}\Tutorials\Visual Studio 2010\bin\Debug"

;////////////////////////////////////////////////////////


[LangOptions]
LanguageName=English
LanguageID=$0409
DialogFontName=
DialogFontSize=8
WelcomeFontName=Verdana
WelcomeFontSize=12
TitleFontName=Arial
TitleFontSize=29
CopyrightFontName=Arial
CopyrightFontSize=10

[Icons]
Name: "{group}\Order Now"; Filename: "{app}\Order Now.url"
Name: "{group}\EgyFirst Software Homepage"; Filename: "{app}\egyfirst.url"
Name: "{group}\Help"; Filename: "{app}\DC Dynamic Report v4.0.chm"
Name: "{group}\Tutorials"; Filename: "{userdocs}\{#DC_Path}\Tutorials\"
Name: "{group}\Executable Demo"; Filename: "{userdocs}\{#DC_Path}\Demo\DC_DynamicReport.exe"
Name: "{group}\Uninstall DC Dynamic Report"; Filename: "{app}\unins000.exe"
Name: "{userdesktop}\Dynamic Report Files"; Filename: "{app}"; Tasks: desktopicon
Name: "{userdesktop}\Dynamic Report Projects"; Filename: "{userdocs}\{#DC_Path}"; Tasks: desktopicon

[Run]
; NOTE: The following entry contains an English phrase ("Launch"). You are free to translate it into another language if required.
Filename: "{userdocs}\{#DC_Path}\Demo\DC_DynamicReport.exe"; Description: "Executable Demo"; Flags: shellexec postinstall skipifsilent
Filename: "{userdocs}\{#DC_Path}\Tutorials\"; Description: "Tutorials"; Flags: shellexec postinstall skipifsilent
Filename: "{app}\DC Dynamic Report v4.0.chm"; Description: "Launch Help"; Flags: shellexec postinstall skipifsilent
;Filename: "{app}\egyfirst.url"; Description: "Visit Homepage"; Flags: shellexec postinstall skipifsilent
