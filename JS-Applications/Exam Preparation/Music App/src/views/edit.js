import { get, put } from '../api/api.js';
import { html, page } from '../api/lib.js';
import { renderTemplate } from '../app.js';

let id;

const editView = (album) => html`
<section class="editPage">
<form>
    <fieldset>
        <legend>Edit Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" value=${album.name}>

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value=${album.imgUrl}>

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" value=${album.price}>

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value="${album.releaseDate}">

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" value=${album.artist}>

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" value=${album.genre}>

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" rows="10"cols="10">${album.description}</textarea>

                <button class="edit-album" type="submit">Edit Album</button>
            </div>
        </fieldset>
    </form>
</section>
`;

export async function showEdit(ctx) {

    id = ctx.params.id;
    const album = await get(`/data/albums/${id}`);

    renderTemplate(editView(album));

    let form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onEdit);
}

async function onEdit(event) {

    event.preventDefault();

    let formData = new FormData(event.target);
    let { name, imgUrl, price, releaseDate, artist, genre, description } = Object.fromEntries(formData);

    if (validateForm()){

        const data = {
            name, imgUrl, price, releaseDate, artist, genre, description
        };
    
        await put(`/data/albums/${id}`, data);
    
        page.redirect(`/catalog/${id}`);
    }
    else{
        window.alert(`Cannot edit album with empty fields!`);
        return;
    }

    function validateForm(){

        if (!name || !imgUrl || !price || !releaseDate || !artist || !genre || !description){
            return false;
        }

        return true;
    }
}