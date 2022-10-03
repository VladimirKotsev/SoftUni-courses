function search(){

   let list = document.getElementById(`towns`).getElementsByTagName(`li`);

   for (let text of list){

      text.style.fontWeight = "";
      text.style.textDecoration = `none`;
   }

   let htmlInput = document.getElementById(`searchText`);
   let input = htmlInput.value;

   let counter = Number(0);
   for (let i = 0; i < list.length; i++){

      if (list[i].textContent.match(input)){

         list[i].style.textDecoration = `underline`;
         list[i].style.fontWeight = `bold`;

         counter++;
      }
   }

   document.getElementById(`result`).textContent = `${counter} matches found`;
}
