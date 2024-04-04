using System;
using System.Collections.Generic;
using System.Configuration;              // ConnectionStringSettings
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

using System.Data.SqlClient; // This may work or not depending on local versions.
                             // See this StackOverflow answer: https://stackoverflow.com/a/54472192

// Install via project->Manage Nuget Packages --> Select 'Data.SqlClient' & install.

namespace MD_Dashboard
{
    internal class PatientDb : PatientList
    {
        /// <summary>
        /// FUNCTION: Returns the connection string.
        /// </summary>
        /// <returns>Connection string</returns>
        private static string GetConnectionString()
        {
            string returnValue = null;

            // Look for myConnectionString in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[1];

            // If found, return the connection string.
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            // If not found return the null value.
            return returnValue;
        }

        /// <summary>
        /// FUNCTION. Returns a list containing all patients currently stored in the database.
        /// </summary>
        internal static new List<Patient> AllPatients   // Overrides PatientList Class' Method
        {
            get
            {
                // List of Patient objects.
                List<Patient> patientsFromDb = new List<Patient>();

                // Connect to the DB.
                using (var dbConnection = new SqlConnection(GetConnectionString()))
                {
                    // Selection Query.
                    string query = "SELECT * FROM [PatientTable]";
                    var command = new SqlCommand(query, dbConnection);
                    command.CommandType = CommandType.Text;
                    dbConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient newPatient = new Patient();    // Create a new Patient object

                                // Store Patient data in the object.
                                // Setting each property for the patient using the correct reader methods.
                                newPatient.PatientNumber = reader.GetInt32(0);      // Patient Number
                                newPatient.PatientLName = reader.GetString(1);      // Patient Last Name
                                newPatient.PatientLName = reader.GetString(2);      // Patient First Name
                                newPatient.PatientPhone = reader.GetString(3);      // Etc.
                                newPatient.PatientGender = reader.GetString(4);

                                newPatient.Symptom_01 = reader.GetBoolean(5);
                                newPatient.Symptom_02 = reader.GetBoolean(6);
                                newPatient.Symptom_03 = reader.GetBoolean(7);
                                newPatient.Symptom_04 = reader.GetBoolean(8);
                                newPatient.Symptom_05 = reader.GetBoolean(9);
                                newPatient.Symptom_06 = reader.GetBoolean(10);
                                newPatient.Symptom_07 = reader.GetBoolean(11);
                                newPatient.Symptom_08 = reader.GetBoolean(12);
                                newPatient.Symptom_09 = reader.GetBoolean(13);

                                patientsFromDb.Add(newPatient);
                            }
                        }
                    }
                }

                return patientsFromDb;   // Return the list of Patients.
            }
        }

        /// <summary>
        /// FUNCTION: Adds a patient object into the list.
        /// </summary>
        /// <param name="patient">A patient</param>
        /// <returns>true if successful, false if not</returns>
        internal static new bool Add(Patient patient)   // Overrides from PatientList
        {
            listOfPatients.Add(patient);  // Add the patient to the list.
            InsertIntoDb(patient);       // Also adds patient to the DB when called from PatientDb.

            return true;
        }

        // Find and return a patient
        public static Patient FindPatient(int patientNum)
        {
            Patient foundPatient = null;

            foreach (Patient p in AllPatients)
            {
                if (p.PatientNumber == patientNum)
                {
                    // Patient with ID found.
                    foundPatient = p;
                }
            }

            // Patient not found
            return foundPatient;
        }

        /// <summary>
        /// Function to add a new patient to the patient database
        /// </summary>
        /// <param name="insertPatient">a patient object to be inserted</param>
        /// <returns>true if successful</returns>
        private static bool InsertIntoDb(Patient insertPatient)
        {
            // Store the error state for this DB transaction.
            bool isError = false;
            Exception dbError = new Exception();
            // Create return value
            bool returnValue = false;

            try
            {
                // Declare the SQL connection
                SqlConnection dbConnection = new SqlConnection(GetConnectionString());

                // Create new SQL command and assign it paramaters
                SqlCommand command = new SqlCommand("INSERT INTO [PatientTable] VALUES(@patient_no, @patient_lname, @patient_fname, @patient_phone, @patient_gender," +
                    "@patient_symptom_01, @patient_symptom_02, @patient_symptom_03, @patient_symptom_04, @patient_symptom_05, @patient_symptom_06, @patient_symptom_07," +
                    "@patient_symptom_08, patient_symptom_09, patient_symptom_10, patient_symptom_11, patient_symptom_12, patient_symptom_13)", dbConnection);

                // Set the values for the parameters in the query above.
                command.Parameters.AddWithValue("@patient_no", insertPatient.PatientNumber);
                command.Parameters.AddWithValue("@patient_lname", insertPatient.PatientLName);
                command.Parameters.AddWithValue("@patient_lname", insertPatient.PatientFName);
                command.Parameters.AddWithValue("@patient_phone", insertPatient.PatientPhone);
                command.Parameters.AddWithValue("@patient_gender", insertPatient.PatientGender);

                command.Parameters.AddWithValue("@patient_symptom_01", insertPatient.Symptom_01);
                command.Parameters.AddWithValue("@patient_symptom_02", insertPatient.Symptom_02);
                command.Parameters.AddWithValue("@patient_symptom_03", insertPatient.Symptom_03);
                command.Parameters.AddWithValue("@patient_symptom_04", insertPatient.Symptom_04);
                command.Parameters.AddWithValue("@patient_symptom_05", insertPatient.Symptom_05);
                command.Parameters.AddWithValue("@patient_symptom_06", insertPatient.Symptom_06);
                command.Parameters.AddWithValue("@patient_symptom_07", insertPatient.Symptom_07);
                command.Parameters.AddWithValue("@patient_symptom_08", insertPatient.Symptom_08);
                command.Parameters.AddWithValue("@patient_symptom_09", insertPatient.Symptom_09);
                command.Parameters.AddWithValue("@patient_symptom_10", insertPatient.Symptom_10);
                command.Parameters.AddWithValue("@patient_symptom_11", insertPatient.Symptom_11);
                command.Parameters.AddWithValue("@patient_symptom_12", insertPatient.Symptom_12);
                command.Parameters.AddWithValue("@patient_symptom_13", insertPatient.Symptom_13);


                dbConnection.Open();
                returnValue = (command.ExecuteNonQuery() == 1);
                dbConnection.Close();
            }
            catch (Exception error)
            {
                isError = true;
                dbError = error;
            }
            if (isError)
            {
                throw dbError;
            }

            // Return the true if this worked, false if it failed
            return returnValue;
        }
    }

}
