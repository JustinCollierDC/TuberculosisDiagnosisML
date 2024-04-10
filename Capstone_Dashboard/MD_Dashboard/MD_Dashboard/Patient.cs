using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Dashboard
{

    // Include the PatientDatabase class
    using Patients = PatientDb;          // 'Patient.FunctionName' can be used to access methods in PatientDatabase
                                         // to add/edit data within the patients list

    internal class Patient
    {

        #region Global Properties
        //Private variables
        private int patientNumber = 0;
        private string patientFName = String.Empty;
        private string patientLName = String.Empty;
        private string patientPhone = String.Empty;
        private string patientGender = String.Empty;

        // Symptom Flags (Private)
        private bool symptom_01 = false;
        private bool symptom_02 = false;
        private bool symptom_03 = false;
        private bool symptom_04 = false;
        private bool symptom_05 = false;
        private bool symptom_06 = false;
        private bool symptom_07 = false;
        private bool symptom_08 = false;
        private bool symptom_09 = false;
        private bool symptom_10 = false;
        private bool symptom_11 = false;
        private bool symptom_12 = false;
        private bool symptom_13 = false;

        //Class Constants
        internal const string NameParameter = "Patient Name";

        #endregion

        #region Properties
        public int PatientNumber { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        internal string PatientPhone { get; set; }
        public string PatientGender { get; set; }

        public bool Symptom_01 { get; set; }
        public bool Symptom_02 { get; set; }
        public bool Symptom_03 { get; set; }
        public bool Symptom_04 { get; set; }
        public bool Symptom_05 { get; set; }
        public bool Symptom_06 { get; set; }
        public bool Symptom_07 { get; set; }
        public bool Symptom_08 { get; set; }
        public bool Symptom_09 { get; set; }
        public bool Symptom_10 { get; set; }
        public bool Symptom_11 { get; set; }
        public bool Symptom_12 { get; set; }
        public bool Symptom_13 { get; set; }



        /// <summary>
        /// ACCESOR: Retrieves the list of workers from the data class.
        /// </summary>
        internal static List<Patient> List
        {
            get
            {
                return Patients.AllPatients;
            }
        }

        /// <summary>
        /// OVERRIDE: Displays the Patient object as a properly formatted string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PatientNumber + " - " + PatientFName + " " + PatientLName;
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal Patient()
        {
            PatientNumber = patientNumber;
            PatientLName = patientLName;
            PatientFName = patientFName;
            PatientPhone = patientPhone;
            PatientGender = patientGender;

            Symptom_01 = symptom_01;
            Symptom_02 = symptom_02;
            Symptom_03 = symptom_03;
            Symptom_04 = symptom_04;
            Symptom_05 = symptom_05;
            Symptom_06 = symptom_06;
            Symptom_07 = symptom_07;
            Symptom_08 = symptom_08;
            Symptom_09 = symptom_09;
            Symptom_10 = symptom_10;
            Symptom_11 = symptom_11;
            Symptom_12 = symptom_12;
            Symptom_13 = symptom_13;
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="workerName"></param>
        /// <param name="messagesSent"></param>
        /// <param name="workerPay"></param>
        internal Patient(int inputPatientNumber, string inputPatientLName, string inputPatientFName, string inputPatientPhone, string inputPatientGender, bool inputSymptom_01, bool inputSymptom_02,
            bool inputSymptom_03, bool inputSymptom_04, bool inputSymptom_05, bool inputSymptom_06, bool inputSymptom_07, bool inputSymptom_08, bool inputSymptom_09, bool inputSymptom_10, bool inputSymptom_11, 
            bool inputSymptom_12, bool inputSymptom_13)
        {
            // Setting properties
            PatientNumber = inputPatientNumber;
            PatientFName = inputPatientLName;
            PatientLName = inputPatientFName;
            PatientPhone = inputPatientPhone;
            PatientGender = inputPatientGender;
            Symptom_01 = inputSymptom_01;
            Symptom_02 = inputSymptom_02;
            Symptom_03 = inputSymptom_03;
            Symptom_04 = inputSymptom_04;
            Symptom_05 = inputSymptom_05;
            Symptom_06 = inputSymptom_06;
            Symptom_07 = inputSymptom_07;
            Symptom_08 = inputSymptom_08;
            Symptom_09 = inputSymptom_09;
            Symptom_10 = inputSymptom_10;
            Symptom_11 = inputSymptom_11;
            Symptom_12 = inputSymptom_12;
            Symptom_13 = inputSymptom_13;

            // Add the Patient into the list via the Data class.
            Patients.Add(this);
        }

        #endregion

        #region Custom Methods
        internal static void Initialize()
        {
            Patients.RefreshList();      // Refreshes the Database List.
        }

        public static void populateDB()
        {
            // Method to populate our patient DB with test values

            Patient testPatient1 = new Patient(10001, "Jackson", "Marcus", "289-123-9876", "Male", true, false, false, false, false, true, false, true, false, false, true, true, false);

        }

        #endregion

    }
}
