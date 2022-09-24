function sort(arr){

    let result = [];
    arr.sort((a, b) => a - b);
    let length = arr.length;

    for (let i = 0; i < length; i++){

        if (i % 2 === 0){

            result.push(arr.shift());
        }
        else{

            result.push(arr.pop());

        }
    }

    return result;
}