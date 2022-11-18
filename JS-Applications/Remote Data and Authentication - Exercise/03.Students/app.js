
let url = `http://localhost:3030/jsonstore/collections/students`;
tableRecords();

let tableBody = document.getElementsByTagName(`tbody`)[0];

let submitBtn = document.getElementById(`submit`);
submitBtn.addEventListener(`click`, submitRecord);


function submitRecord(){

    let firstName = document.querySelector(`[name=firstName]`).value;
    let lastName = document.querySelector(`[name=lastName]`).value;
    let facultyNumber = document.querySelector(`[name=facultyNumber]`).value;
    let grade = document.querySelector(`[name=grade]`).value;
    
    if (validate(firstName, lastName, facultyNumber, grade)){

        let body = {
            firstName: firstName,
            lastName: lastName,
            facultyNumber: facultyNumber,
            grade: grade
        };
    
        postRecord(body);
    }

}

function validate(firstName, lastName, facultyNumber, grade){

    if (firstName && lastName && facultyNumber && grade){

        return true;
    }

    return false;
}

// async function addTableRecord(data){

//     for (const key in data) {
        
//         let current = data[key];
//         let tr = document.createElement(`tr`);

//         let th1 = document.createElement(`th`);
//         th1.textContent = current.firstName;

//         let th2 = document.createElement(`th`);
//         th2.textContent = current.lastName;

//         let th3 = document.createElement(`th`);
//         th3.textContent = current.facultyNumber;

//         let th4 = document.createElement(`th`);
//         th4.textContent = current.grade;

//         tr.appendChild(th1);
//         tr.appendChild(th2);
//         tr.appendChild(th3);
//         tr.appendChild(th4);

//         tableBody.appendChild(tr);
//     }
// }

async function postRecord(body){

    const response = await fetch(url, {

        method: 'post',
        header: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    //const data = await response.json();
    //addTableRecord(data);
}

async function tableRecords(){

    const data = await getRecords();

    for (const key in data) {
        
        let current = data[key];
        let tr = document.createElement(`tr`);

        let th1 = document.createElement(`th`);
        th1.textContent = current.firstName;

        let th2 = document.createElement(`th`);
        th2.textContent = current.lastName;

        let th3 = document.createElement(`th`);
        th3.textContent = current.facultyNumber;

        let th4 = document.createElement(`th`);
        th4.textContent = current.grade;

        tr.appendChild(th1);
        tr.appendChild(th2);
        tr.appendChild(th3);
        tr.appendChild(th4);

        tableBody.appendChild(tr);
    }
}

async function getRecords(){

    const response = await fetch(url);
    const data = await response.json();

    return data;
}