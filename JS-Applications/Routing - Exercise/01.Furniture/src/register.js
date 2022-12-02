import { html, render } from '../node_modules/lit-html/lit-html.js';
import { postRequest, createHtml, navigation } from './utils.js';
import  page  from '../node_modules/page/page.mjs';

const body = document.querySelector(`body`);

export function showRegisterPage(){
    
    navigation();
    render(createHtml(`register`), body);
    let form = body.querySelector(`form`);
    form.addEventListener(`submit`, onSubmit);
}

async function onSubmit(event){

    event.preventDefault();
    let data = new FormData(event.target);
    let {email, password, rePass} = Object.fromEntries(data);

    if (password === rePass){

        let body = {
            email: email,
            password: password
        };

        await postRequest(`users/register`, body);
        
        page.redirect(`/`);
    }
}