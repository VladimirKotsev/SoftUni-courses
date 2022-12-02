import { towns } from './towns.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';

let div = document.querySelector(`#towns`);

let searchBtn = document.querySelector(`button`);
searchBtn.addEventListener(`click`, search);

let input = document.querySelector(`input`);

let resultField = document.querySelector(`#result`);

function search(event) {
   
   event.preventDefault();

   let ul = div.querySelector(`ul`);
   let count = 0;

   for (let i = 0; i < ul.children.length; i++){

      let li = ul.children[i];
      if (li.textContent.match(input.value)){

         li.className = `active`;
         count++;
      }
   }

   resultField.textContent = `${count} matches found`;
}

function createHtml(){
   
   const result = html`
   <ul>
      ${towns.map(town => html`<li>${town}</li>`)}
      </ul>
      `
      
      return result;
}

function renderHtml(){
   
   let template = createHtml();
   render(template, div);
}

renderHtml();
