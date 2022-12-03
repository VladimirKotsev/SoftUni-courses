import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { register } from '../api/user.js';
import { navigationBar } from './home.js';

const registerView = html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
</section>
`;

export function showRegister(){
    renderTemplate(registerView);

    const form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onRegister);
}

async function onRegister(event){
    event.preventDefault();

    let formData = new FormData(event.target);
    const data = Object.fromEntries(formData);

    if (!validation()){

        alert(`Cannot register with empty fields!`);
    }
    else{

        if (data.password === data[`re-password`]){

            await register(data.email, data.password);
            navigationBar();
    
            page.redirect(`/catalog`);
        }
    }

    function validation(){

        debugger;
        if (!data.email || !data.password || !data[`re-password`]){
            return false;
        }

        return true;
    }
}