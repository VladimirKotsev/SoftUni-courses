import { html, render, page } from '../api/lib.js';
import { login } from '../api/user.js';

const main = document.querySelector(`main`);

const loginPage = html`
    <section id="loginPage">
        <form class="loginForm">
            <img src="./images/logo.png" alt="logo" />
            <h2>Login</h2>

            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>

            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="#">here</a></span>
            </p>
        </form>
    </section>
`; 

export function showLogin() {

    render(loginPage, main);

    const form = main.querySelector(`form`);
    form.addEventListener(`submit`, onSubmit);
}

async function onSubmit(event) {

    event.preventDefault();
    const formData = new FormData(event.target);
    let { email, password } = Object.fromEntries(formData);

    if (!email || !password){
        alert(`Register fields can't be empty!`);
        return;
    }
    
    await login(email, password);
    page.redirect(`/`);
}