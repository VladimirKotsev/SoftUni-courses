 function rangeSum(num1, num2){

    let a = Number(num1);
    let b = Number(num2);

    sum = Number(0);
    for (let i = a; i <= b; i++){
        sum += i;
    }

    console.log(sum);
 }
