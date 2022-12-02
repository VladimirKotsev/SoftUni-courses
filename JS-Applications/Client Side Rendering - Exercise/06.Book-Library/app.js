import { html, render } from '../node_modules/lit-html/lit-html.js';

let btnId = ``;
const url = `http://localhost:3030/jsonstore/collections/books`;

const body = document.querySelector(`body`);
loadPage();

const editForm = body.querySelector(`#edit-form`);
editForm.addEventListener(`submit`, saveBook);

const addForm = document.querySelector(`#add-form`);
addForm.addEventListener(`submit`, addBook);

const loadBtn = body.querySelector(`button`);
loadBtn.addEventListener(`click`, loadBooksOnClick);

const tbody = body.querySelector(`tbody`);

let form = document.querySelector(`#add-form`);
form.addEventListener(`submit`, addBook);

function saveBook(event){

    event.preventDefault();

    const formData = new FormData(editForm);
    let {title, author} = Object.fromEntries(formData);

    if (validateFields(title, author)){

        putRequest({
            title: title,
            author: author
        }, btnId);

        loadBooks();

        manipulateDisplayOnForums(true); //display add-forum
    }
}

function addBook(event){

    event.preventDefault();

    const formData = new FormData(addForm);
    let {title, author} = Object.fromEntries(formData);

    if (validateFields(title, author)){

        postRequest({
            title: title,
            author: author
        });

        loadBooks();
        manipulateDisplayOnForums(true); //display add-forum
    }
}

function validateFields(...params){

    params.forEach(param => {

        if (!param){

            return false;
        }
    });

    return true;
}

async function postRequest(body){

    const response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}

function loadBooksOnClick(event){

    event.preventDefault();

    loadBooks();
}

async function loadBooks(){

    let data = await getRequest();
    data = convertToArray(data);
    if (data.length > 0){

        const result = createHtml(data);
        render(result, tbody);
    }
}

function convertToArray(data){

    let array = [];
    for (const key in data) {
       data[key].id = key;
       array.push(data[key]);
    }
 
    return array;
}

function deleteBook(event){

    const id = event.target.name;

    event.preventDefault();

    deleteRequest(id);
    loadBooks();
}

function createHtml(data){
    
    const result = html`
       ${data.map(item => html`
          <tr>
             <td>${item.title}</td>
             <td>${item.author}</td>
             <td>
                <button name=${item.id} @click="${editBook.bind()}">Edit</button/>
                <button name=${item.id} @click="${deleteBook.bind()}">Delete</button>
             </td>
          </tr>
       `)}
    `;
 
    return result;
}

function editBook(event){

    event.preventDefault();
    btnId = event.target.name;

    let editFrm = manipulateDisplayOnForums(false); //display edit-forum

    const tr = event.target.parentElement.parentElement;
    const bookTitle = tr.querySelectorAll(`td`)[0].textContent;
    const bookAuthor = tr.querySelectorAll(`td`)[1].textContent;

    editFrm.querySelector(`input[name="title"]`).value = bookTitle;
    editFrm.querySelector(`input[name="author"]`).value = bookAuthor;
}

async function putRequest(body, id){

    const response = await fetch(url + "/" + id, {

        method: 'put',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });

    const data = await response.json();

}

async function deleteRequest(id){

    const response = await fetch(url + "/" + id, {
        method: 'delete',
        headers: { 'Content-Type': 'application/json'}
    });

    const data = await response.json();
}

async function getRequest(){

    const response = await fetch(url);
    const data = await response.json();
 
    return data;
}

function loadPage(){

    const result = html`
    <button id="loadBooks">LOAD ALL BOOKS</button>
    <table>
        <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
        </thead>
        <tbody>

        </tbody>
    </table>
    <form id="add-form">
        <h3>Add book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Submit">
    </form>

    <form id="edit-form" style="display: none">
        <input type="hidden" name="id">
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Save">
    </form>
    `;

    render(result, body);
}

function manipulateDisplayOnForums(displayAddForum){

    let addFrm = document.querySelector(`#add-form`);
    let editFrm = document.querySelector(`#edit-form`);

    if (displayAddForum){

        addFrm.style.display = `block`;
        editFrm.style.display = `none`;
    }
    else{
        
        addFrm.style.display = `none`;
        editFrm.style.display = `block`;
    }

    let inputs = addFrm.querySelectorAll(`input[type="text"]`);
    inputs.forEach(x => x.value = ``);

    inputs = editFrm.querySelectorAll(`input[type="text"]`);
    inputs.forEach(x => x.value = ``);

    return editFrm;
}