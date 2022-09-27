function sumTable() {

    let td = document.getElementById(`sum`);
    let result = Number(0);

    let prices = document.getElementsByTagName(`td`);

    for (let i = 0; i < prices.length; i++){

        if (i % 2 !== 0){

            result += Number(prices[i].textContent);
        }
    }

    td.textContent = result;
}