import { del, get } from "../api/api.js";
import { html, page } from '../api/lib.js';
import { renderTemplate } from "../app.js";
import { getUserData } from "../utils.js";

let id;

const detailsView = (item) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${item.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${item.name}</h1>
                <h3>Artist: ${item.artist}</h3>
                <h4>Genre: ${item.genre}</h4>
                <h4>Price: $${item.price}</h4>
                <h4>Date: ${item.releaseDate}</h4>
                <p>Description: ${item.description}</p>
            </div>

            <!-- Only for registered user and creator of the album-->
            <div class="actionBtn">
                ${getUserData()._id == item._ownerId ? html`
                    <a href="/edit/${item._id}" class="edit">Edit</a>
                    <a href="javascript:void(0)" @click=${onDelete} class="remove">Delete</a>
                ` : html`

                `
                }
            </div>
        </div>
    </div>
</section>
`

export async function showDetails(ctx) {

    id = ctx.params.id;

    const data = await get(`/data/albums/${id}`);

    renderTemplate(detailsView(data));
}

async function onDelete(event){

    event.preventDefault();

    await del(`/data/albums/${id}`);
    page.redirect(`/catalog`);
}