#include <iostream>
#include "objects.h"


int main() {
    std::cout << "Черненко Захар 2-MD-21 lab5\n";
    std::cout << "This program has realisation of 5 objects:\n";
    std::cout << "Vehicle, Car, ElectricCar, Bicycle, AirCraft\n";
    std::cout << "____________________________________________\n";

    Vehicle* p = new Vehicle(233);
    p->Print();
    delete p;
    std::cout << std::endl;

    p = new Car(250, "BMV X5");
    p->Print();
    delete p;
    std::cout << std::endl;

    p = new ElectricCar(262, "Tesla model X", 75);
    p->Print();
    delete p;
    std::cout << std::endl;

    p = new Bicycle(40, 10);
    p->Print();
    delete p;
    std::cout << std::endl;

    p = new AirCraft(955, "Boeing 747", 366);
    p->Print();
    delete p;
    std::cout << std::endl;
}
