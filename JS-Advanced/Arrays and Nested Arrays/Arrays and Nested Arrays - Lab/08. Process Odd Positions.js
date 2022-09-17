function oddArraySum(arr){

    let result = [];
    for (let i = 1; i < arr.length; i += 2){
        result.push(arr[i]);
    }

    result = result.map(n => n * 2);
    result.reverse();

    console.log(result.join(` `));
}
