function info(...params){

    let obj = {};

    for (let index = 0; index < params.length; index++) {
        
        console.log(`${typeof(params[index])}: ${params[index]}`);

        if (obj[typeof(params[index])] !== undefined){

            obj[typeof(params[index])]++;
        }
        else{

            obj[typeof(params[index])] = Number(1);
        }
    }

    let sorted = [];
    for (var t in obj) {

        sorted.push([t, obj[t]]);
    }
    
    sorted = sorted.sort((a, b) => b[1] - a[1]);
    for (let key of sorted) {
        
        console.log(`${key[0]} = ${key[1]}`);
    }

}