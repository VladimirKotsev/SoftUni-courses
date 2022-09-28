function search(){

   let list = document.getElementById(`towns`).getElementsByTagName(`li`);
   let defaultList = ;
   let clear = false;

   if (clear === true){

      list = defaultList;
   }

   let htmlInput = document.getElementById(`searchText`);
   let input = htmlInput.value;

   let counter = Number(0);
   for (let i = 0; i < list.length; i++){

      if (list[i].textContent.match(input)){

         list[i].style.textDecoration = `underline`;
         list[i] += `bold`;

         counter++;
      }
   }

   document.getElementById(`result`).textContent = `${counter} matches found`;
   clear = true;
}
