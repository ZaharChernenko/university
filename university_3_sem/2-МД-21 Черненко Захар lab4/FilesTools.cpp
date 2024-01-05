// lab 4
// 2-MD-21 Chernenko Zahar
// 2023-11-11
// functions realisation
#include <vector>
#include <unordered_map>
#include <fstream>
#include <string>
#include <regex>
#include "FilesTools.h"


std::vector<std::string> readFile(const std::string& file_name) {
    std::ifstream fin;
    fin.open(file_name);

    if (!fin) throw "File is not exist";

    std::regex exclude_signs {R"([^A-Za-z]+)"};
    std::string buf;
    std::vector<std::string> words;
    while (fin >> buf) {
        buf = std::regex_replace(buf, exclude_signs, "");
        for (auto& elem: buf) elem = tolower(elem);
        if (!buf.empty()) words.push_back(buf);
    }
    fin.close();
    return words;
}


void writeFile(const std::string& file_name,
               const std::unordered_map<std::string, int>& frequency_map) {
    std::ofstream fout;
    fout.open(file_name);

    fout << "WORD: FREQUENCY\n";
    for (const auto& elem: frequency_map) {
        fout << elem.first << ": " << elem.second << '\n';
    }
    fout.close();
}


std::unordered_map<std::string, int> createFrequencyMap(const std::vector<std::string>& words) {
    std::unordered_map<std::string, int> frequency_map;
    for (const auto& elem: words) {
        frequency_map.insert_or_assign(elem, ++frequency_map[elem]);
    }
    return frequency_map;
}
