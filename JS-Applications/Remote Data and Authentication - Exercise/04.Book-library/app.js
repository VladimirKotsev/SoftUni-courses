let url = `http://localhost:3030/jsonstore/collections/books`;

let loadBtn = document.getElementById(`loadBooks`);
loadBtn.addEventListener(`click`, getBooks);

let submitBtn = document.querySelector(`form button`);
submitBtn.addEventListener(`click`, submitBook);

let btnEdit1 = document.querySelectorAll(`td <button>Edit</button>`);

btnEdit1.forEach(element => {
    
    element.addEventListener(`click`, editBook);

});

function editBook(event){

    let h3 = document.getElementsByTagName(`h3`)[0];
    h3.textContent = `Edit FORM`

    let tr = event.target.parentElement.parentElement;
    let title = tr.getElementsByTagName(`td`)[0];
    let author = tr.getElementsByTagName(`td`)[1];

    let inputTitle = document.querySelector(`input[name=title]`).value;
    let inputAuthor = document.querySelector(`input[name=author]`).value;

    inputTitle = title;
    inputAuthor = author;

    submitBtn.textContent = `Save`;
    submitBtn.removeEventListener(`click`);

    submitBtn.addEventListener(`click`, putBook);

    async function putBook(){
    
        const response = await fetch(url);
        const data = await response.json();

        for (const key in data) {
            
            let current = data[key];
            if (current.author === author){

                const response1 = await fetch(url + `/` + key, {

                    method: 'put',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({author: inputAuthor, title: inputTitle})
                });
            }
        }

        submitBtn.textContent = `Submit`;
        submitBtn.removeEventListener(`click`);
        submitBtn.addEventListener(`click`, submitBook);
    }
}


function submitBook(){

    let title = document.querySelector(`input[name=title]`).value;
    let author = document.querySelector(`input[name=author]`).value;
    
    if (validate(title, author)){
        
        let body = {
            author: author,
            title: title
        }
        
        postBook(body);
    }
}

function validate(title, author){

    if (title && author){

        return true;
    }

    return false;
}

async function getBooks(){

    const response = await fetch(url);
    const data = await response.json();
}

async function postBook(body){

    const response = await fetch(url, {
        method: 'post',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });


}