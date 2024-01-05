// ������������ ������ 2
// 2-��-21 �������� �����
// 2023-09-30 ver1
// ���������� ���������� ���� Triangle

#ifndef TRIANGLE_H
#define TRIANGLE_H

namespace Geometry {
	struct Triangle {
		double a, b, c;

		Triangle();
		Triangle(double a, double b, double c);

		bool operator==(const Triangle& other) const;

		bool isValid() const;
		double findSquare() const;
	};
}

std::ostream& operator<<(std::ostream& os, const Geometry::Triangle& triangle);

#endif