import { html } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { getUserData } from '../utils.js';

const homeView = html`
<section id="welcomePage">
    <div id="welcome-message">
        <h1>Welcome to</h1>
        <h1>My Music Application!</h1>
    </div>

    <div class="music-img">
        <img src="./images/musicIcons.webp">
    </div>
</section>
`;

export function showHome() {
    renderTemplate(homeView);
    navigationBar();
}

export function navigationBar(){
    //user-only
    const logoutLink = document.querySelector(`a[href="javascript:void(0)"]`);
    const createLink = document.querySelector(`a[href="/create"]`);

    //guest-only
    const loginLink = document.querySelector(`a[href="/login"]`);
    const registerLink = document.querySelector(`a[href="/register"]`);

    const userOnly = [ logoutLink, createLink ];
    const guestOnly = [ loginLink, registerLink ];

    if (getUserData() === null){
        guestOnly.forEach(x => x.parentElement.style.display = `inline-block`);
        userOnly.forEach(x => x.parentElement.style.display = `none`);
    }
    else{
        guestOnly.forEach(x => x.parentElement.style.display = `none`);
        userOnly.forEach(x => x.parentElement.style.display = `inline-block`);
    }
}