import { put, get } from '../api/api.js';
import { render, html, page } from '../api/lib.js';

const main = document.querySelector(`main`);

let id;

const editPage = (pet) => html`
<section id="editPage">
    <form class="editForm">
        <img src="./images/editpage-dog.jpg">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" value=${pet.name}>
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" value=${pet.breed}>
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" value=${pet.age}>
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" value=${pet.weight}>
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" value=${pet.image}>
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
    </form>
</section>
`;

export async function showEdit(ctx) {
    id = ctx.params.id;
    const currentPet = await get(`/data/pets/${id}`);
    
    render(editPage(currentPet), main);

    const form = main.querySelector(`form`);
    form.addEventListener(`submit`, onEdit);
}

async function onEdit(event){

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
    
        await put(`/data/pets/${id}`, data);
    
        page.redirect(`/catalog/${id}`);
    }

    function validateForum(){
        if (!name || !breed || !age || !weight || !image){
            return false;
        }
        
        return true;
    }
}