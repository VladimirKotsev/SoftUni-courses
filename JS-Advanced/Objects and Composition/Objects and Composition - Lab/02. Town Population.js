function registry(input){
    let towns = {};

    for (let town of input){

        let [name, population] = town.split(` <-> `);
        population = Number(population);

        if (towns[name] != undefined){
            towns[name] += population;
        }
        else{
            towns[name] = population;
        }
    }

    for(let t in towns){
        console.log(`${t} : ${towns[t]}`);
    }

}
