import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = `http://localhost:3030/jsonstore/advanced/table`;

document.querySelector('#searchBtn').addEventListener('click', onClick);
let tbody = document.querySelector(`tbody`);
let input = document.getElementById(`searchField`);

const data = await getRequest();
loadTable(data);

function loadTable(data){

   data = convertToArray(data);

   let result = createHtml(data);

   render(result, tbody);
}

function convertToArray(data){

   let array = [];
   for (const key in data) {
       
      array.push(data[key]);
   }

   return array;
}

function createHtml(data){

   const result = html`
      ${data.map(item => html`
         <tr>
            <td>${item.firstName + " " + item.lastName}</td>
            <td>${item.email}</td>
            <td>${item.course}</td>
         </tr>
      `)}
   `;

   return result;
}

async function getRequest(){

   const response = await fetch(url);
   const data = await response.json();

   return data;
}

function onClick() {
   
   let trs = tbody.getElementsByTagName(`tr`);

   for (let tr of trs){

      if (tr.textContent.toLowerCase().match(input.value.toLowerCase())){
         tr.classList.add("select");          
      }
      else{
         tr.classList.remove(`select`);      
      }
   }  
   
   input.value = ``;
}

