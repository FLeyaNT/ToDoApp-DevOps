let items = document.querySelectorAll('.form-container');

for (let i = 0; i < items.length; i++) {
    const element = items[i];
    element.style.transitionDuration = `${3 + i}s`;
}

setTimeout(() => {
    items.forEach(item => {
        item.classList.add('appeared');
    })
}, 200)