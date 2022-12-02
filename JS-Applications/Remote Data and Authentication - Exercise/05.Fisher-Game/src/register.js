const url = `http://localhost:3030/users/register`;

let email = document.querySelector(`input[name="email"]`);
let password = document.querySelector(`input[name="password"]`);
let rePassword = document.querySelector(`input[name="rePass"]`);

let notification = document.querySelector(`p[class="notification"]`);
let btnRegister = document.querySelector(`button`);
btnRegister.addEventListener(`click`, onRegister);

async function onRegister(){

    if (password === rePassword){

        let body = {
    
            email: email.value,
            password: password.value
        };
    
        try {
            
            const data = await postRequest(body);  

            if (!data.ok){

                throw new Error(data.message);
            }
            
        } catch (error) {
            
            notification.textContent = error.message;
        }
    }
}

async function postRequest(body){

    try {
        
        const response = await fetch(url, {
    
            method: 'post',
            headers: { 'Content-Type': 'application/json'},
            body: JSON.stringify(body)
        });

        if (!response.ok){
            
            const data = await response.json();

            throw new Error(data.message);
        }

        const data = await response.json();

        return data;

    } catch (error) {
        
        throw Error(error.message);
    }
}
