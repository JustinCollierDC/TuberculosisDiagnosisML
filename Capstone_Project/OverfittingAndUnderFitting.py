import pandas as pd
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.linear_model import LogisticRegression
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
from sklearn.model_selection import cross_val_score


# Define features and target variable
X = data[tuberculosis_symptoms]  # Features
y = data['Tuberculosis_present']  # Target variable

# Split data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize logistic regression model
log_reg_model = LogisticRegression(max_iter=1000)

# Train the logistic regression model
log_reg_model.fit(X_train, y_train)

# Make predictions
y_pred = log_reg_model.predict(X_test)

# Evaluate the model
accuracy = accuracy_score(y_test, y_pred)
report = classification_report(y_test, y_pred)

print("Accuracy on test set:", accuracy)
print("Classification Report on test set:\n", report)

# Cross-validation to check for overfitting
cross_val_score_log_reg = cross_val_score(log_reg_model, X, y, cv=5)
print("Cross-validation scores on 5 folds:", cross_val_score_log_reg)
print("Mean cross-validation score:", cross_val_score_log_reg.mean())


# Evaluate the model on the training set
y_train_pred = log_reg_model.predict(X_train)
train_accuracy = accuracy_score(y_train, y_train_pred)
train_report = classification_report(y_train, y_train_pred)
print("Accuracy on training set:", train_accuracy)
print("Classification Report on training set:\n", train_report)

import matplotlib.pyplot as plt
import numpy as np

# Generate some data
x = np.random.rand(30)
y = np.random.rand(30)

# Create a figure and a set of subplots
fig, ax = plt.subplots()

# Plot the data as a scatter plot
ax.scatter(x, y)

# Set labels for the x and y axes
ax.set_xlabel('X-axis label')
ax.set_ylabel('Y-axis label')

# Set a title for the plot
ax.set_title('Scatter Plot Example')

# Display the plot
plt.show()