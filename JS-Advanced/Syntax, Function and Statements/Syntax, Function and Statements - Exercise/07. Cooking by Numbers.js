function cook(number, ...commands){
    commands.forEach(command => {
        switch (command){
            case `chop`:
                number /= 2;
                break;
            case `dice`: 
                number = Math.sqrt(number);
                break;
            case `spice`:
                number++;
                break;
            case `bake`:
                number *= 3;
                break; 
            case `fillet`:
                number *= 0.80;
                break;
        }
        console.log(number);
    });
}
