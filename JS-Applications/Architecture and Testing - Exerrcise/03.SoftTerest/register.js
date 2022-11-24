import { hideSections, hideHeaders, postRequest } from './utils.js';
import { showHomePage } from './home.js';
import { showLoginPageOnClick } from './login.js';


const section = document.getElementById(`register-page`);
const btnSubmit = section.getElementsByTagName(`button`)[0];
const switchPagesLink = section.getElementsByTagName(`a`)[0];

function showRegisterPage(){

    hideSections();
    hideHeaders();

    section.style.display = `block`;

    executePageLogic();
}

export function showRegisterPageOnClick(event){

    event.preventDefault();

    showRegisterPage();
}

function executePageLogic(){

    btnSubmit.addEventListener(`click`, onSubmit);

    switchPagesLink.addEventListener(`click`, showLoginPageOnClick);

    async function onSubmit(event){
    
        event.preventDefault();
        
        let email = document.getElementById(`email`).value;
        let password = document.getElementById(`password`).value;
        let rePassword = document.getElementById(`inputRepeatPassword`).value;

        if (validateInputField(email, password, rePassword)){

            let body = {
                email: email,
                password: password
            };

            const data = await postRequest("users/register", body);

            if (data !== false){
            
                localStorage.setItem(`email`, data.email);
                localStorage.setItem(`password`, data.password);
                localStorage.setItem(`accessToken`, data.accessToken);

                showHomePage();
            }

        }
    }
}

function validateInputField(email, password, repass){

    let correctEmail = email.length >= 3;
    let correctPass = password.length >= 3;
    let correctRepass = repass === password;

    if(correctEmail && correctPass && correctRepass){
        return true;
    }
    else{
        return false;
    }
}   