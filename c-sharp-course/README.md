
# C# course
This course consists of 7 laboratory works
#### List of given tasks:
1. [LabWork1](#Laboratory-work-1) Overview of the main features of the C# .NET language.
2. [LabWork2](#Laboratory-work-2) Introduction to the basics of object-oriented programming in C# and Windows Forms technology.
3. [LabWork3](#Laboratory-work-3) Acquaintance with the main types of collection, GUI creation based on Windows Forms.
4. [LabWork4](#Laboratory-work-4) File i/o software interfaces and file manipulations in the .NET Framework
5. [LabWork5](#Laboratory-work-5) Using LINQ TO OBJECTS and DATABINDING technic
6. [LabWork6](#Laboratory-work-6) Multithreading in C#
7. [LabWork7](#Laboratory-work-7) fundamentals of working with databases in C# using ADO.NET technology

## Laboratory work 1

Implement the task scheduler (for workers in the office). 
Create interfaces and classes which implements them. 
Provide exceptions to handle incorrect values entering.

Data type (class properties):
1. Program name: cannot be empty
2. Array of tasks: complexity of the task is determined by an enumeration of 4-5 states
3. Number of employees
4. Tasks history

Methods:
1. Initializing constructor
2. Determination of the task completion time based on the object's internal data
3. Displaying scheduler's history
4. Clearing the array of tasks
5. Clearing the history of tasks

## Laboratory work 2

Implement a seaport as an WinForms application. Provide separation of the interface
and the logic of the types that were created during the execution of the task. 
Application must allow user:
1. "seaport" objects Creation 
2. Displaying fields and properties of selected "seaport"
3. Call methods

Data type (class properties):
1. Name, port address, number of workers, number of equipment units
2. Cost of one unit of equipment
3. Cost of maintenance of one ship, time of maintenance of one ship
4. Number of berths (docks) (for 1 berth - 5 units of equipment and 15 workers)

Methods:
1. Determining the service time of the specified number of ships (expanding method)
2. Anticipation of the port's income when serving a given number of ships
3. Initializing and copy constructors
4. Operator ++ (number of berths with equipment, without workers)
5. Operators Y = and B = (by the number of functional moorings)
6. Implementation of the interface IequalityComparer<T> (T – port, comparison of ports)
7. Hire/Fire workers
 
## Laboratory work 3

#### Implement Task Manager
Classes: process manager; process; computer.
#### Class "Process"

Data: process name, user, CPU memory, Location, description, priority

Methods: initializing constructor; copy constructor

Operators: operators ++ and – to change the priority level (from 0 to 4).
#### Class "Computer"
Data: name, RAM, list of processes, CPU frequency, number of processors

Methods: changing RAM, overclocking/deceleration of the processor, adding a process,removing the process
#### Class "Computer Manager"
Data: list of computers (Hashtable), process list (Hashtable/Dictionary, key – process name), administrator name; administrator password.

Methods: add a computer; remove the computer; administrator authentication; add a process to the selected computer; remove the process from the selected computer; change the process on the selected computer; change the settings of the selected computer.


### WARNING: 
Implemented application works with real processes. So.... Try to select all processes and click "Delete" button !  


## Laboratory work 4

Given a file of real numbers. Swap the minimum and maximum elements in it.
Task must be completed as a WindowsForms application. All files are requested
through standard file opening and saving dialogs. Provide method to generate and 
fill file with the necessary values (perhaps using a random number generator).

## Laboratory work 5

The application stores information about students and their groups (many-to-one relationship 
is implemented, that is, one student belongs to only one group, but there can be many 
students in a group). Through dialog boxes, you can edit information about the list of 
groups (add, delete, rename) and student (add, delete, rename, change group). Sort by 
student name or group number. Implement output filtering of all students or only students
of the selected group.

## Laboratory work 6

The application simulates the operation of the factory, containing information about 
number of workshops, raw materials and finished products in warehouses. At the same time,
factory can work in several modes:
1) Purchase of raw materials
2) Production of products 
3) Sale of products. 

When purchasing, the factory spends money on raw materials from which the product will be made.
The "production" process takes place in the background and takes some time, and each batch of 
raw materials takes up 5% of the warehouse space. The process of manufacturing 1 unit of products
is accompanied by the expenditure of some fixed amount for the operation of the equipment from the 
factory register, removal of 1 unit of raw materials from the warehouse, takes some time and is performed
in the background flow. The process of selling products takes place in the background stream,
takes some time, leads to the removal of a fixed amount of products from the warehouse and the 
addition of money to the factory cash register. It also takes some time to transport 1 unit of products 
from the warehouse to the sale. At the end of the execution of each of the listed processes,
the corresponding report on the work performed is saved in XML. Implement the possibility of managing
processes at the plant, as well as viewing reports on the work performed with XML.

## Laboratory work 7

The application stores information about students and their groups (many-to-one relationship
is implemented, that is, one student belongs to only one group, but there can be many
students in a group). Implement the possibility of editing information about the list of 
groups (adding, deleting, renaming) and the student (adding, deleting, renaming, changing the
group). Implement the possibility of saving, extracting and changing data about students and 
groups in the database table.