function pie(arr, pie1, pie2){

    let index1 = arr.indexOf(pie1);
    let index2 = arr.indexOf(pie2);

    let result = arr.slice(index1, index2 + 1);
    return result;
}