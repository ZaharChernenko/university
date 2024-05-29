// functions realisation
#include "objects.h"


Vehicle::Vehicle(float speed): _speed {speed} {
    std::cout << "Vehicle object was created\n";
}

Vehicle::~Vehicle() {
    std::cout << "Vehicle object was destroyed\n";
}

void Vehicle::Print() const {
    std::cout << "This vehicle speed is " << _speed << " km/h" << '\n';
}


Car::Car(float speed, const std::string& model): Vehicle {speed}, _model {model} {
    std::cout << "Car object was created\n";
}

Car::~Car() {
    std::cout << "Car object was destroyed\n";
}

void Car::Print() const {
    Vehicle::Print();
    std::cout << "Car model is " << _model << '\n';
}


ElectricCar::ElectricCar(float speed, const std::string& model, float accum_cap):
    Car{speed, model}, _accum_cap {accum_cap} {
    std::cout << "ElectricCar object was created\n";
}

ElectricCar::~ElectricCar() {
    std::cout << "ElectricCar object was destroyed\n";
}

void ElectricCar::Print() const {
    Car::Print();
    std::cout << "Accummulator capacity is " << _accum_cap << " kw/h" << '\n';
}


AirCraft::AirCraft(float speed, const std::string& model, int capacity):
    Vehicle {speed}, _model {model}, _capacity {capacity} {
    std::cout << "AirCraft object was created\n";
}

AirCraft::~AirCraft() {
    std::cout << "AirCraft object was destoyed\n";
}

void AirCraft::Print() const {
    Vehicle::Print();
    std::cout << "Aircraft model is " << _model << '\n';
    std::cout << "Aircraft capacity is " << _capacity << " people" << '\n';
}


Bicycle::Bicycle(float speed, float weight): Vehicle {speed}, _weight {weight} {
    std::cout << "Bicycle object was created\n";
}

Bicycle::~Bicycle() {
    std::cout << "Bicycle object was destroyed\n";
}

void Bicycle::Print() const{
    Vehicle::Print();
    std::cout << "Bicycle weight is " << _weight << " kg" << '\n';
}
