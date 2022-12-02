import { get } from '../api/api.js';
import { html } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { getUserData } from '../utils.js';
import { navigationBar } from './home.js';

const catalogViewData = (data) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
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
</section>
`;

const catalogViewNoData = html`
<section id="catalogPage">
    <h1>All Albums</h1>
           
    <!--No albums in catalog-->
    <p>No Albums in Catalog!</p>

</section>
`;

export async function showCatalog(ctx) {

    const data = await get(`/data/albums?sortBy=_createdOn%20desc&distinct=name`);

    if (data.length === 0){
        renderTemplate(catalogViewNoData)
    }
    else{
        renderTemplate(catalogViewData(data));
    }

    navigationBar();
}
