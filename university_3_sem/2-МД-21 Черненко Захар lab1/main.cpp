#include <iostream>
#include "string"
int main() {
    std::string user_name;
    int user_age;
    std::cout << "Введите ваше имя: ";
    std::cin >> user_name;
    std::cout << "Введите ваш возраст: ";
    if (std::cin >> user_age)
    {
        std::cout << "Hello, " << user_name << "!" << std::endl;
        std::cout << "Вам " << user_age << " лет." << '\n';
    }
    else
    {
        std::cerr << "Некорректный ввод возраста";
    }
    return 0;
}
