#include <iostream>
#include "Triangle.h"

using namespace Geometry;
using std::cin;
using std::cout;


int main() {
	Triangle triangles_arr[10];
	for (int i = 0; i < 10; ++i) {
		while (!triangles_arr[i].isValid()) {
			triangles_arr[i] = { double(1 + std::rand() % 20), double(1 + std::rand() % 20), double(1 + std::rand() % 20) };
		}
		cout << triangles_arr[i] << "   Square: " << triangles_arr[i].findSquare() << '\n';
	}
	return 0;
}
