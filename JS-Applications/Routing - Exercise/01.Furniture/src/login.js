import { render , html} from '../node_modules/lit-html/lit-html.js';
import { createHtml, navigation, postRequest } from './utils.js';
import  page  from '../node_modules/page/page.mjs';

const body = document.querySelector(`body`);


export async function showLoginPage(){

    navigation();
    render(createHtml(`login`), body);
    
    let form = body.querySelector(`form`);
    form.addEventListener(`submit`, onSubmit);
}

async function onSubmit(event){
    
    event.preventDefault();
    let formData = new FormData(event.target);
    let { email, password } = Object.fromEntries(formData);
    
    let body = {
        email: email,
        password: password
    };
    
    try {
        const data = await postRequest(`users/login`, body);
        
        sessionStorage.setItem(`accessToken`, data.accessToken);
        sessionStorage.setItem(`email`, data.email);
        sessionStorage.setItem(`username`, data.username);

        page.redirect(`/`);

    } catch (error) {
        
        console.log(error.message);
    }
}