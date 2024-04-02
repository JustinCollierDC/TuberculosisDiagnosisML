using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Dashboard
{
    class PatientList
    {

        protected static List<Patient> listOfPatients = new List<Patient>();     // Create a list of Patient objects.

        /// <summary>
        /// ACCESOR: Returns the patients list.
        /// </summary>
        protected internal static List<Patient> AllPatients
        {
            get
            {
                return listOfPatients;
            }
        }

        /// <summary>
        /// FUNCTION: Adds a patient object into the list.
        /// </summary>
        /// <param name="patient">A patient</param>
        /// <returns>true if successful, false if not</returns>
        protected virtual bool Add(Patient patient)
        {
            listOfPatients.Add(patient);  // Add the patient to the list.

            return true;
        }

        /// <summary>
        /// For some data storage methods, refreshing is important. This method is basically the same as access the list for this class though.
        /// </summary>
        /// <returns>List of patients</returns>
        protected internal static List<Patient> RefreshList()
        {
            return listOfPatients;
        }

    }
}
