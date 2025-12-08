alert("Hello world!");


let message = "Hello world";
console.log(typeof(message))

// var - устаревшее ключевое слово
var a = 5;

let array = [1, 2, 3, 4];
console.log(typeof(array));

for (let i = 0; i != 10; ++i)
    console.log(i);

for (letter in message)
    console.log(message[letter]);


let counter = 0;
while (counter != 10) {
    ++counter;
    console.log(counter);
}

function sum_of_numbers() {
    // в функцию можно передавать неограниченно количество аргументов
    console.log(arguments);
};

console.log(sum_of_numbers(1, 2, 3, 4));

// если функция в фигурных скобках, то нужен return
let anonimous = (a, b) => a + b;


console.log(anonimous(23, 17));
