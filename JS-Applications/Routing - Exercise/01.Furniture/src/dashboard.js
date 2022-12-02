import { getRequest, navigation } from './utils.js'
import { render, html } from '../node_modules/lit-html/lit-html.js';

const body = document.querySelector(`body`);

export async function showDashboardPage(){
    
    navigation();
    
    const data = await getRequest(`data/catalog`);
    render(createHtml(data), body);
}

function createHtml(data){

    const result = html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${data.map(item => html`
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${item.img} />
                        <p>${item.description}</p>
                        <footer>
                            <p>Price: <span>${item.price} $</span></p>
                        </footer>
                        <div>
                            <a href="/details/${item._id}" id=${item._id} class="btn btn-info">Details</a>
                        </div>
                    </div>
                </div>
            </div>`)}                        
        </div>
    </div>`;

    return result;
}