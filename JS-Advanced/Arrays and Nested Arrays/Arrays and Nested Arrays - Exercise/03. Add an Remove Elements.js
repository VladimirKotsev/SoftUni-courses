function solve(arr){

    let result = [];
    for (let i = 0; i < arr.length; i++){

        if (arr[i] === `add`){

            result.push(i + 1);
        }
        else{
            result.pop();
        }
    }

    if (result.length === 0){

        console.log(`Empty`);
        return;
    }

    for(let number of result){

        console.log(number);
    }
}