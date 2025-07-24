Imports System.Windows
Imports DevExpress.Xpf.Core

Namespace SlideViewSample

    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>
    Public Partial Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            ThemeManager.ApplicationThemeName = Theme.Office2013Name
            MyBase.OnStartup(e)
        End Sub
    End Class
End Namespace
