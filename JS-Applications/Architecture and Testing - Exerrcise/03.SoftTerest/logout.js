import { showHomePage } from './home.js';
import { logoutRequest } from './utils.js';

export function onLogout(event){

    event.preventDefault();

    localStorage.clear();
    logoutRequest(`users/logout`);
    showHomePage()
}