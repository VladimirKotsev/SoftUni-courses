function largestNumber(a, b, c){

    let number = 0;
    if (a >= b && a >= c)
    {
        number = a;
    }
    else if (b >= a && b >= c)
    {
        number = b;
    }
    else
    {
        number = c;
    }
    console.log(`The largest number is ${number}.`)
}