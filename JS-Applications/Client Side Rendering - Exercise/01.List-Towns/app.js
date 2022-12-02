import { render, html} from '../node_modules/lit-html/lit-html.js';

let loadBtn = document.querySelector(`#btnLoadTowns`);
loadBtn.addEventListener(`click`, onLoad);

let rootDiv = document.querySelector(`#root`);


function onLoad(event){
    
    event.preventDefault();
    
    let formData = new FormData(event.target.parentElement);
    let data = Object.fromEntries(formData);
    let towns = data[`towns`].split(`, `);
    
    let text = createHtml(towns);
    //debugger;
    render(text, rootDiv);
}

function createHtml(towns){
    
    let result = html`
    <ul>
        ${towns.map(item => html`<li>${item}</li>`)};
    </ul>
    `;

    return result;
}