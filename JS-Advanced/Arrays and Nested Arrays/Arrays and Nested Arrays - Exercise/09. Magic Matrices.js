function magicMatrix(matrix){

    let sum = 0;
    
    //rows
    for (let row = 0; row < matrix.length; row++){
        
        let currentRow = 0;

        for(let col = 0; col < matrix.length; col++){

            currentRow += matrix[row][col];
        }

        if (row === 0){

            sum = currentRow
        }

        if (currentRow !== sum){ return false; }
    }

    //cols
    for (let col = 0; col < matrix.length; col++){

        let currentCol = 0;

        for (let row = 0; row < matrix.length; row++){

            currentCol += matrix[row][col];
        }

        if (currentCol !== sum){ return false; }
    }

    return true;
}