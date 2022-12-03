import { get } from '../api/api.js';
import { html } from '../api/lib.js';
import { renderTemplate } from '../app.js';
import { getUserData } from '../utils.js';
import { navigationBar } from './home.js';

const catalogViewData = (data) => html`
<section id="dashboard">
    <h2>Albums</h2>
    <ul class="card-wrapper">
        <!-- Display a li with information about every post (if any)-->
        ${data.map(item => html`
        <li class="card">
        <img src=${item.imageUrl} alt="travis" />
        <p>
          <strong>Singer/Band: </strong><span class="singer">${item.singer}</span>
        </p>
        <p>
          <strong>Album name: </strong><span class="album">${item.album}</span>
        </p>
        <p><strong>Sales:</strong><span class="sales">${item.sales}</span></p>   
        <a class="details-btn" href="/catalog/${item._id}">Details</a>
      </li>
        `)}
    </ul>
</section>
`;

const catalogViewNoData = html`
<section id="dashboard">
    <h2>Albums</h2>

    <!-- Display an h2 if there are no posts -->
    <h2>There are no albums added yet.</h2>
</section>
`;

export async function showCatalog() {

    navigationBar();

    const data = await get(`/data/albums?sortBy=_createdOn%20desc`);

    if (data.length === 0){
        renderTemplate(catalogViewNoData);
    }
    else{
        renderTemplate(catalogViewData(data));
    }
}
