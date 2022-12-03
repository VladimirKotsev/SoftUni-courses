import { del, get } from "../api/api.js";
import { html, page } from '../api/lib.js';
import { renderTemplate } from "../app.js";
import { getUserData } from "../utils.js";

let id;
let ownerId;

const detailsView = (album) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
            <img src=${album.imageUrl} alt="example1" />
        </div>
            <div id="info-wrapper">
                <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
                <p>
                    <strong>Album name:</strong><span id="details-album">${album.album}</span>
                </p>
                <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
                <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
                <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
        </div>
        <div id="likes">Likes: <span id="likes-count">0</span></div>

        <!--Edit and Delete are only for creator-->
        <div id="action-buttons">
            ${getUserData()._id === album._ownerId ? html`
            
            ` : html`       
            <a href="" id="like-btn">Like</a>
            `}
            ${getUserData()._id === album._ownerId ? html`
            <a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a href="javascript:void(0)" @click=${onDelete} id="delete-btn">Delete</a>            
            ` : 
            html`
            
            `}
        </div>
    </div>
</section>
`;

export async function showDetails(ctx) {

    id = ctx.params.id;

    const album = await get(`/data/albums/${id}`);
    ownerId = album._ownerId;
    renderTemplate(detailsView(album));
}

async function onDelete(event){

    event.preventDefault();

    if (getUserData()._id === ownerId){

        await del(`/data/albums/${id}`);

        page.redirect(`/catalog`);
    }
}