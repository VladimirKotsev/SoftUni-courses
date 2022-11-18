function attachEvents() {
    
    const url = `http://localhost:3030/jsonstore/phonebook`;
    let deleteUrl = `http://localhost:3030/jsonstore/phonebook/`;

    let createBtn = document.getElementById(`btnCreate`);
    let loadBtn = document.getElementById(`btnLoad`);
    let ul = document.getElementById(`phonebook`);

    loadBtn.addEventListener(`click`, loadPhones);

    createBtn.addEventListener(`click`, createPhone);

    async function createPhone(event){
        
        event.preventDefault();
        
        let personName = document.getElementById(`person`).value;
        let personPhone = document.getElementById(`phone`).value;

        const response = await fetch(url, {

            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({person: personName, phone: personPhone})
        });

    }

    async function loadPhones(event){

        event.preventDefault();

        const response = await fetch(url);
        const data = await response.json();

        for (const key in data) {
            
            let li = document.createElement(`li`);
            li.textContent = `${data[key].person}: ${data[key].phone}`;
            
            let btnDelete = document.createElement(`button`);
            btnDelete.textContent = `Delete`;
            btnDelete.name = data[key]._id;
            btnDelete.addEventListener(`click`, deletePhone);
            li.appendChild(btnDelete);

            ul.appendChild(li);
        }

    }

    async function deletePhone(event){

        event.preventDefault();

        const response = await fetch(deleteUrl + event.target.name, {

            method: `delete`
        });

        ul.removeChild(event.target.parentElement);
        
    }
}

attachEvents();