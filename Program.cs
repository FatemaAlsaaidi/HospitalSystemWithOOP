using System.Numerics;

namespace HospitalSystemWithOOP
{
        internal class Program
        {
            static void Main(string[] args)
            {
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
            private Doctor doctor;
            private Patient patient;
            private DateTime appointmentDate;

            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public Doctor Doctor { get => doctor; set => doctor = value; }
            public Patient Patient { get => patient; set => patient = value; }
            public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Appointment ID: {AppointmentId}, Doctor: {Doctor.Name}, Patient: {Patient.Name}, Date: {AppointmentDate:yyyy-MM-dd HH:mm}"); // Formatted date
            }
        }

        // Hospital class that manages all data
        public class Hospital
        {
            // Make lists instance members (non-static)
            private List<Patient> patients = new List<Patient>();
            private List<Doctor> doctors = new List<Doctor>();
            private List<Appointment> appointments = new List<Appointment>();

            // declare variables
            int tries = 0; // Variable to track the number of tries for patient ID input
            int Id; 
            string Name;
            int Age;



        // Method to add new patient
        public void AddNewPatient() // Removed static and parameter
            {
                Patient newPatient = new Patient();
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
                Console.Write("Enter Phone Number: ");
                newPatient.PhoneNumber = Console.ReadLine();
           
                newPatient.DisplayInfo();
                patients.Add(newPatient);
                Console.WriteLine("Patient added successfully!");
            }

            // Method to add new doctor
            public void AddNewDoctor() 
            {
                Doctor newDoctor = new Doctor();
                Console.Write("Enter Doctor ID: ");
                newDoctor.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Doctor Name: ");
                newDoctor.Name = Console.ReadLine();
                Console.Write("Enter Doctor Age: ");
                newDoctor.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select Specialization: ");
                Console.WriteLine("1. Cardiology");
                Console.WriteLine("2. Neurology");
                Console.WriteLine("3. Orthopedics");
                Console.Write("Enter choice (1-3): ");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine(); // To move to the next line after ReadKey
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

                newDoctor.DisplayInfo();
                doctors.Add(newDoctor);
                Console.WriteLine("Doctor added successfully!");
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
                Doctor selectedDoctor = doctors[doctorIndex - 1];

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
                Patient selectedPatient = patients[patientIndex - 1];

                Console.WriteLine($"\n--- Availability for Dr. {selectedDoctor.Name} ({selectedDoctor.Specialization}) ---");

                List<Appointment> doctorAppointments = appointments.Where(a => a.Doctor.Id == selectedDoctor.Id).ToList();
            if (doctorAppointments.Count == 0)
            {
                Console.WriteLine($"Dr. {selectedDoctor.Name} currently has no appointments booked. Likely fully available!");
            }
            else
            {
                Console.WriteLine($"Booked appointments Date and Time for Dr. {selectedDoctor.Name}:");
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
                    Doctor = selectedDoctor,
                    Patient = selectedPatient,
                    AppointmentDate = appointmentDate
                };
                appointments.Add(newAppointment);
                newAppointment.DisplayInfo();
                Console.WriteLine("Appointment booked successfully!");
            }
        }

            // Displaying all appointments for specific doctor
            public void DisplayingAllAppointments(int doctorId) 
            {
                Console.WriteLine($"\n--- Appointments for Doctor ID: {doctorId} ---");
                var doctorAppointments = appointments.Where(a => a.Doctor.Id == doctorId).ToList();

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
                var patientAppointments = appointments.Where(a => a.Patient.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase)).ToList();

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
