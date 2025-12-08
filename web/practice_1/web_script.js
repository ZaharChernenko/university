let my_container = document.getElementById("container")
let class_container = document.getElementsByClassName("container")
// возвращает первый элемент
let query = document.querySelector("container");

console.log(my_container);
console.log(class_container);

my_container.style.backgroundColor = "red";
my_container.innerHTML = "<p>HI</p>";

my_container.addEventListener("click", () => {
    alert("Element clicked");
})


console.log("Заказываем пиццу");
setTimeout(() => {
    console.log("Пицца доставлена");
}, 5000);

console.log("Смотрим сериал");


let i = 10;
setInterval(() => {console.log(i); --i;}, 1000);
