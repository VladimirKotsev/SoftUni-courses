function addItem() {

    let ul = document.getElementById(`items`);

    let text = document.getElementById(`newItemText`).value;
    let li =  document.createElement(`li`);
    li.textContent = text;
    
    let link = document.createElement(`a`);
    link.text = `[Delete]`;
    link.href = `#`;

    li.appendChild(link);
    
    link.addEventListener(`click`, function(){

        ul.removeChild(li);
    });

    ul.appendChild(li);
}
