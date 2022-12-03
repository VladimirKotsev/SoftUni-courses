import { post } from "../api/api.js";
import { renderTemplate } from "../app.js";
import { html, page } from '../api/lib.js';

const createView = html`
<section id="create">
        <div class="form">
          <h2>Add Album</h2>
          <form class="create-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
      </section>
`;

export async function showCreate(){
    renderTemplate(createView);

    const form = document.querySelector(`main`).querySelector(`form`);
    form.addEventListener(`submit`, onCreate);
}

async function onCreate(event){
    event.preventDefault();

    let formData = new FormData(event.target);
    const { singer, album, imageUrl, release, label, sales} = Object.fromEntries(formData);

    if (!singer || !album || !imageUrl || !release || !label || !sales){

        alert(`Cannot create an album with empty fields!`);
        return;
    }
    else{

        let body = { 
            singer,
            album, 
            imageUrl, 
            release, 
            label, 
            sales
        };
    
        await post(`/data/albums`, body);
    
        page.redirect(`/catalog`);
    }
}