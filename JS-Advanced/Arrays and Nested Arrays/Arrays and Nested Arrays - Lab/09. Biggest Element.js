function element(matrix){
    let max = Number(-100000);

    matrix.forEach(element => {
        element.forEach(number => {
            if (number > max){
                max = Number(number);
            }
        });
    });

    return max;
}
