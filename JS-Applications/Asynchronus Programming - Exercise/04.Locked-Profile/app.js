async function lockedProfile() {
    
    let url = `http://localhost:3030/jsonstore/advanced/profiles`;

    let main = document.getElementById(`main`);
    let profileSelector = document.getElementsByClassName(`profile`)[0];
    let aplication = profileSelector.cloneNode(true);

    let promise = await fetch(url);
    let result = await promise.json();

    let first = true;;
    for (let key in result) {
        
        if (first){

            let profile = result[key];

            //let radioBtnLock = profileSelector.getElementsByTagName(`input`)[0];
            let radioBtnUnlock = profileSelector.getElementsByTagName(`input`)[1];

            profileSelector.getElementsByTagName(`div`)[0].style.display = `none`;

            profileSelector.getElementsByTagName(`input`)[2].value = profile.username;
            profileSelector.getElementsByTagName(`div`)[0].getElementsByTagName(`input`)[0].value = profile.email;
            profileSelector.getElementsByTagName(`div`)[0].getElementsByTagName(`input`)[1].value = profile.age;

            let btn = profileSelector.getElementsByTagName(`button`)[0];
            
            btn.addEventListener(`click`, function(){
                
                if (radioBtnUnlock.checked && btn.textContent === `Show more`){
                    
                    //radioBtnLock.checked = false;
                    profileSelector.getElementsByTagName(`div`)[0].style.display = `inline`;
                    btn.textContent = `Hide it`;
                }     
                else if (radioBtnUnlock.checked && btn.textContent === `Hide it`){
                    
                    //radioBtnLock.checked = false;
                    profileSelector.getElementsByTagName(`div`)[0].style.display = `none`;
                    btn.textContent = `Show more`;
                }
            });

            first = false;

            continue;
        }

        let profile = result[key];

        let div = aplication.cloneNode(true);

        let radioBtnLock = div.getElementsByTagName(`input`)[0];
        let radioBtnUnlock = div.getElementsByTagName(`input`)[1];

        div.getElementsByTagName(`div`)[0].style.display = `none`;

        div.getElementsByTagName(`input`)[2].value = profile.username;
        div.getElementsByTagName(`div`)[0].getElementsByTagName(`input`)[0].value = profile.email;
        div.getElementsByTagName(`div`)[0].getElementsByTagName(`input`)[1].value = profile.age;

        let btn = div.getElementsByTagName(`button`)[0];
        
        btn.addEventListener(`click`, function(){
            
            if (radioBtnUnlock.checked && btn.textContent === `Show more`){
                
                //radioBtnLock.checked = false;
                div.getElementsByTagName(`div`)[0].style.display = `inline`;
                btn.textContent = `Hide it`;
            }     
            else if (radioBtnUnlock.checked && btn.textContent === `Hide it`){
                
                //radioBtnLock.checked = false;
                div.getElementsByTagName(`div`)[0].style.display = `none`;
                btn.textContent = `Show more`;
            }
        });

        main.appendChild(div);
    }
}