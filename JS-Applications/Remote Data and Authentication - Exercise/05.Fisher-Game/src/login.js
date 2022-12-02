if (localStorage.length > 0){

    document.querySelector(`span`).textContent = localStorage.username;
}

let url = `http://localhost:3030/users/login`;

let email = document.querySelector(`input[name="email"]`);
let password = document.querySelector(`input[name="password"]`);

let btnLogin = document.getElementsByTagName(`button`)[0];
btnLogin.addEventListener(`click`, onLogin);

let notification = document.querySelector(`p[class="notification"]`);

async function onLogin(event){

    event.preventDefault();

    let body = {
    
        email: email.value,
        password: password.value
    };

    try {
        
        const data = await postRequest(body);  
        localStorage.setItem(`username`, data.username);
        localStorage.setItem(`email`, data.email);

        document.querySelector(`span`).textContent = data.username;

        window.location = `index.html`;

    } catch (error) {
        
        notification.textContent = error.message;
    }
}

async function postRequest(body){

    try {
        const response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json'},
            body: JSON.stringify(body)
        });
    
        //console.log(response);
        if (!response.ok){
    
            const data = await response.json();
            
            throw new Error(data.message);
        }
        
        const data = await response.json();
        return data;

    } catch (error) {
        
        throw new Error(error.message);
    }

}