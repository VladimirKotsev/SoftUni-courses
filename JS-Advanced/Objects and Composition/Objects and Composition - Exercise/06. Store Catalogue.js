function storeCatalog(arr){

    let obj = {};
    for (let line of arr){

        let [product, price] = line.split(` : `);
        price = Number(price);
        let sortCategory = product[0].toUpperCase();
        let newProduct = {};

        if (obj[sortCategory] !== undefined){

            obj[sortCategory].push(line);
        }
        else{

            obj[sortCategory] = [line];
        }
    }

    for (let category of Object.keys(obj).sort()){
        console.log(category);
        for (let s of obj[category].sort()){

            let [product, price] = s.split(` : `);
            console.log(` ${product}: ${price}`);
        }
    }
}
