function bargain(type, weight, price){

    let fruitType = type;
    let fruitWeight = weight / 1000;
    let fruitPrice = price;
    
    let neededPrice = fruitPrice * fruitWeight;
    console.log(`I need $${neededPrice.toFixed(2)} to buy ${fruitWeight.toFixed(2)} kilograms ${type}.`)
}