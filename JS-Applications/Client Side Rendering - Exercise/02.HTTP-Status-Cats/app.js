import { cats } from "./catSeeder.js";
import { html, render} from '../node_modules/lit-html/lit-html.js';

const section = document.querySelector(`#allCats`);

renderHtml();


function renderHtml(){

    let template = createHtml();
    render(template, section);
}

function createHtml(){

    let result = html`
    <ul>
        ${cats.map(cat => html`
        <li>
            <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn" @click="${toggleInfoBtn.bind()}">Show status code</button>
                <div class="status" style="display: none" id=${cat.id}>
                    <h4 class="card-title">Status Code: ${cat.statusCode}</h4>
                    <p class="card-text">${cat.statusMessage}</p>
                </div>
            </div>
        </li>
        `)}
    </ul>
    `;

    return result;
}

function toggleInfoBtn(event){

    event.preventDefault();
    let parentDiv = event.target.parentElement;

    let catCard = parentDiv.querySelector(`div`);
    if (catCard.style.display === `none`){

        catCard.style.display = `block`;
        event.target.textContent = `Hide status code`;
    }
    else{
        
        catCard.style.display = `none`;
        event.target.textContent = `Show status code`;
    }
}