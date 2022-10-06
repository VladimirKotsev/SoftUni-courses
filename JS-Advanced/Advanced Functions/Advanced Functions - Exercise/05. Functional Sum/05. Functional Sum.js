function add(number){

    let sum = Number(number);

    function calc(number1){

        sum += number1;
        return calc;
    }

    calc.toString = () => sum;
    return calc;

}
