function cheapestPrice(arr){

    let obj = {};

    for (let line of arr){
        
        let [town, product, price] = line.split(` | `);
        price = Number(price);

        if (obj[product] !== undefined){

            if (price < obj[product].price){
                obj[product] = {town: town, price: price};
            }
        }
        else{

            obj[product] = {town: town, price: price};
        }
    }

    for (let prd in obj){
        
        console.log(`${prd} -> ${obj[prd].price} (${obj[prd].town})`)
    }
}