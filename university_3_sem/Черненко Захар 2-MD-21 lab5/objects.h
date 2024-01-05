// functions declaration
#pragma once

#include <string>
#include <iostream>

class Vehicle {
// parent class
protected:
    float _speed;

public:
    Vehicle(float speed);
    virtual ~Vehicle();
    virtual void Print() const;
};


class Car: public Vehicle {
protected:
    std::string _model;

public:
   Car(float speed, const std::string& model);
   virtual ~Car();
   virtual void Print() const override;
};


class ElectricCar: public Car {
protected:
    float _accum_cap;

public:
    ElectricCar(float speed, const std::string& model, float accum_cap);
    virtual ~ElectricCar();
    virtual void Print() const override;
};


class AirCraft: public Vehicle {
protected:
    std::string _model;
    int _capacity;

public:
    AirCraft(float speed, const std::string& model, int capacity);
    virtual ~AirCraft();
    virtual void Print() const override;
};


class Bicycle: public Vehicle {
protected:
    float _weight;

public:
    Bicycle(float speed, float weight);
    virtual ~Bicycle();
    virtual void Print() const override;
};
