function solve(arr){

    let result = [];
    for (let i = 0; i < arr.length; i++){

        if (arr[i] === `add`){

            result.push(i + 1);
        }
        else if (arr[i] === `remove`){

            if (result.length === 0){

                console.log(`Empty`);
                return;
            }

            result.pop();
        }
    }

    console.log(result.join(`\n`));
}