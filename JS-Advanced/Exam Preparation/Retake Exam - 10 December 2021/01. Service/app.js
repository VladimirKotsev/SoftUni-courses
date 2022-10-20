window.addEventListener('load', solve);

function solve() {

    
    let submitButton = document.getElementsByTagName(`button`)[0];
    submitButton.addEventListener(`click`, (e) => {
        
        e.preventDefault();
        
        let typeofProduct = document.getElementById(`type-product`);
        let description = document.getElementById(`description`);
        let clientName = document.getElementById(`client-name`);
        let clientPhone = document.getElementById(`client-phone`);

        if (!description.value || !clientName.value || !clientPhone.value){

            return;
        }
   
        let receivedSelection = document.getElementById(`received-orders`);
        let completedSelection = document.getElementById(`completed-orders`);

        let div = document.createElement(`div`);
        div.classList.add(`container`);

        let h2 = document.createElement(`h2`);
        h2.textContent += `Product type for repair: ${typeofProduct.options[typeofProduct.selectedIndex].text}`;
        div.appendChild(h2);

        let h3 = document.createElement(`h3`);
        h3.textContent += `Client information: ${clientName.value}, ${clientPhone.value}`;
        div.appendChild(h3);

        let h4 = document.createElement(`h4`);
        h4.textContent += `Description of the problem: ${description.value}`;
        div.appendChild(h4);

        description.value = ``;
        clientName.value = ``;
        clientPhone.value = ``;

        let bntStart = document.createElement(`button`);
        bntStart.className = `start-btn`;
        bntStart.textContent = `Start repair`;

        bntStart.addEventListener(`click`, () => {

            btnFinish.disabled = false;
            bntStart.disabled = true;
        });


        let btnFinish = document.createElement(`button`);
        btnFinish.className = `finish-btn`;
        btnFinish.textContent = `Finish repair`;
        btnFinish.disabled = true;

        btnFinish.addEventListener(`click`, () => {

            receivedSelection.removeChild(div);

            div.removeChild(bntStart);
            div.removeChild(btnFinish);

            completedSelection.appendChild(div);
        });

        let btnClear = document.getElementsByClassName(`clear-btn`)[0];
        btnClear.addEventListener(`click`, () => {

            let toDelete = document.querySelectorAll(`#completed-orders>.container`);

            for (const iterator of toDelete) {
                
                completedSelection.removeChild(iterator);
            };

        });


        div.appendChild(bntStart);
        div.appendChild(btnFinish);

        receivedSelection.appendChild(div);

    });
    
}