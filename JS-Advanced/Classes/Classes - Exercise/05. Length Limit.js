class Stringer{

    constructor(string, length){

        this.innerString = string;
        this.innerLength = Number(length);
    }

    increase(length){

        this.innerLength += length;
    };

    decrease(length){

        this.innerLength -= length;

        if (this.innerLength < 0){

            this.innerLength = 0;
        }
    }

    toString(){

        if (this.innerLength === 0){

            return `...`;
        }

        if (this.innerLength >= this.innerString.length){

            return this.innerString.substring(0, this.innerLength);
        }
      
        return this.innerString.substring(0, this.innerLength) + `...`;
    }
}

