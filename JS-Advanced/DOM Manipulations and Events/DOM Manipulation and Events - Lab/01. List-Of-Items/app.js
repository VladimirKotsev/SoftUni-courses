function addItem() {
    
    let ul = document.getElementById(`items`);

    let text = document.getElementById(`newItemText`).value;
    let li =  document.createElement(`li`);
    li.textContent = text;
    ul.appendChild(li);
}