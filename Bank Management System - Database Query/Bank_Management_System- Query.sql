CREATE TABLE Branch
(
    Branch_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Branch_Name VARCHAR(100) UNIQUE NOT NULL,
    Branch_Manager_Name VARCHAR(50) NOT NULL,
    Branch_Manager_Email VARCHAR(50) NOT NULL UNIQUE,
    Branch_Manager_Password VARCHAR(500) NOT NULL,
    Branch_Manager_JoinDate DATE,
    Branch_City VARCHAR(50) NOT NULL,
    Branch_Country VARCHAR(50) NOT NULL,
    Branch_Phone VARCHAR(20) UNIQUE NOT NULL,
    Branch_Manager_Picture VARCHAR(1000)
)

CREATE TABLE Department
(
    Department_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Department_Name VARCHAR(50) UNIQUE NOT NULL,
    Head_Of_Department VARCHAR(50) NOT NULL
)

CREATE TABLE Employee
(
    Employee_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Employee_Name VARCHAR(50) NOT NULL,
    Employee_Email VARCHAR(50) UNIQUE NOT NULL,
    Employee_Password VARCHAR(500),
    Employee_Phone VARCHAR(20) UNIQUE NOT NULL,
    Employee_JoinDate DATE,
    Branch_ID INT NOT NULL,
    Department_ID INT NOT NULL,
    Employee_Address VARCHAR(1000),
    Employee_Picture VARCHAR(1000),
    
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID),
    FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID)
)

CREATE TABLE VerifyEmployee
(
    VerifyEmployee_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	Employee_ID INT,
	FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
)

CREATE TABLE Customer
(
    Customer_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Customer_Name VARCHAR(50) NOT NULL,
    Customer_Email VARCHAR(50) UNIQUE,
    Customer_Password VARCHAR(300) NOT NULL,
    Customer_Phone VARCHAR(20) UNIQUE NOT NULL,
    Customer_JoinDate DATE,
    Branch_ID INT NOT NULL,
    Customer_Address VARCHAR(500) NOT NULL,
    Customer_Picture VARCHAR(1000),
    
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID)
)

CREATE TABLE Accounts
(
    Account_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Branch_ID INT NOT NULL,
    Customer_ID INT NOT NULL,
    Account_Number VARCHAR(50) UNIQUE NOT NULL,
    Account_Type VARCHAR(20) NOT NULL,
    Balance NUMERIC(12,2) NOT NULL,
    Account_Status VARCHAR(20) NOT NULL,
    
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID),
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID) 
)

CREATE TABLE Transactions
(
    Transactions_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Branch_ID INT NOT NULL,
    Customer_ID INT NOT NULL,
    Account_ID INT NOT NULL,
    Employee_ID INT NOT NULL,
    CrediteOrDeposit VARCHAR(20),
    Ammount NUMERIC(12,0) NOT NULL,
    Transactions_Type VARCHAR(20),
    DateTimeStamp DATE,
    
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID),
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID),
    FOREIGN KEY (Account_ID) REFERENCES Accounts(Account_ID),
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
)

CREATE TABLE Loan
(
    Loan_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    Branch_ID INT NOT NULL,
    Customer_ID INT NOT NULL,
    Account_ID INT NOT NULL,
    Employee_ID INT  NOT NULL,
    Loan_Ammount NUMERIC(12,0) NOT NULL,
    Interest_Rate NUMERIC(12,2) NOT NULL,
    Durations INT NOT NULL,
    Start_Date DATE NOT NULL,
    Due_Ammount NUMERIC(12,2) NOT NULL,
    
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID),
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID),
    FOREIGN KEY (Account_ID) REFERENCES Accounts(Account_ID),
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
)