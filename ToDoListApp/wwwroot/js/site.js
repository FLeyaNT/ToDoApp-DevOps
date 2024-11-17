let items = document.querySelectorAll('.form-container');

for (let i = 0; i < items.length; i++) {
    const element = items[i];
    element.style.transitionDuration = `${3 + i}s`;
}

document.addEventListener('onbeforeunload', function () {
    setTimeout(() => {
        console.log("Загрузка");
    }, 1000);
});

document.addEventListener('DOMContentLoaded', function () {
    items.forEach(item => {
        item.classList.add('appeared');
    })
});