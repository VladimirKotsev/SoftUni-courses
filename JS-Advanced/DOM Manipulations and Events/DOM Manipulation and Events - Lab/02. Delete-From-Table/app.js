function deleteByEmail() {
    
    let table = document.getElementsByTagName(`tr`);

    let input = document.getElementsByName(`email`)[0].value;

    let result = document.getElementById(`result`);

    let length = table.length;
    for (let i = 1; i < length; i++){

        let email = table[i].getElementsByTagName(`td`)[1].textContent;

        if (email === input){

            console.log(table)
            table.removeChild(table[i]);
            table.removeChild(table[i]);

            result.textContent = `Deleted.`;
        }
        else{

            result.textContent = `Not found.`;
        }
    }
}