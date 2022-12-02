import { page, } from './api/lib.js';
import { logout } from './api/user.js';
import { navigationBar, showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';
import { showCatalog } from './views/catalog.js'
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showCreate } from './views/create.js';

const logoutLink = document.querySelector(`a[href="javascript:void(0)"]`);
logoutLink.addEventListener(`click`, onLogout)

function onLogout(event){

    event.preventDefault();
    logout();
    navigationBar();
}

page('/', showHome);
page('/catalog', showCatalog);
page('/catalog/:id', showDetails);
page('/edit/:id', showEdit)
page('/create', showCreate);
page('/login', showLogin);
page('/register', showRegister);

page.start();