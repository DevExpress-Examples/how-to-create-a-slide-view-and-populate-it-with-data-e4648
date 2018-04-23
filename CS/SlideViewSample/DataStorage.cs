
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace SlideViewSample {
    [XmlRoot("Employees")]
    public class Employees : List<Employee> {
    }
    [XmlRoot("Employee")]
    public class Employee {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        public string GroupName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        BitmapImage imageSource;
        [XmlIgnore]
        public BitmapImage Photo {
            get {
                if(imageSource == null)
                    SetImageSource();
                return imageSource;
            }
        }
        void SetImageSource() {
            var stream = new MemoryStream(ImageData);
            imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = stream;
            imageSource.EndInit();
        }
    }

    public static class DataStorage {
        static Employees employees;
        public static Employees Employees {
            get {
                if(employees == null) {
                    var stream = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("SlideViewSample.Employees.xml");
                    XmlSerializer serializier = new XmlSerializer(typeof(Employees));
                    employees = serializier.Deserialize(stream) as Employees;
                }
                return employees;
            }
        }
    }
    public class EmployeesData {
        public Employees DataSource {
            get { return DataStorage.Employees; }
        }
    }
}
