function colorize() {
    
    let data = document.getElementsByTagName(`tr`);

    for(let i = 1; i < data.length; i++){

        if (i % 2 !== 0){

            data[i].style.backgroundColor = `teal`;
        }
    }
}