using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    file.WriteLine($"{doctor.Id}, {doctor.Name}, {doctor.Specialization}");
                }
            }
        }
    }
}
