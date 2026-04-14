using Homework5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


// File path for json because we do not want the newly created customers to live only in memory
string filePath = "customers.json";

// Loading data
List<Customer> customers = LoadCustomers(filePath);

// Main loop
while (true)
{
    Console.WriteLine("\n==== ATM SYSTEM ====");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");
    Console.WriteLine("3. Exit");

    Console.Write("Choose option: ");
    string input = Console.ReadLine();

    int choice;
    bool isValid = int.TryParse(input, out choice);

    if (!isValid || choice < 1 || choice > 3)
    {
        Console.WriteLine("Invalid choice.");
        continue;
    }

    if (choice == 1)
    {
        Customer customer = AuthenticateCustomer(customers);

        if (customer != null)
        {
            Console.WriteLine($"\nWelcome {customer.FullName}!");

            bool isRunning = true;

            while (isRunning)
            {
                int option = ShowATMMenu();

                if (option == 1)
                {
                    ShowBalance(customer);
                }
                else if (option == 2)
                {
                    WithdrawFunds(customer);
                    SaveCustomers(filePath, customers);
                }
                else if (option == 3)
                {
                    DepositFunds(customer);
                    SaveCustomers(filePath, customers);
                }

                isRunning = AskForAnotherAction();
            }
        }
    }
    else if (choice == 2)
    {
        RegisterNewCustomer(customers);
        SaveCustomers(filePath, customers);
    }
    else if (choice == 3)
    {
        break;
    }
}

// Methods

List<Customer> LoadCustomers(string filePath)
{
    if (!File.Exists(filePath))
    {
        return new List<Customer>();
    }

    string json = File.ReadAllText(filePath);

    List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json);

    return customers ?? new List<Customer>();
}

void SaveCustomers(string filePath, List<Customer> customers)
{
    string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    File.WriteAllText(filePath, json);
}

Customer AuthenticateCustomer(List<Customer> customers)
{
    Console.Write("Enter card number: ");
    string cardNumber = Console.ReadLine();

    int pin;
    bool validPin;

    do
    {
        Console.Write("Enter PIN: ");
        string input = Console.ReadLine();

        validPin = int.TryParse(input, out pin);

        if (!validPin)
            Console.WriteLine("Invalid PIN.");
    }
    while (!validPin);

    foreach (Customer customer in customers)
    {
        if (customer.CardNumber == cardNumber && customer.ValidatePin(pin))
            return customer;
    }

    Console.WriteLine("Invalid credentials.");
    return null;
}

int ShowATMMenu()
{
    int option;
    bool isValid;

    do
    {
        Console.WriteLine("\n1. Balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");

        string input = Console.ReadLine();

        isValid = int.TryParse(input, out option);

    } while (!isValid || option < 1 || option > 3);

    return option;
}

void ShowBalance(Customer customer)
{
    Console.WriteLine($"Balance: {customer.GetBalance()}");
}

void WithdrawFunds(Customer customer)
{
    double amount;
    bool isValid;

    do
    {
        Console.Write("Amount: ");
        string input = Console.ReadLine();

        isValid = double.TryParse(input, out amount);

    } while (!isValid || amount <= 0);

    if (customer.Withdraw(amount))
        Console.WriteLine("Success");
    else
        Console.WriteLine("Not enough money");
}

void DepositFunds(Customer customer)
{
    double amount;
    bool isValid;

    do
    {
        Console.Write("Amount: ");
        string input = Console.ReadLine();

        isValid = double.TryParse(input, out amount);

    } while (!isValid || amount <= 0);

    customer.Deposit(amount);
    Console.WriteLine("Success");
}

bool AskForAnotherAction()
{
    Console.Write("Continue? (y/n): ");
    string answer = Console.ReadLine();

    return answer != null && answer.ToLower() == "y";
}

void RegisterNewCustomer(List<Customer> customers)
{
    Console.Write("Full name: ");
    string name = Console.ReadLine();

    string cardNumber = GenerateCardNumber();

    Console.WriteLine($"Your card number: {cardNumber}");

    int pin;
    bool valid;

    do
    {
        Console.Write("PIN: ");
        string input = Console.ReadLine();

        valid = int.TryParse(input, out pin);

    } while (!valid);

    Customer newCustomer = new Customer(name, cardNumber, pin, 0);

    customers.Add(newCustomer);

    Console.WriteLine("Registered!");
}

string GenerateCardNumber()
{
    Random random = new Random();

    return $"{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}";
}

void PrintAllCustomers(List<Customer> customers)
{
    Console.WriteLine("\n--- All Customers ---");

    foreach (Customer customer in customers)
    {
        Console.WriteLine(
            $"Name: {customer.FullName} | Card: {customer.CardNumber} | Balance: {customer.GetBalance()}"
        );
    }
}

List<Customer> defaultCustomers = new List<Customer>()
    {
        new Customer("Marija Poposka", "1111-2222-3333-4444", 1234, 1000),
        new Customer("Atanas Hristov", "5555-6666-7777-8888", 4321, 500),
        new Customer("John Doe", "9999-0000-1111-2222", 1111, 750)
    };

PrintAllCustomers(customers);