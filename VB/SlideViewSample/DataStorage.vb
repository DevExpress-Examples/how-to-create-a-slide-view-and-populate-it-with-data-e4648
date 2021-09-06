Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Media.Imaging
Imports System.Xml.Serialization

Namespace SlideViewSample
	<XmlRoot("Employees")>
	Public Class Employees
		Inherits List(Of Employee)

	End Class
	<XmlRoot("Employee")>
	Public Class Employee
		Public Property Id() As Integer
		Public Property ParentId() As Integer
		Public Property FirstName() As String
		Public Property LastName() As String
		Public ReadOnly Property FullName() As String
			Get
				Return FirstName & " " & LastName
			End Get
		End Property
		Public Property JobTitle() As String
		Public Property Phone() As String
		Public Property EmailAddress() As String
		Public Property AddressLine1() As String
		Public Property City() As String
		Public Property PostalCode() As String
		Public Property CountryRegionName() As String
		Public Property GroupName() As String
		Public Property BirthDate() As DateTime
		Public Property HireDate() As DateTime
		Public Property Gender() As String
		Public Property MaritalStatus() As String
		Public Property Title() As String
		Public Property ImageData() As Byte()
		Private imageSource As BitmapImage
		<XmlIgnore>
		Public ReadOnly Property Photo() As BitmapImage
			Get
				If imageSource Is Nothing Then
					SetImageSource()
				End If
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
'INSTANT VB NOTE: The field employees was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private employees_Conflict As Employees
		Public ReadOnly Property Employees() As Employees
			Get
				If employees_Conflict Is Nothing Then
					Dim stream = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("Employees.xml")
					Dim serializier As New XmlSerializer(GetType(Employees))
					employees_Conflict = TryCast(serializier.Deserialize(stream), Employees)
				End If
				Return employees_Conflict
			End Get
		End Property
	End Module
	Public Class EmployeesData
		Public ReadOnly Property DataSource() As Employees
			Get
				Return DataStorage.Employees
			End Get
		End Property
	End Class
End Namespace
