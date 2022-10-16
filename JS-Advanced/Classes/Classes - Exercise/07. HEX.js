class Hex{

    constructor(value){

        this.number = value;
    }

    valueOf(){

        return this.number;
    };

    toString(){

        return `0x` + this.number.toString(16).toUpperCase();
    };

    plus(obj){

        let newNumber = this.number + obj.number;
        return new Hex(newNumber);
    };

    minus(obj){

        let newNumber = this.number - obj.number;
        return new Hex(newNumber);
    };

    parse(hexString){

        let newNumber = parseInt(hexString, 16);
        return newNumber;
    }
}
