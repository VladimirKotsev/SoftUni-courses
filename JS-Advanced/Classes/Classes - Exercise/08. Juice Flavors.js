function juices(arr){

    let juices = [];
    let types = [];
    class Juice{

        constructor(type, litters){

            this.type = type;
            this.litters = Number(litters);
        }
    }

    arr.forEach(element => {
        
        let info = element.split(` => `)
        if (juices.find(x => x.type == info[0])){

            juices.find(x => x.type == info[0]).litters += Number(info[1]);
            if (juices.find(x => x.type == info[0]).litters >= 1000 && !types.includes(info[0])) { types.push(info[0]); }
        }
        else{

            if (Number(info[1]) >= 1000){ types.push(info[0]); }
            let juice = new Juice(info[0], info[1]);
            juices.push(juice);
        }
    });

    types.forEach(element => {

        if (juices.find(x => x.type == element).litters >= 1000){

            let bottles = juices.find(x => x.type == element).litters / 1000;
            bottles = Math.floor(bottles);
            console.log(`${element} => ${bottles}`);
        }
    });

}