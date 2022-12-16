Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Xml.Serialization

Namespace SlideViewSample

    <XmlRoot("Employees")>
    Public Class Employees
        Inherits List(Of Employee)

    End Class

    <XmlRoot("Employee")>
    Public Class Employee

        Public Property Id As Integer

        Public Property ParentId As Integer

        Public Property FirstName As String

        Public Property LastName As String

        Public ReadOnly Property FullName As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property

        Public Property JobTitle As String

        Public Property Phone As String

        Public Property EmailAddress As String

        Public Property AddressLine1 As String

        Public Property City As String

        Public Property PostalCode As String

        Public Property CountryRegionName As String

        Public Property GroupName As String

        Public Property BirthDate As Date

        Public Property HireDate As Date

        Public Property Gender As String

        Public Property MaritalStatus As String

        Public Property Title As String

        Public Property ImageData As Byte()

        Private imageSource As BitmapImage

        <XmlIgnore>
        Public ReadOnly Property Photo As BitmapImage
            Get
                If imageSource Is Nothing Then SetImageSource()
                Return imageSource
            End Get
        End Property

        Private Sub SetImageSource()
            Dim stream = New MemoryStream(ImageData)
            imageSource = New BitmapImage()
            imageSource.BeginInit()
            imageSource.StreamSource = stream
            imageSource.EndInit()
        End Sub
    End Class

    Public Module DataStorage

        Private employeesField As Employees

        Public ReadOnly Property Employees As Employees
            Get
                If employeesField Is Nothing Then
                    Dim stream = Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("SlideViewSample.Employees.xml")
                    Dim serializier As XmlSerializer = New XmlSerializer(GetType(Employees))
                    employeesField = TryCast(serializier.Deserialize(stream), Employees)
                End If

                Return employeesField
            End Get
        End Property
    End Module

    Public Class EmployeesData

        Public ReadOnly Property DataSource As Employees
            Get
                Return DataStorage.Employees
            End Get
        End Property
    End Class
End Namespace
