function validate() {

    let valid = true;

    let checkBox = document.getElementById(`company`);
    checkBox.addEventListener(`change`, (e) => {
    
        let field = document.getElementById(`companyInfo`);
        if (checkBox.checked){

            field.style.display = `block`;
        }
        else{

            field.style.display = `none`;
        }
    });
    
    let submit = document.getElementById(`submit`);
    submit.addEventListener(`click`, () =>{
        
        let usernamePattern = /^[A-Za-z0-9]{3,20}$/g;
        let username = document.getElementById(`username`).value;
        
        let passwordPattern = /^\w{5,15}$/g;
        let password = document.getElementById(`password`).value;
        let passwordConfirm = document.getElementById(`confirm-password`).value;
    
    
        let emailPattern = /[a-zA-Z0-9_.]+\@\w+\.+\w+$|[a-zA-Z0-9_.]?\@\w+\.+\w+$/g;
        let email = document.getElementById(`email`).value;


        if (!username.match(usernamePattern)){
    
            document.getElementById(`username`).style.borderColor = `red`;

            valid = false;
        }
        else{
    
            document.getElementById(`username`).style.borderColor = `none`;
        }
        if (!password.match(passwordPattern) || password !== passwordConfirm){
    
            document.getElementById(`password`).style.borderColor = `red`;
            document.getElementById(`confirm-password`).style.borderColor = `red`;

            valid = false;
        }
        else{
    
            document.getElementById(`password`).style.borderColor = `none`;
            document.getElementById(`confirm-password`).style.borderColor = `none`;
        }
        if (!email.match(emailPattern)){
    
            document.getElementById(`email`).style.borderColor = `red`;

            valid = false;
        }
        else{
    
            document.getElementById(`email`).style.borderColor = `none`;
        }
        
        let field = document.getElementById(`companyInfo`);

        if (checkBox.checked){

            let number = field.getElementsByTagName(`input`)[0].value;

            if (Number(number) < 1000 || Number(number) > 9999 || number === undefined){

                field.getElementsByTagName(`input`)[0].style.borderColor = `red`;

                valid = false;
            }
        }

        if (valid){
            
            let div = document.getElementById(`valid`)
            div.style = `display: center;`;
        }
        else{
    
            let div = document.getElementById(`valid`)
            div.style = `display: none;`;
        }
    });


    
}
