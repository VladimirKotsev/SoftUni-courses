function neighbors(matrix){
    let pairs = Number(0);

    for (let row = 0; row < matrix.length; row++ ){
        for (let col = 0; col < matrix[row].length; col++){

            if (isValid(row - 1, col, matrix)){
                if (matrix[row][col] === matrix[row - 1][col]){
                    pairs++;
                }
            }
            if (isValid(row + 1, col, matrix)){
                if (matrix[row][col] === matrix[row + 1][col]){
                    pairs++;
                }
            }
            if (isValid(row, col + 1, matrix)){
                if (matrix[row][col] === matrix[row][col + 1]){
                    pairs++;
                }
            }
            if (isValid(row, col - 1, matrix)){
                if (matrix[row][col] === matrix[row][col - 1]){
                    pairs++;
                }
            }
        }
    }

    function isValid(row, col, matrix){
        if (row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length){
            return true;
        }
        return false;
    }

    return pairs / 2;
}

