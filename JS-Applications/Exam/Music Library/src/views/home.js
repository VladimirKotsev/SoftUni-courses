import { html } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { getUserData } from '../utils.js';

const homeView = html`
<section id="home">
    <img src="./images/landing.png" alt="home" />

    <h2 id="landing-text"><span>Add your favourite albums</span> <strong>||</strong> <span>Discover new ones right
        here!</span></h2>
</section>
`;

export function showHome() {
    renderTemplate(homeView);
    navigationBar();
}

export function navigationBar(){

    const userOnly = document.querySelector(`div[class="user"]`);
    const guestOnly = document.querySelector(`div[class="guest"]`);

    if (getUserData() === null){ //guest
        userOnly.style.display = `none`;
        guestOnly.style.display = `inline-block`;
    }
    else{ //user
        userOnly.style.display = `inline-block`;
        guestOnly.style.display = `none`;
    }
}