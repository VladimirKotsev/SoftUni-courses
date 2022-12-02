import { deleteRequest, getRequest} from "./utils.js";
import { render, html } from '../node_modules/lit-html/lit-html.js';

const body = document.querySelector(`body`);

export async function showDetailsPage(ctx){

    let pathname = ctx.path;
    let id = pathname.split(`/`)[2];

    const data = await getRequest(`data/catalog/${id}`);
    
    render(createHtml(data), body);

    if (sessionStorage.accessToken !== undefined){ // logged in
        body.querySelector(`div[class="container"]`).querySelectorAll(`a`).forEach(a => a.style.display = `inline-block`);
    }
    else{ // not logged in
        body.querySelector(`div[class="container"]`).querySelectorAll(`a`).forEach(a => a.style.display = `none`);
    }
}

function createHtml(data){

    const result = html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=".${data.img}" class="h1 img" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${data.make}</span></p>
                <p>Model: <span>${data.model}</span></p>
                <p>Year: <span>${data.year}</span></p>
                <p>Description: <span>${data.description}</span></p>
                <p>Price: <span>${data.price}</span></p>
                <p>Material: <span>${data.material}</span></p>
                <div>
                    <a href=/edit/${data._id} id=${data._ownerId} style="display: none" class="btn btn-info">Edit</a>
                    <a href="javascript:void(0)" id=${data._id} @click=${onDelete.bind()} style="display: none" class="btn btn-red">Delete</a>
                </div>
            </div>
        </div>
    </div>
    `;

    return result;
}

async function onDelete(event){

    event.preventDefault();

    let id = event.target.id;

    const data = await deleteRequest(`data/catalog/${id}`);
}