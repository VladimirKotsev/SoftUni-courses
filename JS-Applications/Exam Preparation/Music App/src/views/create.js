import { post } from "../api/api.js";
import { renderTemplate } from "../app.js";
import { html, page } from '../api/lib.js';

const createView = html`
<section class="createPage">
    <form>
        <fieldset>
            <legend>Add Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" placeholder="Album name">

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" placeholder="Image Url">

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" placeholder="Price">

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" placeholder="Release date">

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" placeholder="Artist">

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" placeholder="Genre">

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" placeholder="Description"></textarea>

                <button class="add-album" type="submit">Add New Album</button>
            </div>
        </fieldset>
    </form>
</section>
`;

export async function showCreate(){
    renderTemplate(createView);

    let form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onCreate);
}

async function onCreate(event){

    event.preventDefault();

    let formData = new FormData(event.target);
    const { name, imgUrl, price, releaseDate, artist, genre, description } = Object.fromEntries(formData);

    if (!name || !imgUrl || !price || !releaseDate || !artist || !genre || !description){
        
        alert(`Cannot create album with empty fields!`);
    }
    else{

        const body ={
            name, imgUrl, price, releaseDate, artist, genre, description
        };
    
        const data = await post(`/data/albums`, body);
    
        page.redirect(`/catalog`);
    }
}