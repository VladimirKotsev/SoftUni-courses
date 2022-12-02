import { renderTemplate } from "../app.js";
import { html, render } from '../api/lib.js';
import { get } from "../api/api.js";
import { getUserData } from "../utils.js";

const searchView = html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button class="button-list" @click=${onSearch}>Search</button>
    </div>

    <h2>Results:</h2>

    <!--Show after click Search button-->
    <div class="search-result">
                        
    </div>
</section>
`;

const resultView = (data) => html`
${data.map(item => html`
    <div class="card-box">
        <img src=${item.imgUrl}>
        <div>
            <div class="text-center">
                <p class="name">Name: ${item.name}</p>
                <p class="artist">Artist: ${item.artist}</p>
                <p class="genre">Genre: ${item.genre}</p>
                <p class="price">Price: $${item.price}</p>
                <p class="date">Release Date: ${item.releaseDate}</p>
            </div>
            ${getUserData() === null ? html`
            <div class="btn-group">  

            </div>
            `: html`
            <div class="btn-group">
                <a href="/catalog/${item._id}" id="details">Details</a>
            </div>
            `}
            </div>
    </div>
    `)}
`;

const noResultView = html`
<p class="no-result">No result.</p>
`;

export function showSearch(){
    renderTemplate(searchView);

}

async function onSearch(event){

    event.preventDefault();
    const searchName = document.querySelector(`#search-input`);

    if (!searchName.value){

        alert(`Input field cannot be empty`);
        return;
    }
    else{

        const data = await get(`/data/albums?where=name%20LIKE%20%22${searchName.value}%22`);
        
        if (data.length === 0){
            render(noResultView, document.querySelector(`#searchPage`).querySelector(`div[class="search-result"]`));
        }
        else{
            render(resultView(data), document.querySelector(`#searchPage`).querySelector(`div[class="search-result"]`));
        }
    }
}