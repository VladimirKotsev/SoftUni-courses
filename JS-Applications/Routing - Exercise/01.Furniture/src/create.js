import { createHtml, navigation, postRequest } from "./utils.js";
import { render, html } from '../node_modules/lit-html/lit-html.js';
import  page  from '../node_modules/page/page.mjs';

const body = document.querySelector(`body`);

export function showCreatePage(){
    
    navigation();
    render(createHtml(`create`), body);
    
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


