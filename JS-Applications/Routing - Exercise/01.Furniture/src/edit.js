import { html, render } from '../node_modules/lit-html/lit-html.js';
import { getRequest } from './utils.js';

const body = document.querySelector(`body`);

export async function showEditPage(ctx){

    let pathname = ctx.path;
    let id = pathname.split(`/`)[2];
    console.log(id);
    const data = await getRequest(`data/catalog/${id}`);
    
    render(createHtml(data), body);

    let make = body.querySelector(`#new-make`);
    let model = body.querySelector(`#new-model`);
    let year = body.querySelector(`#new-year`);
    let description = body.querySelector(`#new-description`);
    let price = body.querySelector(`#new-price`);
    let image = body.querySelector(`#new-image`);
    let material = body.querySelector(`#new-material`);
    
    attackEvents();

    let btn = body.querySelector(`input[type="submit"]`);
    btn.addEventListener(`click`, onCreate);


    function attackEvents(){
    
        make.addEventListener(`change`, (e) => {
            if (e.target.value.length < 4){ 
                make.classList.add(`is-invalid`); 
                make.classList.remove(`is-valid`)
            }
            else { 
                make.classList.remove(`is-invalid`);
                make.classList.add(`is-valid`); 
            }
        });
    
        model.addEventListener(`change`, (e) => {
            if (e.target.value.length < 4){ 
                model.classList.add(`is-invalid`); 
                model.classList.remove(`is-valid`); 
            }
            else { 
                model.classList.remove(`is-invalid`);
                model.classList.add(`is-valid`); 
            }
        });
    
        description.addEventListener(`change`, (e) => {
            if (e.target.value.length <= 10){             
                description.classList.add(`is-invalid`); 
                description.classList.remove(`is-valid`); 
            }
            else { 
                description.classList.remove(`is-invalid`);
                description.classList.add(`is-valid`); 
            }
        }); 
    
        year.addEventListener(`change`, (e) => {
            if (e.target.value < 1950 || e.target.value > 2050){             
                year.classList.add(`is-invalid`); 
                year.classList.remove(`is-valid`); 
            }
            else { 
                year.classList.remove(`is-invalid`);
                year.classList.add(`is-valid`); 
            }
        }); 
    
        price.addEventListener(`change`, (e) => {
            if (e.target.value < 0 || !e.target.value){             
                price.classList.add(`is-invalid`); 
                price.classList.remove(`is-valid`); 
            }
            else { 
                price.classList.remove(`is-invalid`);
                price.classList.add(`is-valid`); 
            }
        }); 
    
        image.addEventListener(`change`, (e) => {
            if (!e.target.value){             
                image.classList.add(`is-invalid`); 
                image.classList.remove(`is-valid`); 
            }
            else { 
                image.classList.remove(`is-invalid`);
                image.classList.add(`is-valid`); 
            }
        }); 
    }
    async function onCreate(event){
    
        event.preventDefault();
    
        if (validate(make, model, year, description, price, image)){
    
            let body = {
    
                make: make,
                model: model,
                year: year,
                description: description,
                price: price,
                image: image,
                material: material
            };
    
           
            let data = await postRequest(`data/catalog`, body);
            
            page.redirect(`/`);
        }
    
    
        function validate(){
        
            if (make.classList.contains(`is-invalid`) || model.classList.contains(`is-invalid`) || year.classList.contains(`is-invalid`) || description.classList.contains(`is-invalid`)
            || price.classList.contains(`is-invalid`) || image.classList.contains(`is-invalid`)){
    
                return false;
            }
    
            return true;
        }
    }
}

function createHtml(data){

    const result = html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control" id="new-make" type="text" name="make" value=${data.make}>
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control" id="new-model" type="text" name="model" value=${data.model}>
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control" id="new-year" type="number" name="year" value=${data.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control" id="new-description" type="text" name="description" value=${data.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control" id="new-price" type="number" name="price" value=${data.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control" id="new-image" type="text" name="img" value=${data.img}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material" value=${data.materials}>
                    </div>
                    <input type="submit" class="btn btn-info" value="Edit" />
                </div>
            </div>
        </form>
    </div>`;

    return result;
}