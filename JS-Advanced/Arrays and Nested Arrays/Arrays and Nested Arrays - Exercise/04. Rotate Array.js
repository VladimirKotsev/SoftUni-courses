function rotation(arr, n){

    for (let i = 1; i <= n; i++){

        arr.unshift(arr.pop());
    }

    console.log(arr.join(` `));
}