function company(arr){

    class Car{

        constructor(brand, model, quantity){

            this.brand = brand;
            this.cars = [ { model: model, quantity: Number(quantity)} ];
        }
    }

    let cars = [];

    arr.forEach(element => {
        
        let [brand, model, quantity] = element.split(` | `);
        quantity = Number(quantity);

        if(cars.find(x => x.brand == brand)){

            if(cars.find(x => x.brand == brand).cars.find(x => x.model == model)){

                cars.find(x => x.brand == brand).cars.find(x => x.model == model).quantity += quantity;
            }
            else{

                cars.find(x => x.brand == brand).cars.push( {model: model, quantity: quantity} );
            }
        }
        else{

            cars.push(new Car(brand, model, quantity));
        }
    });

    cars.forEach(element => {
        
        console.log(element.brand);
        element.cars.forEach(car => {
            
            console.log(`###` + car.model + ` -> ` + car.quantity);
        });
    });

}