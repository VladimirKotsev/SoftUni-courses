function solve(){

    let htmlInput = document.getElementById(`text`);
    let input = htmlInput.value.split(` `);
    debugger;

    let htmlConvention = document.getElementById(`naming-convention`);
    let convention = htmlConvention.value;

    let span = document.getElementById(`result`);

    if (convention === `Pascal Case`){

        for (let i = 0; i < input.length; i++){

            input[i] = input[i][0].toUpperCase() + input[i].substring(1).toLowerCase();

        }

        span.textContent = input.join(``);
    }
    else if (convention === `Camel Case`){

        let result = ``;
        
        result += input[0].toLowerCase();

        for (let i = 1; i < input.length; i++){

            result += input[i][0].toUpperCase();

            for (let j = 1; j < input[i].length; j++){

                result += input[i][j].toLowerCase();
            }
        }

        span.textContent = result;
    }
    else{

        span.textContent = `Error!`;
        return;
    }

}