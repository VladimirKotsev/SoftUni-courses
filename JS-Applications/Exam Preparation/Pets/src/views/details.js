import { del, get } from '../api/api.js';
import { html, render, page } from '../api/lib.js';
import { getUserData } from '../utils.js';

const main = document.querySelector(`main`);
let id;

const detailsPage = (pet) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            <div class="actionBtn">
                <!-- Only for registered user and creator of the pets-->
                ${getUserData()._id == pet._ownerId ? html`
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a href="javascript:void(0)" @click=${onDelete} class="remove">Delete</a>
                `:
                html`
                
                `}
                <!--(Bonus Part) Only for no creator and user-->
                <a href="javascript:void(0)" @click=${onDonate} id=${pet._ownerId} class="donate">Donate</a>
            </div>
        </div>
    </div>
</section>
`;
async function onDonate(event){

    event.preventDefault();

    if (getUserData()._id !== event.target.id){
        event.target.style.display = `none`;
    }
}

async function onDelete(event){

    event.preventDefault();
    await del(`/data/pets/${id}`);

    page.redirect(`/`);
}

export async function showDetails(ctx) {

    id = ctx.params.id;
    const currentPet = await get(`/data/pets/${id}`);

    render(detailsPage(currentPet), main);
    links();
}

function links(){

    if (getUserData() === null){
        main.querySelectorAll(`a`).forEach(x => x.style.display = `none`);
    }
    else{
        main.querySelectorAll(`a`).forEach(x => x.style.display = `inline-block`);
    }
}