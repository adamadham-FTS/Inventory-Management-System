# Inventory Management System

A C# console application built with .NET 10 for adding, viewing, editing, 
deleting, and searching products. Each product has a name, price, and quantity. 
Duplicate names are rejected regardless of letter case.

Inventory is stored in memory and is cleared when the application exits.


## Run with Docker

Start Docker Desktop with Linux containers enabled, then run:

```powershell

docker build -t inventory-system .

docker run --rm -it inventory-system

```

## Usage

Choose an operation from the console menu and follow the prompts. 
Prices must be greater than zero, quantities cannot be negative, 
and names cannot be blank. Select **6** to exit.
