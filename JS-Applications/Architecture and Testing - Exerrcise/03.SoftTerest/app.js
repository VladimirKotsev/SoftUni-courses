import { showHomePage, showHomePageOnClick } from './home.js';
import { showLoginPageOnClick } from './login.js';
import { showRegisterPageOnClick } from './register.js';
import { onLogout } from './logout.js';
import { showCreatePageOnClick } from './create.js';
import { showDashboardPage, showDashboardPageOnClick } from './dashboard.js';

const icon = document.getElementById(`icon`);

const registerPage = document.getElementById(`register-link`);
registerPage.addEventListener(`click`, showRegisterPageOnClick)

const loginPage = document.getElementById(`login-link`);
loginPage.addEventListener(`click`, showLoginPageOnClick);

const logoutPage = document.getElementById(`logout-link`);
logoutPage.addEventListener(`click`, onLogout);

const createPage = document.getElementById(`create-link`);
createPage.addEventListener(`click`, showCreatePageOnClick)

if (localStorage.email !== undefined){
    
    icon.addEventListener(`click`, showDashboardPageOnClick);
    showDashboardPage();
}
else{
    
    icon.addEventListener(`click`, showHomePageOnClick);
    showHomePage();
}
