function magicMatrix(matrix){

    let sum = 0;
    let currentRow = 0;
    let currentCol = 0;

    //rows
    for (let row = 0; row < matrix.length; row++){

        currentRow = 0;
        for (let col = 0; col < matrix[row].length; col++){

            currentRow += matrix[row][col];
            currentCol = 0;
            for (let row1 = 0; row1 < matrix.length; row1++){

                currentCol += matrix[row1][col];
            }

        }
        if (row === 0){

            sum = currentRow;
        }

        if (currentCol !== currentRow ){

            return false;
        }
        else if (currentCol !== sum){

            return false;
        }
        else if (currentRow !== sum){

            return false;
        }

    }

    return true;
}