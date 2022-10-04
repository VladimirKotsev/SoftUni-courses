function addItem() {
    
    let menu = document.getElementById(`menu`);
    let text = document.getElementById(`newItemText`);
    let value = document.getElementById(`newItemValue`);

    let option = document.createElement(`option`);
    option.value = value.value;
    option.textContent = text.value;

    text.value = ``;
    value.value = ``;
    
    menu.appendChild(option);
}