function half(arr){

    arr = arr.sort((a, b) => a - b);
    let result = [];

    let middle = Math.floor(arr.length / 2);
    result = arr.slice(middle);

    return result;
}