function smallest(arr){

    let sorted = arr.sort((a, b) => a - b);

    console.log(sorted[0] + ` ` + sorted[1]);
}
