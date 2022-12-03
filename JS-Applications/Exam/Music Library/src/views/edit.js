import { get, put } from '../api/api.js';
import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';

let id;

const editView = (item) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Album</h2>
        <form class="edit-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value=${item.singer} />
            <input type="text" name="album" id="album-album" placeholder="Album" value="${item.album}"/>
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value="${item.imageUrl}"/>
            <input type="text" name="release" id="album-release" placeholder="Release date" value="${item.release}"/>
            <input type="text" name="label" id="album-label" placeholder="Label" value="${item.label}"/>
            <input type="text" name="sales" id="album-sales" placeholder="Sales" value="${item.sales}"/>

            <button type="submit">post</button>
        </form>
    </div>
</section>
`;

export async function showEdit(ctx) {

    id = ctx.params.id;

    const data = await get(`/data/albums/${id}`);
    //debugger;
    renderTemplate(editView(data));

    const form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onEdit);
}

async function onEdit(event){

    event.preventDefault();

    let formData = new FormData(event.target);
    const { singer,album, imageUrl, release, label, sales } = Object.fromEntries(formData);

    debugger;
    if (!singer || !album || !imageUrl || !release || !label || !sales){

        alert(`Cannot edit with empty fields!`);
    }
    else{

        let body = { singer,album, imageUrl, release, label, sales };

        await put(`/data/albums/${id}`, body);

        page.redirect(`/catalog`);
    }
}