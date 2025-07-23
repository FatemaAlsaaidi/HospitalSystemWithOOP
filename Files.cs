using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalSystemWithOOP
{
    class Files
    {
        // file to save doctore data 
        public static string DoctorFile = "doctors.txt";
        // file to save patient data
        public static string PatientFile = "patients.txt";
        // file to save appointment data
        public static string AppointmentFile = "appointments.txt";

        // save data of doctore in doctor file 
        public static void SaveDoctorToFile(List<Doctor> doctors)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(DoctorFile))
            {
                foreach (Doctor doctor in doctors)
                {
                    file.WriteLine($"{doctor.Id}, {doctor.Name}, {doctor.Age}, {doctor.Specialization}");
                }
            }
        }

        // Load data of doctor from file 
        public static void LoadDoctorFromFile()
        {
            int DoctorID = 0;   
           
            // Check if the file exists before reading
            if (System.IO.File.Exists(DoctorFile))
            {
                string[] lines = System.IO.File.ReadAllLines(DoctorFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {

                        // 1. Create a new doctor object using the overloaded constructor
                        Doctor loadedDoctor = new Doctor
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            Age = int.Parse(parts[2]),
                            Specialization = parts[3]

                        };
                        // 2. Add this new doctor object to the list
                        Hospital.doctors.Add(loadedDoctor);
                    }

   
                }
            }
        }
    }
}
