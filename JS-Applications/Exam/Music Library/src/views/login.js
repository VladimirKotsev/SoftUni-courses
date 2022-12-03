import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { login } from '../api/user.js';
import { navigationBar } from './home.js';

const loginView = html`
<section id="login">
    <div class="form">
        <h2>Login</h2>
        <form class="login-form">
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
                Not registered? <a href="/register">Create an account</a>
            </p>
        </form>
    </div>
</section>
`;

export function showLogin() {
    renderTemplate(loginView);

    const form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onLogin);

}   

async function onLogin(event){
    event.preventDefault();

    let formData = new FormData(event.target);
    const { email, password } = Object.fromEntries(formData);

    if (!validation()){

        alert(`Cannot login with empty fields!`);
    }
    else{

        await login(email, password);
        navigationBar();

        page.redirect(`/catalog`);
    }

    function validation(){

        if (!email || !password){
            return false;
        }

        return true;
    }
}
