function solve() {
   
   let products = document.getElementsByClassName(`product`);

   let checkout = document.getElementsByTagName(`textarea`)[0];

   let stop = false;

   let total = Number(0);
   let cart = [];
   
   //debugger;
   
   for (let i = 0; i < products.length; i++) {
      
      products[i].getElementsByClassName(`add-product`)[0].addEventListener(`click`, function(){
         
         if (stop === true){
            return;
         }
         
         let name = products[i].getElementsByClassName(`product-title`)[0].textContent;
         let price = Number(products[i].getElementsByClassName(`product-line-price`)[0].textContent);
         
         checkout.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`
         total += price;
   
         if (!cart.includes(name)){
   
            cart.push(name);
         }
      });
   }

   let btn = document.getElementsByClassName(`checkout`)[0];

   btn.addEventListener(`click`, function(){

      if (stop === true){
         return;
      }

      checkout.value += `You bought ${cart.join(`, `)} for ${total.toFixed(2)}.`;

      stop = true;
   });
}