import { render, html, page } from '../api/lib.js';
import { register } from '../api/user.js';

const main = document.querySelector(`main`);

const registerPage = html`
    <section id="registerPage">
        <form class="registerForm">
            <img src="./images/logo.png" alt="logo" />
            <h2>Register</h2>
            <div class="on-dark">
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>

            <div class="on-dark">
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <div class="on-dark">
                <label for="repeatPassword">Repeat Password:</label>
                <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Register</button>

            <p class="field">
                <span>If you have profile click <a href="#">here</a></span>
            </p>
        </form>
    </section>
`;

export function showRegister(){

    render(registerPage, main);

    let form = main.querySelector(`form`);
    form.addEventListener(`submit`, onSubmit);
}

async function onSubmit(event) {

    event.preventDefault();
    const formData = new FormData(event.target);
    let { email, password, repeatPassword } = Object.fromEntries(formData);

    if (!email || !password || !repeatPassword){  
        alert(`Register fields can't be empty!`);
        return;
    }

    if(password === repeatPassword){
        await register(email, password);
        page.redirect(`/`);
    }
}