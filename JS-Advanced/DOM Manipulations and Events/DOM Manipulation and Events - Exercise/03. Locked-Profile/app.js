function lockedProfile() {
    
    let profiles = document.getElementsByClassName(`profile`);

    for (let i = 0; i < profiles.length; i++) {
        
        let radioBtns = profiles[i].getElementsByTagName(`input`);
        
        let btn = profiles[i].getElementsByTagName(`button`)[0];
        
        btn.addEventListener(`click`, function(){
            
            debugger;
            if (radioBtns[1].checked && btn.textContent === `Show more`){
                
                profiles[i].getElementsByTagName(`div`)[0].style.display = `inline`;
                btn.textContent = `Hide it`;
            }     
            else if (radioBtns[1].checked && btn.textContent === `Hide it`){
                
                profiles[i].getElementsByTagName(`div`)[0].style.display = `none`;
                btn.textContent = `Show more`;
            }
        });
    }
}