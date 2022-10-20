class Garden{

    constructor(spaceAvailable){

        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired){

        if (this.spaceAvailable < spaceRequired){

            throw new Error(`Not enough space in the garden.`);
        }

        let plant = {

            name: plantName,
            spaceRequired: spaceRequired,
            ripe: false,
            quantity: 0
        };

        this.plants.push(plant);
        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`
    };

    ripenPlant(plantName, quantity){

        quantity = Number(quantity);
        if (!this.plants.find(x => x.name == plantName)){

            throw new Error(`There is no ${plantName} in the garden.`);
        }

        let plant = this.plants.find(x => x.name == plantName);

        if (plant.ripe === true){

            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0){

            throw new Error(`The quantity cannot be zero or negative.`);
        }

        //success
        plant.ripe = true;
        plant.quantity += quantity;

        if (quantity === 1){

            return `${quantity} ${plantName} has successfully ripened.`
        }
        else{

            return `${quantity} ${plantName}s have successfully ripened.`;
        }

    };

    harvestPlant(plantName){

        if (!this.plants.find(x => x.name == plantName)){

            throw new Error(`There is no ${plantName} in the garden.`);
        }

        let plant = this.plants.find(x => x.name == plantName);
        if (plant.ripe === false){

            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        let index = 0;
        for (let i = 0; i < this.plants.length; i++){

            if (this.plants[i] === plant){

                index = i;
            }
        }

        let toFree = plant.spaceRequired;
        this.storage.push(this.plants.splice(index, 1)[0]);
        this.spaceAvailable += toFree;

        return `The ${plantName} has been successfully harvested.`;
    };

    generateReport(){

        let result = ``;
        result += `The garden has ${ this.spaceAvailable } free space left.\n`;

        this.plants.sort((a, b) => a.name - b.name);

        result += `Plants in the garden: `;

        for (let index = 0; index < this.plants.length; index++) {
            
            result += `${this.plants[index].name}, `;
        }
        result = result.slice(0, result.length - 2);

        result += `\n`;

        if (this.storage.length == 0){

            result += `Plants in storage: The storage is empty.`;
        }
        else{

            result += `Plants in storage: `;

            for (let index = 0; index < this.storage.length; index++) {
                
                result += this.storage[index].name + ` (${this.storage[index].quantity}), `;
            }

            result = result.slice(0, result.length - 2);
        }

        return result;
    };
}

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('olive', 50));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('orange', 4));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('olive', 30));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('cucumber', -5));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('olive'));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('raspberry'));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('orange'));
// console.log(myGarden.generateReport());






