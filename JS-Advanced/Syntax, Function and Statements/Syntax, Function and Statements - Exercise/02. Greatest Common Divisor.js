function GCD(num1, num2){

    let smaller = undefined;
    let bigger = undefined;
    if (num1 >= num2)
    {
        smaller = Number(num2);
        bigger = Number(num1);
    }
    else 
    {
        smaller = Number(num1);
        bigger = Number(num2);
    }

    let GCD = undefined;
    for (let i = 1; i <= smaller; i++)
    {
        if (smaller % i == 0)
        {
            if (bigger % i == 0)
            {
                GCD = Number(i);
            }
        }
    }

    console.log(GCD);
}