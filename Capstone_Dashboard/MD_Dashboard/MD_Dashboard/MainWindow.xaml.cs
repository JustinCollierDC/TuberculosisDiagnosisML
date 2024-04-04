// Created by: Justin Collier
// Date Created: March 7, 2024
// Purpose: This is the front-end applicarion for our Tuberculosis predictive diagnosis system. Patients will give their personal info and symptoms and it will be fed into our DB and ML algorithm.

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MD_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Form startup function
            InitializeForm();
        }

        #region Events
        /// <summary>
        /// EVENT: The 'Exit' button is pressed on the worker page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Prompt the user upon exit.
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();        //Closes the currently active window.
            }

        }

        /// <summary>
        /// EVENT: The Patient Dashboard is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatientClick(object sender, RoutedEventArgs e)
        {
            new PatientWindow().ShowDialog();
        }
        #endregion

        #region methods

        /// <summary>
        /// FUNCTION: Initialize all form variables so default values are present where neccesary.
        /// </summary>
        private void InitializeForm()
        {

        }

        #endregion
    }
}
