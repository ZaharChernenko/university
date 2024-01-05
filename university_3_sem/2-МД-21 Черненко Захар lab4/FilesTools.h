// lab 4
// 2-MD-21 Chernenko Zahar
// 2023-11-11
// functions declaration
#pragma once

std::vector<std::string> readFile(const std::string& file_name);
void writeFile(const std::string& file_name, const std::unordered_map<std::string, int>& frequency_map);
std::unordered_map<std::string, int> createFrequencyMap(const std::vector<std::string>& words);
