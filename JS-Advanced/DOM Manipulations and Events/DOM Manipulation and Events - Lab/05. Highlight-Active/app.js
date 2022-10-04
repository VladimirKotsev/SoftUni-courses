function focused() {
    
    let input = document.getElementsByTagName(`input`);

    for (let section of input) {
        
        section.addEventListener(`focus`, function(){

            section.parentElement.classList.add(`focused`);
        });

        section.addEventListener(`blur`, function(){

            section.parentElement.classList.remove(`focused`);
        });
    }

}