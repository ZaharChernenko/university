// Лабораторная работа 2
// 2-МД-21 Черненко Захар
// 2023-09-30 ver1
// Реализация составного типа Triangle

#include <iostream>
#include <algorithm>
#include "Triangle.h"

using namespace Geometry;
using std::cin;
using std::cout;


Triangle::Triangle(): a{0}, b{0}, c{0} {
	cout << "default constructor was used\n";
}

Triangle::Triangle(double a, double b, double c) {
	double sides_arr[3] = { a, b, c };
	std::sort(std::begin(sides_arr), std::end(sides_arr));
	this->a = sides_arr[0];
	this->b = sides_arr[1];
	this->c = sides_arr[2];
	cout << "constructor with values was used\n";
}

bool Triangle::operator==(const Triangle& other) const {
	return a == other.a && b == other.b && c == other.c;
}

bool Triangle::isValid() const {
	if (a + b <= c) return false;
	return true;
}

double Triangle::findSquare() const {
	double p = (this->a + this->b + this->c) / 2;
	return std::sqrt(p * (p - a) * (p - b) * (p - c));
}

std::ostream& operator<<(std::ostream& os, const Geometry::Triangle& triangle) {
    os << "Triangle with sides: a = " << triangle.a << ", b = " << triangle.b << ", c = " << triangle.c;
    return os;
}
