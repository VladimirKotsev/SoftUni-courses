function sort(arr, order){

    switch(order){
        case `asc`: arr = arr.sort((a, b) => a - b); break;
        case `desc`: arr = arr.sort((a, b) => b - a); break;
    }

    return arr;
}