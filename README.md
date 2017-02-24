# _Hair Salon_

#### _App for managing a hair salon, 02/24/2017_

#### By _**Elise St Hilaire**_

## Description

_This app allows the owner of a hair salon to keep track of stylists and clients. The owner can view which clients belong to which stylists, as well as edit and delete clients._

## Setup/Installation Requirements

_Create database_
In SQLMD:
* _> CREATE DATABASE hair_salon;_
* _> GO_
* _> USE hair_salon;_
* _> GO_
* _> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));_
* _> GO_
* _> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);_
* _> GO_


## Specs

**The program returns a list of saved clients.**  
* Input: "Betsy Ross", "John Newton", "Hilga the Rockclimber";
* Output: "Betsy Ross", "John Newton", "Hilga the Rockclimber";

**The program returns a saved client's details.**  
* Input: "Betsy Ross" *click*  
* Output: Name: "Betsy Ross", Stylist: "Hilga the Rockclimber", Balance: 0

**The program returns a list of saved stylists.**  
* Input: "Betsy Ross", "John Newton", "Hilga the Rockclimber";
* Output: "Betsy Ross", "John Newton", "Hilga the Rockclimber";

**The program returns a saved stylist's details.**  
* Input: "Betsy Ross" *click*  
* Output: Name: "Betsy Ross", Hire Date: 01/21/1992

**The program allows to update a client's details.**  
* Input: Change "Betsy Ross" to "Betsy DeVoss"
* Output: Name: Recorded updated! Client's new name is "Betsy DeVoss"

**The program allows to update a client's details.**  
* Input: Change "Betsy Ross" to "Betsy DeVoss"
* Output: Name: Recorded updated! Client's new name is "Betsy DeVoss"


## Known Bugs

_{Are there issues that have not yet been resolved that you want to let users know you know?  Outline any issues that would impact use of your application.  Share any workarounds that are in place. }_

## Support and contact details

_Please contact me with any problems at eliseylenore@gmail.com_

## Technologies Used

_I used C# with the Nancy framework and Razor. I used SQL to create the database. I also relied on Bootstrap._

### License

*MIT*

Copyright (c) 2016 **_Elise St Hilaire_**
