function sumOfSequence(n, k){
    let arr = [];
    arr[0] = 1;

    for (let i = 1; i < n; i ++) {

        let sum = Number(0);
        for (let j = i - 1; j >= i - k; j--){
            
            if (j == -1){
                break;
            }

            sum += Number(arr[j]);
        }

        arr[i] = Number(sum);
    }

    return arr;
}
