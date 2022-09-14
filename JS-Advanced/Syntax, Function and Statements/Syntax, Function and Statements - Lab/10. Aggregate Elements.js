function aggregate(array){
    //sum
    let sum = Number(0)
    array.forEach(element => {
        sum += Number(element);
    });
    console.log(sum);

    //inverse values
    let sumInverse = Number(0);
    array.forEach(element => {
        sumInverse += Number(1 / element);
    });
    console.log(sumInverse);

    //concat
    let concat = ``;
    array.forEach(element => {
        concat += element;
    });
    console.log(concat);
}
