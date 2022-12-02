import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { login } from '../api/user.js';

const loginView = html`
<section id="loginPage">
    <form>
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="#">here</a></span>
            </p>
        </fieldset>
    </form>
</section>
`;

export function showLogin() {
    renderTemplate(loginView);

    let form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onLogin);
}

async function onLogin(event) {

    event.preventDefault();

    let formData = new FormData(event.target);
    let { email, password} = Object.fromEntries(formData);

    if (!email || !password) {

        alert(`Cannot login with empty fields!`);
        return;
    }

    await login(email, password);
    page.redirect(`/`);
}
