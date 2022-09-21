function factory(library, orders){
    let products = [];
    
    for (let i = 0; i < orders.length; i++){
 
        let myObj = {};
        myObj[`name`] = orders[i].template.name;
        orders[i].parts.forEach(element => {
            myObj[element] = library[element];
        });
        products.push(myObj);
    }

    return products;
  }
  