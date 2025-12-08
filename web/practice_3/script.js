const images = ["https://cs12.pikabu.ru/post_img/2022/01/07/11/1641584006164198870.jpg",
    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzz1rs2Rj_1bB1JnKs4VIOoZMluwHg56BOYg&s",
    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-5o1eMGUdXexfz5wNGKVs-gauNEuWvgV_EQ&s"
];
let index = 0;
const container = document.getElementsByClassName("container")[0];


function showImage(index) {
    let image = document.createElement("img");
    image.src = images[index];
    container.replaceChild(image, container.firstChild);
}

function showNextSlide(diff) {
    index = (index + diff + images.length) % images.length;
    showImage(index);
}

showImage(index);