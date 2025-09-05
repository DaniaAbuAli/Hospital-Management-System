# Hospital Management System (HMS)

## Overview

A **C# Console Application** designed to manage basic hospital operations including **patient management**, **doctor management**, **appointments**, **prescriptions**, **medications**, and **billing**.

Demonstrates **Entity Framework Core (Code-First)**, **OOP principles**, and console-based menu-driven interactions.

## Features

- **Patient Management:** add, view, update, delete
- **Doctor Management:** add, view, update, delete, assign specialties
- **Appointment Management:** schedule, view, cancel appointments
- **Prescription Management:** issue prescriptions, view prescriptions
- **Medication Management:** add, view medications
- **Billing Management:** automatically generate bills when prescriptions are created, view bills

## How It Works

When you run the application, a **console-based menu** appears with options like:
1. Patient Management
2. Doctor Management
3. Appointment Management
4. Prescription Management
5. Medication Management
6. Billing Management
7. Exit

The user can select an option by entering the corresponding number.

Each section has its own sub-menu. For example:

- **Patient Management:** Add, View, Update, Delete patients.
- **Doctor Management:** Add, View, Update, Delete doctors.

The program will store and retrieve data from the database using **Entity Framework Core**.

When a prescription is created, the system **automatically generates a bill**.
