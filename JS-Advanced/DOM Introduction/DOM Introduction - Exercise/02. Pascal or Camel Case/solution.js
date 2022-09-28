function solve(){

    let htmlInput = document.getElementById(`text`);
    let input = htmlInput.value.split(` `);

    let htmlConvention = document.getElementById(`naming-convention`);
    let convention = htmlConvention.value;

    let span = document.getElementById(`result`);

    if (convention === `Pascal Case`){

        for (let i = 0; i < input.length; i++){

            input[i] = input[i][0].toUpperCase() + input[i].substring(1).toLowerCase();

        }
    }
    else if (convention === `Camel Case`){

        for (let i = 1; i < input.length; i++){

            input[i] = input[i][0].toUpperCase() + input[i].substring(1).toLowerCase();
        }
    }
    else{

        span.textContent = `Error!`;
        return;
    }

    span.textContent = input.join(``);
}