function toggle() {

    let button = document.getElementsByClassName(`button`)[0];
    let buttonTxt = button.textContent;

    let div = document.getElementById(`extra`);

    if (buttonTxt === `Less`){

        div.style.display = `none`;

        button.textContent = `More`;
    }
    else if (buttonTxt === `More`){

        div.style.display = `block`;

        button.textContent = `Less`;
    }

    
}