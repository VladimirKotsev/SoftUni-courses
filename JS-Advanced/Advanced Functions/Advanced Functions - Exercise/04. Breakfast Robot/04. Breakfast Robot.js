function solution(){

    let recipes = {

        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        eggs: {protein: 5, fat: 1, flavour: 1},
        turkey: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    };

    let stock = {

        protein: Number(0),
        carbohydrate: Number(0),
        fat: Number(0),
        flavour: Number(0),
    }

    let robot = {

        restock: function(microElement, quantity) {

            stock[microElement] += Number(quantity); 
            return `Success`; 
        },
        prepare: function(recipe, quantity) {

            let ingredients = recipes[recipe];
            let enough = true;

            for (let element in ingredients) {
                
                if (stock[element] < ingredients[element] * quantity){

                    return `Error: not enough ${element} in stock`;
                    enough = false;
                    break;
                }
            }

            if (enough){
                
                for (let element in ingredients) {
                
                    stock[element] -= Number(ingredients[element] * quantity)
                }

                return `Success`;
            }
        },
        report: function() { return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}` }
    };

    return function(input){


        let cmd = input.split(` `)[0];
        let recipeOrElement = input.split(` `)[1];
        let quantity = input.split(` `)[2];

        let result = ``;
        if (cmd === `prepare`){

            result = robot.prepare(recipeOrElement, quantity);
        }
        else if (cmd === `restock`){

            result = robot.restock(recipeOrElement, quantity);
        }
        else if (cmd === `report`){

            result = robot.report();
        }

        return result;
    }

}
