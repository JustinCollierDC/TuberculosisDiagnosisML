#!/usr/bin/env python
# coding: utf-8

# Data Preprocessing
# 

# In[32]:


import pandas as pd

# Load the dataset from Excel file
file_path = "Tbdiseasesymptoms.csv"  # Update with your file path
data = pd.read_csv(file_path)

# 1. Convert 'date' and 'time' columns to datetime format
data['date'] = pd.to_datetime(data['date'])
data['time'] = pd.to_datetime(data['time'], format='%I:%M %p').dt.time

# 2. Check for missing values and handle them
missing_values = data.isnull().sum()
print("Missing values:\n", missing_values)

# Since there are no missing values, no further action is needed for handling missing values.

# 3. Convert categorical variables into numerical representations (One-hot encoding for 'gender')
data = pd.get_dummies(data, columns=['gender'], drop_first=True)

# 4. Normalize or scale numerical features if needed (Not required in this case since the features are binary)

# Display the preprocessed data
print("Preprocessed data:\n", data.head())


# Finding the accuracy of the different models
# 

# In[ ]:





# Tuberculosis present or not

# In[2]:


import pandas as pd

# Load the dataset
data = pd.read_csv('Tbdiseasesymptoms.csv')

# Define relevant symptoms for tuberculosis
tuberculosis_symptoms = ['fever for two weeks', 'coughing blood', 'night sweats', 'weight loss', 'chest pain',
                          'sputum mixed with blood', 'shortness of breath', 'body feels tired', 'lumps that appear around the armpits and neck',
                           'cough and phlegm continuously for two weeks to four weeks',
                          'swollen lymph nodes', 'loss of appetite', 'back pain in certain parts']

# Function to determine tuberculosis presence based on symptoms
def is_tuberculosis_present(row):
    tuberculosis_conditions = [
        (row['fever for two weeks'] == 1 and row['coughing blood'] == 1),
        (row['coughing blood'] == 1 and row['sputum mixed with blood'] == 1),
        (row['night sweats'] == 1 and row['chest pain'] == 1),
        (row['coughing blood'] == 1 and row['night sweats'] == 1),
        (row['weight loss'] == 1 and row['coughing blood'] == 1),
        (row['shortness of breath'] == 1 and row['coughing blood'] == 1),
        (row['chest pain'] == 1 and row['back pain in certain parts'] == 1),
        (row['night sweats'] == 1 and row['weight loss'] == 1),
        (row['lumps that appear around the armpits and neck'] == 1 and row['swollen lymph nodes'] == 1),
        (row['cough and phlegm continuously for two weeks to four weeks'] == 1 and row['swollen lymph nodes'] == 1),
        (row['cough and phlegm continuously for two weeks to four weeks'] == 1 and row['loss of appetite'] == 1)
    ]
    for condition in tuberculosis_conditions:
        if condition:
            return 1  # Tuberculosis present
    return 0  # Tuberculosis not present

# Create a new column indicating tuberculosis presence
data['Tuberculosis_present'] = data.apply(is_tuberculosis_present, axis=1)

# Save the modified dataset
data.to_csv('Tbdiseasesymptoms_with_tuberculosis.csv', index=False)



# logistic regression classifier
# 

# In[3]:


import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, classification_report

# Load the dataset
data = pd.read_csv('Tbdiseasesymptoms_with_tuberculosis.csv')

log_reg_model = LogisticRegression(max_iter=1000, C=0.1, penalty='l2')

# Define relevant symptoms for tuberculosis
tuberculosis_symptoms = [
    'fever for two weeks',
    'coughing blood',
    'sputum mixed with blood',
    'night sweats',
    'chest pain',
    'back pain in certain parts',
    'shortness of breath',
    'weight loss',
    'body feels tired',
    'lumps that appear around the armpits and neck',
    'cough and phlegm continuously for two weeks to four weeks',
    'swollen lymph nodes',
    'loss of appetite'
]

# Define features and target variable
X = data[tuberculosis_symptoms]  # Features
y = data['Tuberculosis_present']  # Target variable

# Split data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize logistic regression model
log_reg_model = LogisticRegression()

# Train the logistic regression model
log_reg_model.fit(X_train, y_train)

# Make predictions
y_pred = log_reg_model.predict(X_test)

# Evaluate the model
accuracy = accuracy_score(y_test, y_pred)
report = classification_report(y_test, y_pred)

print("Accuracy:", accuracy)
print("Classification Report:\n", report)


# Support Vector Machine (SVM) model

# In[4]:


import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.svm import SVC
from sklearn.metrics import accuracy_score, classification_report

# Load the dataset
data = pd.read_csv('Tbdiseasesymptoms_with_tuberculosis.csv')

# Define relevant symptoms for tuberculosis
tuberculosis_symptoms = [
    'fever for two weeks',
    'coughing blood',
    'sputum mixed with blood',
    'night sweats',
    'chest pain',
    'back pain in certain parts',
    'shortness of breath',
    'weight loss',
    'body feels tired',
    'lumps that appear around the armpits and neck',
    'cough and phlegm continuously for two weeks to four weeks',
    'swollen lymph nodes',
    'loss of appetite'
]

# Define features and target variable
X = data[tuberculosis_symptoms]  # Features
y = data['Tuberculosis_present']  # Target variable


# Split data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize SVM model
svm_model = SVC(kernel='linear')

# Train the SVM model
svm_model.fit(X_train, y_train)

# Make predictions
y_pred = svm_model.predict(X_test)

# Evaluate the model
accuracy = accuracy_score(y_test, y_pred)
report = classification_report(y_test, y_pred)

print("Accuracy:", accuracy)
print("Classification Report:\n", report)

