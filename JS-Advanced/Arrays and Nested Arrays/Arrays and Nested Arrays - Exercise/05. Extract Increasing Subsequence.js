function sortArray(arr){

    let max = Number(0);
    for (let i = 0; i < arr.length; i++){

        if (max > arr[i]){

            arr.splice(i , 1);
            i--;
        }
        else{

            max = arr[i];
        }
    }

    return arr;
}