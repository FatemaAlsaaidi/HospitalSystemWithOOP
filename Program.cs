using System.Numerics;
using System.Collections.Generic;
namespace HospitalSystemWithOOP
{
        internal class Program
        {
            static void Main(string[] args)
            {

                // load doctor data from doctor file 
                Files.LoadDoctorFromFile();
                // Load Patient data from patient file 
                Files.LoadPatientFromFile();

                //Load Appointment data from Appoitnment file
                Files.LoadAppointmentsFromFile();
                // 1. Create an instance of the Hospital class
                Hospital hospital = new Hospital();

                bool MainMenu = true;
                while (MainMenu)
                {
                    Console.WriteLine("Welcome to the Hospital System");
                    Console.WriteLine("Please select an option (1-0): ");
                    Console.WriteLine("1. Add Patient");
                    Console.WriteLine("2. Add Doctor");
                    Console.WriteLine("3. Booking Appointment");
                    Console.WriteLine("4. Displaying all appointments for a specific doctor");
                    Console.WriteLine("5. Showing available doctors by specialization");
                    Console.WriteLine("6. Displaying all appointments for a specific patient name");
                    Console.WriteLine("0. Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            // Call the instance method on the hospital object
                            hospital.AddNewPatient();
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 2:
                            // Call the instance method on the hospital object
                            hospital.AddNewDoctor();
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 3:
                            // Call the instance method on the hospital object
                            hospital.BookAppointment();
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter the doctor ID to display appointments for: ");
                            int doctorId = Convert.ToInt32(Console.ReadLine());
                            // Call the instance method on the hospital object
                            hospital.DisplayingAllAppointments(doctorId);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Available Specializations:");
                            Console.WriteLine("1. Cardiology");
                            Console.WriteLine("2. Neurology");
                            Console.WriteLine("3. Orthopedics");
                            Console.Write("Enter specialization (e.g., Cardiology): ");
                            string choiceNum = Console.ReadLine();
                            string specialization = string.Empty;
                            if (choiceNum == "1")
                            {
                                specialization = "Cardiology";
                            }
                            else if (choiceNum == "2")
                            {
                                specialization = "Neurology";
                            }
                            else if (choiceNum == "3")
                            {
                                specialization = "Orthopedics";
                            }
                            else
                            {
                                Console.WriteLine("Invalid specialization choice. Please try again.");
                                continue; // Skip to the next iteration of the loop
                            }
                            // Call the instance method on the hospital object
                            hospital.ShowingAvailableDoctorsBySpecialization(specialization);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Enter the patient name to display appointments for: ");
                            string patientName = Console.ReadLine();
                            // Call the instance method on the hospital object
                            hospital.DisplayingAllAppointmentsForPatient(patientName);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        case 0:
                            MainMenu = false;
                            Console.WriteLine("Exiting Hospital System. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }

        // Create Person Class
        public class Person
        {
            //  private fields
            private int id;
            private string name;
            private int age;

            // properties
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            // virtual method to display person details
            public virtual void DisplayInfo()
            {
                //Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
            }

        }
        // Create Patient Class that inherits from Person
        public class Patient : Person
        {
            // public feild
            public string PhoneNumber { get; set; }
            // override DisplayInfo method
            public override void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Phone: {PhoneNumber}");
            }
        }

        // Create Doctor Class that inherits from Person
        public class Doctor : Person
        {
            // private fields
            private string specialization;

            // properties
            public string Specialization
            {
                get { return specialization; }
                set { specialization = value; }
            }

            // override DisplayInfo method
            public override void DisplayInfo()
            {
                Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Specialization: {specialization}"); // Corrected to display specialization
            }
        }

        // Appointment class
        public class Appointment
        {
            private int appointmentId;
            private string doctorName;
            private string patientName;
            private DateTime appointmentDate;

            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public string DoctorName { get => doctorName; set => doctorName = value; }
            public string PatientName { get => patientName; set => patientName = value;}
            public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Appointment ID: {AppointmentId}, Doctor: {DoctorName}, Patient: {PatientName}, Date: {AppointmentDate:yyyy-MM-dd HH:mm}"); // Formatted date
            }
        }

        // Hospital class that manages all data
        public class Hospital
        {
            // Make lists instance members (non-static)
            public static List<Patient> patients = new List<Patient>();
            public static List<Doctor> doctors = new List<Doctor>();
            public static List<Appointment> appointments = new List<Appointment>();

            



        // Method to add new patient
        public void AddNewPatient() // Removed static and parameter
        {
            Patient newPatient = new Patient();

            // declare variables
            int tries = 0; // Variable to track the number of tries for patient ID input
            int Id;
            string Name;
            int Age;
            string PhoneNumber;
            try
            {
                do
                {
                    Console.Write("Enter Patient ID: ");
                    Id = Convert.ToInt32(Console.ReadLine());
                    if(Id <= 0 )
                    {
                        Console.WriteLine("Patient ID must be a positive integer. Please try again.");
                        tries++; // Increment the number of tries

                    }
                    
                    else
                    {
                        newPatient.Id = Id; // Assign valid ID to the new patient
                        tries = 0; // Reset tries for the next input
                    }
                } while (Id <= 0 && tries < 3); // Ensure ID is positive
                if (tries >= 3)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting patient addition.");
                    return; // Exit the method if too many invalid attempts
                }
                

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for Patient ID. Please enter a valid integer.");
                return; // Exit the method if input is invalid
            }
            try
            {
                // Loop until a valid name is entered
                do
                {
                    Console.Write("Enter Patient Name: ");
                    Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Name)) // Check for empty or whitespace input
                    {
                        Console.WriteLine("Patient Name cannot be empty or whitespace.");
                        tries++; // Increment the number of trie
                    }
                    else
                    {


                        newPatient.Name = Name; // Assign valid name to the new patient
                        tries = 0; // Reset tries if input is valid

                    }
                } while (string.IsNullOrWhiteSpace(Name) && tries < 3); // Ensure name is not empty or whitespace
                if (tries >= 3)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting patient addition.");
                    return; // Exit the method if too many invalid attempts
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input for Patient Name. Please enter a valid string.");
            }
            try
            {
                do
                {
                    Console.Write("Enter Patient Age: ");
                    Age = Convert.ToInt32(Console.ReadLine());
                    if (Age <= 0)
                    {
                        Console.WriteLine("Patient Age must be a positive integer. Please try again.");
                        tries++; // Increment the number of tries
                    }
                    else
                    {
                        newPatient.Age = Age; // Assign valid age to the new patient
                        tries = 0; // Reset tries for the next input
                    }
                } while (Age <= 0 && tries < 3); // Ensure age is positive
                if (tries >= 3)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting patient addition.");
                    return; // Exit the method if too many invalid attempts
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for Patient Age. Please enter a valid integer.");
                return; // Exit the method if input is invalid
            }
            try
            {
                do
                {
                    Console.Write("Enter Phone Number: ");
                    PhoneNumber = Console.ReadLine();
                    if (PhoneNumber == null)
                    {
                        Console.WriteLine("Phone Number cannot be null. Please enter a valid string.");
                    }
                    else if (PhoneNumber.Length != 8)
                    {
                        Console.WriteLine("Phone Number must be 8 characters long. Please try again.");
                        tries++; // Increment the number of tries
                    }
                    else
                    {
                        newPatient.PhoneNumber = PhoneNumber; // Assign valid phone number to the new patient
                        tries = 0; // Reset tries for the next input


                    }
                } while (PhoneNumber == null || PhoneNumber.Length != 8 && tries < 3); // Ensure phone number is not null and has exactly 8 characters
                if (tries >= 3)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting patient addition.");
                    return; // Exit the method if too many invalid attempts
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for Phone Number. Please enter a valid string.");
            }
           
                newPatient.DisplayInfo();
                patients.Add(newPatient);
                Files.SavePatientToFile(patients);
                Console.WriteLine("Patient added successfully!");
        }

        // Method to add new doctor
        public void AddNewDoctor() 
        {
            Doctor newDoctor = new Doctor(); 
            // declare variables
            int id = 0;
            string name = string.Empty;
            int age = 0;
            string specialization = string.Empty; // Specialization variable

            // Variable to track the number of tries for doctor ID input
            int tries = 0; // Variable to track the number of tries for doctor ID input
            do
            {
                try
                {
                    Console.Write("Enter Doctor ID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    if (id <= 0)
                    {
                        Console.WriteLine("Doctor ID must be a positive integer. Please try again.");
                        tries++; // Increment the number of tries
                    }
                    else
                    {
                        newDoctor.Id = id; // Assign valid ID to the new doctor
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for Doctor ID. Please enter a valid integer.");
                    tries++; // Increment the number of tries
                }
            } while (id <= 0 && tries < 3); // Ensure ID is positive
            if (tries >= 3)
            {
                Console.WriteLine("Too many invalid attempts. Exiting doctor addition.");
                return; // Exit the method if too many invalid attempts
            }
            // Loop until a valid name is entered
            tries = 0; // Reset tries for the next input
            do
            {
                Console.Write("Enter Doctor Name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) // Check for empty or whitespace input
                {
                    Console.WriteLine("Doctor Name cannot be empty or whitespace.");
                    tries++; // Increment the number of tries
                }
                else
                {
                    newDoctor.Name = name; // Assign valid name to the new doctor
                }
            } while (string.IsNullOrWhiteSpace(name) && tries < 3); // Ensure name is not empty or whitespace
            if (tries >= 3)
            {
                Console.WriteLine("Too many invalid attempts. Exiting doctor addition.");
                return; // Exit the method if too many invalid attempts
            }
            tries = 0;
            // Loop until a valid age is entered
            do
            {
                try
                {
                    Console.Write("Enter Doctor Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age <= 0)
                    {
                        Console.WriteLine("Doctor Age must be a positive integer. Please try again.");
                        tries++; // Increment the number of tries
                    }
                    else
                    {
                        newDoctor.Age = age; // Assign valid age to the new doctor
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for Doctor Age. Please enter a valid integer.");
                    tries++; // Increment the number of tries
                }
            } while (age <= 0 && tries < 3); // Ensure age is positive
            if (tries >= 3)
            {
                Console.WriteLine("Too many invalid attempts. Exiting doctor addition.");
                return; // Exit the method if too many invalid attempts
            }
            do
            {
                try
                {
                    Console.WriteLine("Select Specialization: ");
                    Console.WriteLine("1. Cardiology");
                    Console.WriteLine("2. Neurology");
                    Console.WriteLine("3. Orthopedics");
                    Console.Write("Enter choice (1-3): ");

                    char choice = Console.ReadKey().KeyChar;
                    if (choice < '1' || choice > '3')
                    {
                        Console.WriteLine("\nInvalid choice. Please select a valid specialization.");
                        tries++; // Increment the number of tries
                        continue; // Skip to the next iteration of the loop
                    }
                    else
                    {
                        switch (choice)
                        {
                            case '1':
                                newDoctor.Specialization = "Cardiology";
                                break;
                            case '2':
                                newDoctor.Specialization = "Neurology";
                                break;
                            case '3':
                                newDoctor.Specialization = "Orthopedics";
                                break;
                            default:
                                Console.WriteLine("Invalid specialization choice, defaulting to General.");
                                newDoctor.Specialization = "General";
                                break;
                        }
                    }
 
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for Doctor Specialization. Please enter a valid string.");
                    tries++; // Increment the number of tries
                }
                
                newDoctor.DisplayInfo();
                doctors.Add(newDoctor);
                Files.SaveDoctorToFile(doctors);
                Console.WriteLine("Doctor added successfully!");

            } while (string.IsNullOrWhiteSpace(newDoctor.Specialization) && tries < 3); // Ensure specialization is not empty or whitespace
                if (tries >= 3)
                {
                    Console.WriteLine("Too many invalid attempts. Exiting doctor addition.");
                    return; // Exit the method if too many invalid attempts
                }
        }

        // Booking an appointment (select doctor and patient from lists)
        public void BookAppointment() 
        {
            if (doctors.Count == 0 || patients.Count == 0)
            {
                Console.WriteLine("No doctors or patients available for booking. Please add them first.");
                return;
            }

            Console.WriteLine("\n--- Available Doctors ---");
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {doctors[i].Name} (ID: {doctors[i].Id}) - {doctors[i].Specialization}");
            }
            Console.Write("Select a Doctor by number: ");
            int doctorIndex;
            while (!int.TryParse(Console.ReadLine(), out doctorIndex) || doctorIndex < 1 || doctorIndex > doctors.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid doctor number.");
                Console.Write("Select a Doctor by number: ");
            }
            string selectedDoctor = doctors[doctorIndex - 1].Name;

            Console.WriteLine("\n--- Available Patients ---");
            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {patients[i].Name} (ID: {patients[i].Id})");
            }
            Console.Write("Select a Patient by number: ");
            int patientIndex;
            while (!int.TryParse(Console.ReadLine(), out patientIndex) || patientIndex < 1 || patientIndex > patients.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid patient number.");
                Console.Write("Select a Patient by number: ");
            }
            string selectedPatient = patients[patientIndex - 1].Name;

            Console.WriteLine($"\n--- Availability for Dr. {selectedDoctor} ({doctors[doctorIndex - 1].Specialization}) ---");

            List<Appointment> doctorAppointments = appointments.Where(a => a.DoctorName== selectedDoctor).ToList();
        if (doctorAppointments.Count == 0)
        {
            Console.WriteLine($"Dr. {selectedDoctor} currently has no appointments booked. Likely fully available!");
        }
        else
        {
            Console.WriteLine($"Booked appointments Date and Time for Dr. {selectedDoctor}:");
            foreach (var appt in doctorAppointments.OrderBy(a => a.AppointmentDate)) // Order by date for better readability
            {
                Console.WriteLine($"- {appt.AppointmentDate:yyyy-MM-dd HH:mm}"); // Format the date nicely
            }
            Console.WriteLine("Please choose an appointment date and time that doesn't conflict with the above.");
        }

        // Enter the date and time of appointment
        Console.Write("Enter Appointment Date and Time (YYYY-MM-DD HH:mm): ");
        DateTime appointmentDate;
        while (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
        {
            Console.WriteLine("Invalid date and time format. Please enter a valid date and time (YYYY-MM-DD HH:mm):");
            Console.Write("Enter Appointment Date and Time (YYYY-MM-DD HH:mm): ");
        }

        // Corrected conflict check: Check if any existing doctor appointment has the same date
        if (doctorAppointments.Any(appt => appt.AppointmentDate == appointmentDate))
        {
            Console.WriteLine("This appointment time is already booked for this doctor. Please choose a different time.");
            return;
        }
        else
        {
            Appointment newAppointment = new Appointment
            {
                AppointmentId = appointments.Count > 0 ? appointments.Max(a => a.AppointmentId) + 1 : 1, // Ensure unique ID
                DoctorName = selectedDoctor,
                PatientName = selectedPatient,
                AppointmentDate = appointmentDate
            };
            appointments.Add(newAppointment);
            Files.SaveAppointmentToFile(appointments);
            newAppointment.DisplayInfo();
            Console.WriteLine("Appointment booked successfully!");
        }
    }

        // Displaying all appointments for specific doctor
        public void DisplayingAllAppointments(int doctorId) 
        {
            int index = 0;
            Console.WriteLine($"\n--- Appointments for Doctor ID: {doctorId} ---");
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == doctorId)
                {
                    index = i;
                }
            }
                
            var doctorAppointments = appointments.Where(a => a.DoctorName == doctors[index].Name).ToList();

            if (doctorAppointments.Any())
            {
                foreach (var appointment in doctorAppointments.OrderBy(a => a.AppointmentDate))
                {
                    appointment.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine($"No appointments found for Doctor ID: {doctorId}");
            }
        }

        // Displaying all appointments for specific patient name
        public void DisplayingAllAppointmentsForPatient(string patientName) 
        {
            Console.WriteLine($"\n--- Appointments for Patient: {patientName} ---");
            var patientAppointments = appointments.Where(a => a.PatientName.Equals(patientName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (patientAppointments.Any())
            {
                foreach (var appointment in patientAppointments.OrderBy(a => a.AppointmentDate))
                {
                    appointment.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine($"No appointments found for patient: {patientName}");
            }
        }

        // Showing available doctors by specialization
        public void ShowingAvailableDoctorsBySpecialization(string specialization) 
        {
            bool found = true;
            Console.WriteLine($"\n--- Doctors with specialization in {specialization}: ---");
            //var filteredDoctors = doctors.Where(d => d.Specialization .Equals(specialization, StringComparison.OrdinalIgnoreCase)).ToList();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Specialization == specialization)
                {
                    doctors[i].DisplayInfo(); // Calls the overridden DisplayInfo in Doctor class
                    found = true;
                }
                else
                {
                    found = false;
                }
            }


            if (found == false)
            {
                Console.WriteLine($"No doctors found with specialization: {specialization}");
            }
        }
            
    }
    

}
