import { html, render} from '../api/lib.js';
import { getUserData } from '../utils.js';

const main = document.querySelector(`main`);

const homeView = html`
<section class="welcome-content">
    <article class="welcome-content-text">
        <h1>We Care</h1>
        <h1 class="bold-welcome">Your Pets</h1>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</p>
    </article>
    <article class="welcome-content-image">
        <img src="./images/header-dog.png" alt="dog">
    </article>
</section>
`;

export function showHome(){

    render(homeView, main);
    navigationBar();
}

export function navigationBar(){

    //user only
    const logoutLink = document.querySelector(`a[href="javascript:void(0)"]`);
    const createLink = document.querySelector(`a[href="/create"]`);
    const usersOnly = [ logoutLink, createLink ];

    //guest only;
    const loginLink = document.querySelector(`a[href="/login"]`);
    const registerLink = document.querySelector(`a[href="/register"]`);
    const guestOnly = [ loginLink, registerLink ];

    if (getUserData() !== null){
        guestOnly.forEach(x => x.parentElement.style.display = `none`);
        usersOnly.forEach(x => x.parentElement.style.display = `inline-block`);
    }
    else{
        guestOnly.forEach(x => x.parentElement.style.display = `inline-block`);
        usersOnly.forEach(x => x.parentElement.style.display = `none`);
    }
}