function solve(arr, n){

    let result = [];
    for (let i = 0; i < arr.length; i += n){

        result.push(arr[i]);
    }

    return result;
}