class Circle{

    constructor(radius){

        this.radius = radius;
        this.diameter = radius * 2;

    };

    get diameter(){

        return this._diameter;
    };
    
    set diameter(value){

        this._diameter = value;
        this._radius = value / 2;
    };

    get radius(){
        
        return this._radius;
    }

    set radius(value){

        this._radius = value;
    }

    get area(){
        
        return Number(Math.PI * Math.pow(this._radius, 2));
    }
}
