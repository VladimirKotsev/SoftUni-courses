const url = `http://localhost:3030/data/catches`;

let span = document.getElementsByTagName(`span`)[0];
let logout = document.querySelector(`#logout`);
logout.addEventListener(`click`, onLogout);


if (localStorage.length > 0){ //logged in
    
    span.textContent = localStorage.username;
    document.querySelector(`#register`).style.display = `none`;
    document.querySelector(`#login`).style.display = `none`;
    
    logout.style.display = `block`;
    manipulateButtons(false);//enable
}
else{ //not logged in
    
    manipulateButtons(true); //disable
    logout.style.display = `none`;
    document.querySelector(`#register`).style.display = `inline-block`;
    document.querySelector(`#login`).style.display = `inline-block`;
}

let allCatches = document.querySelector(`#catches`);
let template = allCatches.querySelector(`div[class="catch"]`);

let loadBtn = document.querySelector(`button[class="load"]`);
loadBtn.addEventListener(`click`, loadCatches);

createForum();


function createForum(){

}

async function loadCatches(event){
    
    debugger;
    event.preventDefault();

    const data = await getRequest();
    if (data.length > 2){
        
        data.forEach(element => {
    
            console.log(element);
            let obj = element;
            let currentCatch = template.cloneNode(true);
            //currentCatch.style.display = `inline-block`;
            allCatches.appendChild(currentCatch);
    
            allCatches.querySelector(`input[class="angler"]`).value = obj.angler;
            allCatches.querySelector(`input[class="weight"]`).value = obj.weight;
            allCatches.querySelector(`input[class="species"]`).value = obj.species;
            allCatches.querySelector(`input[class="location"]`).value = obj.location;
            allCatches.querySelector(`input[class="bait"]`).value = obj.bait;
            allCatches.querySelector(`input[class="captureTime"]`).value = obj.captureTime;
    
            allCatches.querySelector(`button[class="update"]`).id = obj._id;
            allCatches.querySelector(`button[class="delete"]`).id = obj._id;
        });
    }

    document.querySelector(`#catches`).children.forEach(x => {

        //x.querySelector(`button[class="update"]`).addEventListener(`click`, putRequest(x))
        //x.querySelector(`button[class="delete"]`)
    });
}

async function putRequest(btn, body){

    // const response = await fetch(`http://localhost:3030/data/catches/` + btn.id, {

    //     method: 'put',
    //     headers: {'Content-Type': 'application/json'},
    //     body: 
    // });
}

function attachEventOnCatches(){

}

async function getRequest(){

    const response = await fetch(url);
    const data = await response.json();

    return data;
}

function manipulateButtons(IsDisabled){

    let buttons = document.querySelectorAll(`button`);
    buttons.forEach(button => {
        button.disabled = IsDisabled;
    });

    document.querySelector(`button[class="load"]`);
}

async function onLogout(event){

    //event.preventDefault();

    const response = await fetch(`http://localhost:3030/users/logout`, {

        method: 'get',
        headers: { 'X-Authorization': localStorage.accessToken}
    });
    

    localStorage.clear();

    manipulateButtons(true); //disable
    logout.style.display = `none`;
    document.querySelector(`#register`).style.display = `inline-block`;
    document.querySelector(`#login`).style.display = `inline-block`;
    span.textContent = `guest`;
}