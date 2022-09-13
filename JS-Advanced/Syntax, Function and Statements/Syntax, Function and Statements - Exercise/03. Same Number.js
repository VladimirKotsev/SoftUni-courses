function sameNumbers(number){

    let numberString = number.toString();
    let digit = Number(numberString[0]);
    let sumOfDigits = Number(digit);
    let check = true;

    for (let i = 1; i < numberString.length; i++)
    {
        if (numberString[i] != digit)
        {
            check = false;
        }
        sumOfDigits += Number(numberString[i]);
    }

    console.log(check);
    console.log(sumOfDigits);
}