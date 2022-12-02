import  page  from '../node_modules/page/page.mjs';
import { showRegisterPage } from './register.js'
import { showCatalogPage } from './catalog.js';
import { showCreatePage } from './create.js';
import { showDashboardPage } from './dashboard.js';
import { showDetailsPage } from './details.js';
import { showEditPage } from './edit.js';
import { showLoginPage } from './login.js';

document.querySelector(`#logoutBtn`).addEventListener(`click`, onLogout);

async function onLogout(){

    const token = sessionStorage.accessToken;

    const response = await fetch(`http://localhost:3030/users/logout`, {
        method: 'get',
        headers: { 'X-Authorization': token }
    });

    sessionStorage.removeItem('email');
    sessionStorage.removeItem('accessToken');
    sessionStorage.removeItem(`username`);

    page.redirect(`/`);
}

page('/', showDashboardPage)
page(`/dashboard`, showDashboardPage);
page(`/index.html`, showDashboardPage);

page('/register', showRegisterPage);
page(`/login`, showLoginPage);
page(`/create`, showCreatePage);
page(`/details/:id`, showDetailsPage);
page(`/my-furniture`, showCatalogPage);
page(`/edit/:id`, showEditPage)

page.start();