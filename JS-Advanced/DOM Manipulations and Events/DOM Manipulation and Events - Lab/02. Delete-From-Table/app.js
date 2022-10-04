function deleteByEmail() {
    
    let table = document.getElementsByTagName(`tbody`)[0];
    let tr = table.getElementsByTagName(`tr`);

    let input = document.getElementsByName(`email`)[0].value;

    let result = document.getElementById(`result`);

    debugger;
    let length = tr.length;
    for (let i = 0; i < length; i++){

        let email = tr[i].getElementsByTagName(`td`)[1].textContent;

        if (email === input){
            
            table.removeChild(table.getElementsByTagName(`tr`)[i]);

            result.textContent = `Deleted.`;
        }
    }

    if (result.textContent !== `Deleted.`){

        result.textContent = `Not found.`;
    }
}