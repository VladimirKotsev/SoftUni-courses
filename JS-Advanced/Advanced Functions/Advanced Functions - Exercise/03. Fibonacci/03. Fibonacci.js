function getFibonator(){

    let last = Number(0);
    let lastLast = Number(1);

    return function() {

        let number = last + lastLast;

        lastLast = last;
        last = number;

        return number;
    };
}
console.log(fib()); // 13
