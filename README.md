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
* _> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);_


## Known Bugs

_{Are there issues that have not yet been resolved that you want to let users know you know?  Outline any issues that would impact use of your application.  Share any workarounds that are in place. }_

## Support and contact details

_Please contact me with any problems at eliseylenore@gmail.com_

## Technologies Used

_I used C# with the Nancy framework and Razor. I used SQL to create the database. I also relied on Bootstrap._

### License

*MIT*

Copyright (c) 2016 **_Elise St Hilaire_**
