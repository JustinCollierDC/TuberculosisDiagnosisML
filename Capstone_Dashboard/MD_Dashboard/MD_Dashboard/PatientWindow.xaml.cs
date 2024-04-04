using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MD_Dashboard
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
        }

        # region Events

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveSymptoms();
        }

        private void btnSubmitForm_Click(object sender, RoutedEventArgs e)
        {
            // Perform validation on patient info...
            if(txtFirstName.Text == "" || txtFirstName.Text == String.Empty)
            {
                MessageBox.Show("ERROR: Please enter a valid first name.");
            }
            else if (txtLastName.Text == "" || txtLastName.Text == String.Empty)
            {
                MessageBox.Show("ERROR: Please enter a valid last name.");
            }
            else if (txtPhone.Text == "" || txtPhone.Text == String.Empty)
            {
                MessageBox.Show("ERROR: Please enter a valid phone number.");
            }
            else if (txtGender.Text == "" || txtGender.Text == String.Empty)
            {
                MessageBox.Show("ERROR: Please enter a valid gender.");
            }
            else
            {
                // Auto-Save currently selected symptoms
                saveSymptoms();

                //Prompt the user upon submit.
                if (MessageBox.Show("Are you sure you want to submit the saved symptoms?", "Exit Confirmation",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    bool checkFeverVal = false;
                    if (checkFever.IsChecked == true) { checkFeverVal = true; }
                    bool checkCoughBloodVal = false;
                    if (checkCoughBlood.IsChecked == true) { checkCoughBloodVal = true; }
                    bool checkNightSweatsVal = false;
                    if (checkNightSweats.IsChecked == true) { checkNightSweatsVal = true; }
                    bool checkBloodySputumVal = false;
                    if (checkBloodySputum.IsChecked == true) { checkBloodySputumVal = true; }
                    bool checkChestPainVal = false;
                    if (checkChestPain.IsChecked == true) { checkChestPainVal = true; }
                    bool checkBackPainVal = false;
                    if (checkBackPain.IsChecked == true) { checkBackPainVal = true; }
                    bool checkShortnessBreathVal = false;
                    if (checkShortnessBreath.IsChecked == true) { checkShortnessBreathVal = true; }
                    bool checkWeightLossVal = false;
                    if (checkWeightLoss.IsChecked == true) { checkWeightLossVal = true; }
                    bool checkTirednessVal = false;
                    if (checkTiredness.IsChecked == true) { checkTirednessVal = true; }
                    bool checkNeckLumpsVal = false;
                    if (checkNeckLumps.IsChecked == true) { checkNeckLumpsVal = true; }
                    bool checkCoughPhlegmVal = false;
                    if (checkCoughPhlegm.IsChecked == true) { checkCoughPhlegmVal = true; }
                    bool checkSwollenLymphVal = false;
                    if (checkSwollenLymph.IsChecked == true) { checkSwollenLymphVal = true; }
                    bool checkApetiteLossVal = false;
                    if (checkApetiteLoss.IsChecked == true) { checkApetiteLossVal = true; }

                    /*
                    // Call Parameterized Patient Constructor
                    Patient thisPatient = new Patient(10001, txtLastName.Text, txtFirstName.Text, txtPhone.Text, txtGender.Text, checkFeverVal, checkCoughBloodVal, checkNightSweatsVal, checkBloodySputumVal, checkChestPainVal,
                        checkBackPainVal, checkShortnessBreathVal, checkWeightLossVal, checkTirednessVal, checkNeckLumpsVal, checkCoughPhlegmVal, checkSwollenLymphVal, checkApetiteLossVal);
                    */

                    // Patient info is added into DB through the Patient Class.
                }
            }   
        }

        #endregion

        #region Methods

        private void saveSymptoms()
        {

            // Clear ListBox
            lbxPatients.Items.Clear();

            if (checkFever.IsChecked == false 
                && checkCoughBlood.IsChecked == false
                && checkNightSweats.IsChecked == false
                && checkBloodySputum.IsChecked == false
                && checkChestPain.IsChecked == false
                && checkBackPain.IsChecked == false
                && checkShortnessBreath.IsChecked == false
                && checkWeightLoss.IsChecked == false
                && checkTiredness.IsChecked == false
                && checkNeckLumps.IsChecked == false
                && checkCoughPhlegm.IsChecked == false
                && checkSwollenLymph.IsChecked == false
                && checkApetiteLoss.IsChecked == false)
            {
                lbxPatients.Items.Add("No Symptoms!!");
            }

            // Add Symptoms to listbox 
            // Symptom #01
            if (checkFever.IsChecked == true)
            {
                lbxPatients.Items.Add("Fever for 2+ Weeks");
            }
            // Symptom #02
            if (checkCoughBlood.IsChecked == true)
            {
                lbxPatients.Items.Add("Coughing Blood");
            }
            // Symptom #03
            if (checkNightSweats.IsChecked == true)
            {
                lbxPatients.Items.Add("Bloody Sputum");
            }
            // Symptom #04
            if (checkBloodySputum.IsChecked == true)
            {
                lbxPatients.Items.Add("Chest Pain");
            }
            // Symptom #05
            if (checkChestPain.IsChecked == true)
            {
                lbxPatients.Items.Add("Chest Pain");
            }
            // Symptom #06
            if (checkShortnessBreath.IsChecked == true)
            {
                lbxPatients.Items.Add("Shortness of Breath");
            }
            // Symptom #07
            if (checkWeightLoss.IsChecked == true)
            {
                lbxPatients.Items.Add("Recent Weight Loss");
            }
            // Symptom #08
            if (checkTiredness.IsChecked == true)
            {
                lbxPatients.Items.Add("Tiredness");
            }
            // Symptom #09
            if (checkNeckLumps.IsChecked == true)
            {
                lbxPatients.Items.Add("Lumps in pits of neck");
            }
            // Symptom #10
            if (checkCoughPhlegm.IsChecked == true)
            {
                lbxPatients.Items.Add("Cough producing Phlegm");
            }
            // Symptom #11
            if (checkSwollenLymph.IsChecked == true)
            {
                lbxPatients.Items.Add("Swollen Lymph Nodes");
            }
            // Symptom #12
            if (checkApetiteLoss.IsChecked == true)
            {
                lbxPatients.Items.Add("Loss of Apetite");
            }
            // Symptom #13
            if (checkBackPain.IsChecked == true)
            {
                lbxPatients.Items.Add("Back Pain");
            }
        }

        #endregion

        
    }
}
