import { page, render, } from './api/lib.js';
import { logout } from './api/user.js';
import { showHome, navigationBar } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';
import { showCatalog } from './views/catalog.js'
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showCreate } from './views/create.js';

const logoutLink = document.querySelector(`a[href="javascript:void(0)"]`);
logoutLink.addEventListener(`click`, onLogout);

async function onLogout(event){

    event.preventDefault();
    await logout();

    page.redirect(`/catalog`);
}

page('/', showHome);
page('/catalog', showCatalog);
page('/catalog/:id', showDetails);
page('/edit/:id', showEdit)
page('/create', showCreate);
page('/login', showLogin);
page('/register', showRegister);

page.start();

export function renderTemplate(content){
    render(content, document.querySelector(`main`));
}