import { get } from '../api/api.js';
import { render, html } from '../api/lib.js';

const main = document.querySelector(`main`);

const catalogPageMany = (data) => html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">
        ${data.map(item => html`
        <div class="animals-board">
            <article class="service-img">
                <img class="animal-image-cover" src=${item.image}>
            </article>
            <h2 class="name">${item.name}</h2>
            <h3 class="breed">${item.breed}</h3>
            <div class="action">
                <a class="btn" href="/catalog/${item._id}">Details</a>
            </div>
        </div>
        `)}
    </div>
</section>
`;
const catalogPageNone = html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">
        <div>
            <p class="no-pets">No pets in dashboard</p>
        </div>
    </div>
</section>
`;

export async function showCatalog() {

    const data = await get(`/data/pets?sortBy=_createdOn%20desc&distinct=name`);

    if (data.length === 0){
        render(catalogPageNone, main);
    }
    else{
        render(catalogPageMany(data), main);
    }
}
