function toObj(arr){

    let obj = {};
    for (let index = 0; index < arr.length; index += 2) {
        
        obj[arr[index]] = Number(arr[index + 1]);
    }

    return obj;
}