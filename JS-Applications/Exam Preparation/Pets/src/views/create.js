import { page } from '../api/lib.js';
import { post } from '../api/api.js';
import { html, render } from '../api/lib.js';

const main = document.querySelector(`main`);

const createPage = html`
<section id="createPage">
    <form class="createForm">
        <img src="./images/cat-create.jpg">
            <div>
                <h2>Create PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" placeholder="Max">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" placeholder="2 years">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" placeholder="5kg">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
                </div>
                <button class="btn" type="submit">Create Pet</button>
            </div>
    </form>
</section>
`;

export async function showCreate(){

    render(createPage, main);

    const form = main.querySelector(`form`);
    form.addEventListener(`submit`, onCreate);
}

async function onCreate(event){

    event.preventDefault();

    const formData = new FormData(event.target);
    let { name, breed, age, weight, image } = Object.fromEntries(formData);

    if (validateForum()){

        const data = {
            name, 
            breed,
            age,
            weight,
            image
        };
    
        await post(`/data/pets`, data);
    
        page.redirect(`/`);
    }
    else{
        alert(`Cannot create an animal with empty fields!`);
    }

    function validateForum(){
        if (!name || !breed || !age || !weight || !image){
            return false;
        }
        
        return true;
    }
}
