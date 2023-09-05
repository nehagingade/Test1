using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Test1
{
    [Serializable]
    class Program
    {

        public class Patient
        {
            public int PatientNo { get; set; }
            public string PatientName { get; set; }
            public string DoctorName { get; set; }
            public DateTime AppointmentDate { get; set; } = DateTime.Now;

            public Patient() { }
            public Patient(int PatientNo, string PatientName, string DoctorName)
            {
                this.PatientNo = PatientNo;
                this.PatientName = PatientName;
                //this.billAmount = billAmount;
                this.DoctorName = DoctorName;
            }



            internal void DeepCopy(Patient pat)
            {
                throw new NotImplementedException();
            }


            class PatientCollection
            {
                private static Patient[] _patList = new Patient[100];
                private Patient deepCopy(Patient pat)
                {
                    Patient temp = new Patient();
                    temp.PatientNo = pat.PatientNo;
                    temp.PatientName = pat.PatientName;
                    temp.DoctorName = pat.DoctorName;
                    return temp;
                }

            }



            private static void serialization()
            {
                Patient rec = CreateRecord();
                string fileLocation = "Temp.Bin";
                FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter fm = new BinaryFormatter();
                fm.Serialize(fs, rec);
                fs.Close();
            }

            private static void xmlSerialization()
            {
                Patient rec = CreateRecord();
                FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
                XmlSerializer fm = new XmlSerializer(typeof(Patient));
                fm.Serialize(fs, rec);
                fs.Close();
            }

            private static Patient CreateRecord()
            {
                int PatientNo = 123;
                string Patientname = "Neha";
                string DoctorName = "Dhanvantri";
                DateTime rec = DateTime.Now.AddDays(-146);

                return new Patient
                {
                    PatientName = Patientname,
                    PatientNo = PatientNo,
                    DoctorName = DoctorName,
                    AppointmentDate = rec
                };
            }

        static void Main(string[] args)
            {
                serialization();
                xmlSerialization();
                //switch (opt)
                //{
                //    case "Add":
                //        PatientCollection.AddingPatient();
                //        break;
                //case "Update":
                //    PatientCollection.UpdatePatient();
                //    break;
                //case "Delete":
                //    PatientCollection.DeletePatient();
                //    break;
                //case "Find":
                //    PatientCollection.FindPatient();
                //    break;

                //            default:
                //                condition = false;
                //                break;
                //        }
                //    } while (condition);
                //}
            }
        }
    }
}
