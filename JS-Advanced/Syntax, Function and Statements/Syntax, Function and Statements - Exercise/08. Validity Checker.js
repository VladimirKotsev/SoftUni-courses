function checker(...params){
    x1 = Number(params[0]);
    y1 = Number(params[1]);
    x2 = Number(params[2]);
    y2 = Number(params[3]);

    let result = Math.sqrt(Math.pow(Number(0) - x1, 2) + Math.pow(Number(0) - y1, 2));
    if (result % 1 == 0){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`)
    }

    result = Math.sqrt(Math.pow(x2 - Number(0), 2) + Math.pow(y2 - Number(0), 2));
    if (result % 1 == 0){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }

    result = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    if (result % 1 == 0){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }
}
