function JSon(arr){

    let result = [];
    let arguments = arr[0].split(/\|\ |\ \|\ |\ \|/g);
    
    for (let i = 1; i < arr.length; i++){

        let obj = {};
        let line = arr[i].split(/\|\ |\ \|\ |\ \|/g);

        obj[arguments[1]] = line[1];

        for (let j = 2; j < line.length - 1; j++){

            line[j] = Number(line[j]);
            obj[arguments[j]] = line[j].toFixed(2);
            obj[arguments[j]] = Number(obj[arguments[j]]);
        }
        result.push(obj);
    }

    result = JSON.stringify(result);

    return result;
}