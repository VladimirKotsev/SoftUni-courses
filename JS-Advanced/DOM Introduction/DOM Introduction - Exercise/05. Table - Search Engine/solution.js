function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      
      let body = document.querySelector(`tbody`);
      let tr = body.getElementsByTagName(`tr`)
      
      let input = document.getElementById(`searchField`);

      for (let info of tr){

         info.classList.remove(`select`);

      }

      for (let info of tr){

         if (info.textContent.match(input.value)){

            info.classList.add("select");          
         }
      }  
      
      input.value = ``;
   }
}