function encodeAndDecodeMessages() {
    
    let sender = document.getElementById(`main`).getElementsByTagName(`div`)[0];
    let receiver = document.getElementById(`main`).getElementsByTagName(`div`)[1];

    sender.getElementsByTagName(`button`)[0].addEventListener(`click`, function(){

        let text = sender.getElementsByTagName(`textarea`)[0].value;

        let encoded = ``;

        for (let index = 0; index < text.length; index++){

            encoded += String.fromCharCode(text.charCodeAt(index) + 1);
        }

        sender.getElementsByTagName(`textarea`)[0].value = ``;

        receiver.getElementsByTagName(`textarea`)[0].value = encoded;
    });

    receiver.getElementsByTagName(`button`)[0].addEventListener(`click`, function(){

        let text = receiver.getElementsByTagName(`textarea`)[0].value;

        let decoded = ``;

        for (let index = 0; index < text.length; index++){

            decoded += String.fromCharCode(text.charCodeAt(index) - 1);
        }

        receiver.getElementsByTagName(`textarea`)[0].value = decoded;
    });
}