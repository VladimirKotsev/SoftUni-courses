function factory(car){
    let obj = {};
    obj.model = car.model;

    chooseEngine(car, obj);
    createCarriage(car, obj);
    createWheels(car, obj);
    
    return obj;

    function createWheels(car, obj){
        if (car.wheelsize % 2 == 0){
            car.wheelsize--;
        }

        let wheel = car.wheelsize;
        obj.wheels = [wheel, wheel, wheel, wheel];
    }

    function createCarriage(car, obj){
        if (car.carriage === `hatchback`){
            obj.carriage = {type: `hatchback`, color: car.color};
        }
        else if (car.carriage === `coupe`){
            obj.carriage = {type: `coupe`, color: car.color};
        }
    }

    function chooseEngine(car, obj){

        let engineEnum = {
            small: { power: 90, volume: 1800 },
            normal: { power: 120, volume: 2400 },
            monster: { power: 200, volume: 3500 }
        }

        if (car.power <= 90){
            obj.engine = engineEnum.small;
        }
        else if (car.power <= 120){
            obj.engine = engineEnum.normal;
        }
        else if (car.power > 120){
            obj.engine = engineEnum.monster;
        }

    }
}