function diagonals(matrix){

    let mainIndex = Number(0); 
    let secondIndex = Number(matrix[0].length - 1);

    let mainSum = Number(0);
    let secondSum = Number(0);

    matrix.forEach(element => {

        mainSum += Number(element[mainIndex]);
        secondSum += Number(element[secondIndex]);

        mainIndex++;
        secondIndex--;
    });

    console.log(`${mainSum} ${secondSum}`);
}