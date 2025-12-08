function changeText(element_id) {
    let input = prompt("Введите текст: ");
    let obj = document.getElementById(element_id);
    obj.textContent = input;
    console.log(obj);
}

// changeText("lower__header");
// changeText("lower__text");


function getRandom() {
    console.log(Math.floor(Math.random() * 40) - 20);
}

// console.log(eval(input));