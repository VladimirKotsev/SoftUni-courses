import { html, render } from '../node_modules/lit-html/lit-html.js';
const url = `http://localhost:3030/jsonstore/advanced/dropdown`;

const select = document.querySelector(`#menu`);

const submitBtn = document.querySelector(`input[type="submit"]`);
submitBtn.addEventListener(`click`, addItem);

let data = await getRequest();
loadOptions(data);

async function addItem(event) {
    
    event.preventDefault();

    let input = document.querySelector(`#itemText`);

    let body = {
        text: input.value
    };

    postRequest(body);
    const data = await getRequest();
    loadOptions(data);
}

async function postRequest(body){

    const response = await fetch(url, {
        
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}

async function loadOptions(data){

    data = convertToArray(data);

    const result = createHtml(data);
    render(result, select);
}

function convertToArray(data){

    let array = [];
    for (const key in data) {
        
        array.push(data[key]);
    }

    return array;
}

function createHtml(data){

    const result = html`
        ${data.map(option => html`<option value=${option._id}>${option.text}</option>`)}
    `;

    return result;
}

async function getRequest(){

    const response = await fetch(url);
    const data = await response.json();

    return data;
}
