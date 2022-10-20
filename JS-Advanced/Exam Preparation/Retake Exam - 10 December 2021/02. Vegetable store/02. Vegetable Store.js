class VegetableStore{

    constructor(owner, location){

        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    };

    loadingVegetables(vegetables){

        let types = [];
        vegetables.forEach(element => {

            let [type, quantity, price] = element.split(` `);
            quantity = Number(quantity);
            price = Number(price);

            let product = this.availableProducts.find(x => x.type === type);
            if (product !== undefined){

                product.quantity += Number(quantity);

                if (price > product.price){

                    product.price = price;
                }
            }
            else{

                let product = {
                    type: type,
                    quantity: quantity,
                    price: price
                };

                this.availableProducts.push(product);
            }

            if (!types.includes(type)){

                types.push(type);
            }
        });

        return `Successfully added ${types.join(`, `)}`;
    };

    buyingVegetables(selectedProducts){

        let totalPrice = Number(0);
        selectedProducts.forEach(element => {

            let [type, quantity] = element.split(` `);
            quantity = Number(quantity);

            if (!this.availableProducts.find(x => x.type === type)){

                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            let product = this.availableProducts.find(x => x.type === type);

            if (quantity > product.quantity){

                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            totalPrice += quantity * product.price;
            product.quantity -= quantity;
        });

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    };

    rottingVegetable(type, quantity){

        if (!this.availableProducts.find(x => x.type === type)){

            throw new Error(`${type} is not available in the store.`)
        }

        let product = this.availableProducts.find(x => x.type === type);

        if (quantity > product.quantity){

            product.quantity = Number(0);

            return `The entire quantity of the ${type} has been removed.`;
        }
        else{

            product.quantity -= quantity;

            return `Some quantity of the ${type} has been removed.`;
        }
    };

    revision(){

        let result = `Available vegetables:\n`

        this.availableProducts.sort((a, b) => a.price - b.price);
        this.availableProducts.forEach(element => {
            
            result += `${element.type}-${element.quantity}-$${element.price}\n`;
        });

        result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;

        return result;
    }
}

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.buyingVegetables(["Okra 1"]));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
// console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"]));

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
// console.log(vegStore.revision());



