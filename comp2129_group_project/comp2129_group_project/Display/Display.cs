﻿using System;
using static System.Console;
using static comp2129_group_project.Util.Util;
using comp2129_group_project.BookingSubMenu;
using comp2129_group_project.Entities;

namespace comp2129_group_project.Display
{
    public class Display
    {
        // Define customers and flights arrays at the class level
        private static Customer[] customers = new Customer[5];
        private static Flight[] flights = new Flight[5];

        // Initialize sample data for customers and flights
        public static void InitializeData()
        {
            customers[0] = new Customer("John", "Doe", 0);
            customers[1] = new Customer("Jane", "Smith", 0);

            flights[0] = new Flight("New York", "Los Angeles");
            flights[1] = new Flight("Chicago", "Miami");
        }

        // Display the main menu
        public static string MenuMain()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("--- FACS Airlines Limited ---");
            WriteLine("-----------------------------\n");
            WriteLine("1) Customers");
            WriteLine("2) Flights");
            WriteLine("3) Bookings");
            WriteLine("0) Exit");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(4);
        }

        // Display customers menu
        public static string MenuCustomers()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("--------- Customers ---------");
            WriteLine("-----------------------------\n");
            WriteLine("1) Add Customer");
            WriteLine("2) View Customers");
            WriteLine("3) Delete Customer\n");
            WriteLine("0) Main Menu");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(4);
        }

        // Display flights menu
        public static string MenuFilghts()
        {
            Clear();
            WriteLine("-----------------------------");
            WriteLine("---------- Flights ----------");
            WriteLine("-----------------------------");
            WriteLine("1) Add Flight");
            WriteLine("2) View Flights");
            WriteLine("3) View Particular Flight");
            WriteLine("4) Delete Flight\n");
            WriteLine("0) Main Menu");
            WriteLine("-----------------------------");
            Write("> ");

            return GetInput(5);
        }

        // Display booking menu
        public static string MenuBookings()
        {
            Clear();
            // Ensure temporary data is initialized
            InitializeData();
            BookingMenu bookingMenu = new BookingMenu(customers, flights); 
            bookingMenu.ShowBookingMenu();  
            return "0";  
        }

        // Display exit menu
        public static void MenuExit()
        {
            Clear();
            WriteLine("------------------------------");
            WriteLine("---------- Goodbye! ----------");
            WriteLine("------------------------------");
            Thread.Sleep(1500);
        }
    }
}
