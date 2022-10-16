function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {

      let input = document.getElementById(`inputs`).getElementsByTagName(`textarea`)[0].value;
      
      input = JSON.parse(input);

      let output = document.getElementById(`outputs`)
      let bestRestaurant = output.querySelector(`#bestRestaurant`).getElementsByTagName(`p`)[0];
      let workers = output.querySelector(`#workers`).getElementsByTagName(`p`)[0];
      
      let restaurants = [];

      input.forEach(element => {

         let restaurant = {};
         
         let [restaurantName, workers] = element.split(` - `);
         
         workers = workers.split(`, `);

         if (restaurants.find(x => x.name == restaurantName)){
            
            workers.forEach(worker => {
               
               let [name, salary] = worker.split(` `);
               restaurants.find(x => x.name == restaurantName).workers.push( {name: name, salary: Number(salary) } );
            });
         }
         else{
            
            restaurants.push({
               name: restaurantName,
               avgSalary(){

                  let max = Number(0);
                  let avg = Number(0);

                  let sum = 0;
                  this.workers.forEach(worker => {
            
                     sum += worker.salary;
                  });
            
                  avg = sum / this.workers.length;

                  return avg;
               },
               bestSalary(){

                  let max = Number(0);
                  
                  this.workers.forEach(element => {

                     if (element.salary > max){

                        max = element.salary;
                     }
                  });

                  return max;
               }

            });
            restaurants.find(x => x.name == restaurantName).workers = [];

            workers.forEach(worker => {
               
               let [name, salary] = worker.split(` `);
               restaurants.find(x => x.name == restaurantName).workers.push( {name: name, salary: Number(salary) } );
            });
         }
         
      });
      

      restaurants.sort((a, b) => b.avgSalary() - a.avgSalary());
      let restaurant = restaurants[0];
      
      bestRestaurant.textContent = `Name: ${restaurant.name} Average Salary: ${restaurant.avgSalary().toFixed(2)} Best Salary: ${restaurant.bestSalary().toFixed(2)}`;
      
      let result = ``;
      restaurant.workers.sort((a, b) => b.salary - a.salary);
      restaurant.workers.forEach(worker => {
         
         result += `Name: ${worker.name} With Salary: ${worker.salary} `;
      });

      workers.textContent = result.trimEnd();
   }
}