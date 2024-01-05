// lab 4
// 2-MD-21 Chernenko Zahar
// 2023-11-11
/* this program reads txt file (gets filename from user's input)
 * and counts frequency of every word (ignores uppercase), then writes it
 * to output.txt */
#include <iostream>
#include <string>
#include "FilesTools.h"


int main() {
    std::string file_name;
    std::cout << "Enter filename: ";
    std::cin >> file_name;

    try {
        std::vector<std::string> words {readFile(file_name)};
        std::unordered_map<std::string, int> frequency_map {createFrequencyMap(words)};
        writeFile("output.txt", frequency_map);
    }

    catch (const char* exp) {
        std::cerr << exp << '\n';
        return 1;
    }
    return 0;
}
