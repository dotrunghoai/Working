Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports DevExpress.LookAndFeel

<System.ComponentModel.DesignerCategory("")>
Public Class LookAndFeelSettingsHelper
    Inherits Component

    Public Sub New()

        AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
    End Sub

    ' Fields...
    Private _FileName As String

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property FileName() As String
        Get
            If String.IsNullOrEmpty(_FileName) Then
                Return "LookAndFeelSettings.save"
            Else
                Return _FileName
            End If
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property


    Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        SaveSettings()
    End Sub


    Sub SaveSettings()
        Save(FileName)
    End Sub

    Sub RestoreSettings()
        Load(FileName)
    End Sub
    Public Shared Sub Save(ByVal fileName As String)
        Try
            Dim stream As FileStream
            Dim settings As LookAndFeelSettings
            Dim formatter As BinaryFormatter

            settings = New LookAndFeelSettings()
            settings.SkinName = UserLookAndFeel.Default.SkinName
            settings.ActiveSvgPaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName
            settings.Style = UserLookAndFeel.Default.Style
            settings.UseWindowsXPTheme = UserLookAndFeel.Default.UseWindowsXPTheme

            stream = New FileStream(fileName, FileMode.Create)
            Using stream
                formatter = New BinaryFormatter()
                formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                formatter.Serialize(stream, settings)
            End Using
        Catch ex As Exception
            ShowError(ex, "SaveSkin", "SettingSkin")
        End Try
    End Sub

    Public Shared Sub Load(ByVal fileName As String)
        If File.Exists(fileName) Then
            Try
                Using stream As New FileStream(fileName, FileMode.Open)
                    Dim formatter As New BinaryFormatter()
                    formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                    Dim settings As LookAndFeelSettings = TryCast(formatter.Deserialize(stream), LookAndFeelSettings)
                    If settings IsNot Nothing Then
                        UserLookAndFeel.Default.UseWindowsXPTheme = settings.UseWindowsXPTheme
                        UserLookAndFeel.Default.Style = settings.Style
                        UserLookAndFeel.Default.SkinName = settings.SkinName
                        If settings.ActiveSvgPaletteName <> "" Then
                            UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.ActiveSvgPaletteName)
                        End If
                    End If
                End Using
            Catch ex As Exception
                ShowError(ex, "LoadSkin", "SettingSkin")
            End Try
        End If
    End Sub
End Class
