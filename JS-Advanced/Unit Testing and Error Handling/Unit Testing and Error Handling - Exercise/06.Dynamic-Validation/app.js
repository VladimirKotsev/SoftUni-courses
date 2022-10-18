function validate() {
    
    let email = document.getElementById(`email`);

    email.addEventListener(`change`, onChange);

    function onChange(){

        if (email.value.match(/[a-z]+[@][[a-z]+[.][a-z]+/g)){

            email.classList.remove(`error`);
        }
        else{

            email.classList.add(`error`);
        }
    }
}