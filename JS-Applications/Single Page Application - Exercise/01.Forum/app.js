import { cancelFields, onLoad, onPost, showHomePageOnClick } from './home.js';


const postBtn = document.querySelector(`button[class='public']`);
postBtn.addEventListener(`click`, onPost);

const cancelBtn = document.querySelector(`button[class='cancel']`);
cancelBtn.addEventListener(`click`, cancelFields);

const homeBtn = document.querySelector(`#home-page`);
homeBtn.addEventListener(`click`, showHomePageOnClick);

onLoad();
