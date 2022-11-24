import { hideSections, hideHeaders, postRequest } from "./utils.js";
import { showRegisterPageOnClick } from "./register.js";
import { showDashboardPage } from "./dashboard.js";

const section = document.getElementById(`login-page`);
const btnSubmit = section.getElementsByTagName(`button`)[0];
const switchPagesLink = section.getElementsByTagName(`a`)[0];

function showLoginPage(){

    hideSections();
    hideHeaders();

    section.style.display = `block`;

    if (localStorage.email !== undefined){

        onLogin();
    }
    
    btnSubmit.addEventListener(`click`, onSubmit); 
    switchPagesLink.addEventListener(`click`, showRegisterPageOnClick);
}

async function onSubmit(event){

    event.preventDefault();
    
    let email = document.getElementById(`inputEmail`).value;
    let password = document.getElementById(`inputPassword`).value;

    let body = {
        email: email,
        password: password
    };

    const data = await postRequest(`users/login`, body);
    //console.log(data);
    
    if (data !== false){

        localStorage.setItem(`email`, data.email);
        localStorage.setItem(`password`, data.password);
        localStorage.setItem(`accessToken`, data.accessToken);

        onLogin();
    }
}

function onLogin(){

    document.getElementById(`inputEmail`).value = ``;
    document.getElementById(`inputPassword`).value = ``;

    showDashboardPage();
}

export function showLoginPageOnClick(event){

    event.preventDefault();

    showLoginPage();
}