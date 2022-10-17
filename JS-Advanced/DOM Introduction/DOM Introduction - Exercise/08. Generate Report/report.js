function generateReport() {
    
    let result = [];

    let names = [];
    let indexes = [];
    let checkboxes = document.getElementsByTagName(`input`);
    
    for (let index = 0; index < checkboxes.length; index++) {
        
        if (checkboxes[index].checked){
            
            names.push(checkboxes[index].name);
            indexes.push(index);
        }
    };
    
    let rows = document.getElementsByTagName(`tr`);

    for (let i = 1; i < rows.length; i++) {
        
        let obj = {};

        for (let index = 0; index < indexes.length; index++){

            obj[names[index]] = rows[i].getElementsByTagName(`td`)[indexes[index]].textContent;
        }

        result.push(obj);
    }

    document.getElementById(`output`).textContent = JSON.stringify(result);

}