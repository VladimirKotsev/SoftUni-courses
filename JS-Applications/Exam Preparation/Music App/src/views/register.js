import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { register } from '../api/user.js';

const registerView = html`
<section id="registerPage">
    <form>
        <fieldset>
            <legend>Register</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <label for="conf-pass" class="vhide">Confirm Password:</label>
            <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

            <button type="submit" class="register">Register</button>

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </fieldset>
    </form>
</section>
`;

export function showRegister() {
    renderTemplate(registerView);

    let form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onRegister);
}

async function onRegister(event) {

    event.preventDefault();

    let formData = new FormData(event.target);
    let body = Object.fromEntries(formData);

    debugger;
    if (body.email == "" || body.password == "" || body[`conf-pass`] == "") {

        alert(`Cannot register with empty fields!`);
        return;
    }
    else if (body.password === body[`conf-pass`]){

        await register(body.email, body.password);
        page.redirect(`/`);
    }
}