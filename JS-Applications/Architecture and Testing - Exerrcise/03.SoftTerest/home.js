import { showRegisterPageOnClick } from './register.js';
import { hideSections, hideHeaders } from './utils.js';

export function showHomePageOnClick(event){

    event.preventDefault();
    showHomePage();
}

export function showHomePage(){
    
    hideSections();
    hideHeaders();
    visualizeHeaders();

    let section = document.getElementById(`home-page`);
    section.style.display = `block`;
    section.getElementsByTagName(`a`)[0].addEventListener(`click`, showRegisterPageOnClick)

}

function visualizeHeaders(){

    document.getElementById(`login`).style.display = `block`;
    document.getElementById(`register`).style.display = `block`;
}
