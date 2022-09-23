function solve(arr){

    let obj = {
        plus(a, b){
            return a + b;
        },
        difference(a, b){
            return a - b;
        },
        multiply(a, b){
            return a * b;
        },
        devision(a, b){
            return a / b;
        }
    }

    let nums = [];
    let operands = [];

    for (let c of arr){

        if (typeof(c) == `number`){

            nums.push(Number(c));
        }
        else{

            operands.push(c);
        }
    }

    if (nums.length > operands.length + 1){
        
        console.log("Error: too many operands!");
        return;
    }
    else if (nums.length == operands.length){
        
        console.log("Error: not enough operands!");
        return;
    }

    nums = [];
    operands = [];

    for (let c of arr){

        if (typeof(c) == `number`){

            nums.push(Number(c));
        }
        else{
            if (nums.length >= 2){

                operands.push(c);
                let b = nums.pop();
                let a = nums.pop();
                let operant = operands.shift();
    
                nums.push(Math.round(operation(operant, a, b)));
            }
            else{
                
                console.log("Error: not enough operands!");
                return;
            }
        }
    }

    

    function operation(operator, a, b){
        if (operator === `+`){

            return obj.plus(a, b);
        }
        else if (operator === `-`){

            return obj.difference(a, b);
        }
        else if (operator === `*`){
            
            return obj.multiply(a, b);
        }
        else if (operator === `/`){
            
            return obj.devision(a, b);
        }
    }

    console.log(nums.shift());
}

