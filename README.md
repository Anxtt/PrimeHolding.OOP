This is a console application. I have created an abstract class Vehicle which implements IVehicle interface. The core logic for Vehicles lies there. 
Car, Cargo van, and Motorcycle, inherit the abstract class and override some of properties to make it more flexible. 
Invoice is the class that displays the details about the rental procedure. It implements a generic interface. Most properties are validated and throw exceptions when the passed data is improper.
In the main method there are quite a few test vehicles to use with the Invoice class.
