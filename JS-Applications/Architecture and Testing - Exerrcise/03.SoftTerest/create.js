import { hideSections } from './utils.js';
import { postRequest } from './utils.js';

const section = document.getElementById(`create-page`);
const createBtn = section.getElementsByTagName(`button`)[0];

export function showCreatePage(){
    
    hideSections();
    section.style.display = `block`;

    createBtn.addEventListener(`click`, onCreation);
}

function onCreation(event){

    event.preventDefault();

    let title = document.getElementById(`ideaTitle`).value;
    let description = document.getElementsByName(`description`)[0].value;
    let imageURL = document.getElementById(`inputURL`).value;

    if (validateInputFields(title, description, imageURL)){

        postRequest(`data/ideas`, {
            title: title,
            description: description,
            imageURL: imageURL
        });
    }

    title = ``;
    description = ``;
    imageURL = ``;
}

function validateInputFields(title, description, imageURL){

    let IsOkayTitle = title.length > 5;
    let IsOkayDescription = description.length > 9;
    let IsOkayUrl = imageURL.length > 4;

    if (IsOkayTitle && IsOkayDescription && IsOkayUrl){

        return true;
    }

    return false;
}

export function showCreatePageOnClick(event){

    event.preventDefault();

    showCreatePage();
}