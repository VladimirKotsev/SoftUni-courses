function sort(arr){

    arr.sort((a, b) => a.length - b.length || a.localeCompare(b));
       

    arr.forEach(element => {
        console.log(element);
    });
}

sort(['test', 
'Deny', 
'omen', 
'Default']
);
