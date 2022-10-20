function solve() {
    
    let open = document.getElementsByTagName('section')[1];
    let inProgress = document.getElementsByTagName('section')[2];
    let complete = document.getElementsByTagName('section')[3];

    let taksField = document.getElementById(`task`);
    let descriptionField = document.getElementById(`description`);
    let dataField = document.getElementById(`date`);
    
    let sections = document.getElementsByTagName(`section`);
    

    let addBtn = document.getElementById(`add`);
    addBtn.addEventListener(`click`, c =>{

        c.preventDefault();
        
        if (taksField.value === `` || descriptionField.value === `` || dataField.value === ``){

            return;
        }

        let article = document.createElement(`article`);

        let header = document.createElement(`h3`);
        header.textContent = taksField.value;
        article.appendChild(header);

        let p1 = document.createElement(`p`);
        p1.textContent = `Description: ${descriptionField.value}`;
        article.appendChild(p1);
        
        let p2 = document.createElement(`p`);
        p2.textContent = `Due Date: ${dataField.value}`;
        article.appendChild(p2);
        
        let div = document.createElement(`div`);
        div.classList.add(`flex`);
        let btnStart = document.createElement(`button`);
        btnStart.classList.add(`green`);
        btnStart.textContent = `Start`;
        div.appendChild(btnStart);
        let btnDelete = document.createElement(`button`);
        btnDelete.classList.add(`red`);
        btnDelete.textContent = `Delete`;
        div.appendChild(btnDelete);
        
        article.appendChild(div);

        open.children[1].appendChild(article);  //open

        btnStart.addEventListener(`click`, c => {

            c.preventDefault();

            inProgress.children[1].appendChild(article);

            div.removeChild(btnStart);
            let btnFinish = document.createElement(`button`);
            btnFinish.textContent = `Finish`;
            btnFinish.classList.add(`orange`);
            div.appendChild(btnFinish);
            
            btnFinish.addEventListener(`click`, c => {

                c.preventDefault();

                div.removeChild(btnFinish);
                div.removeChild(btnDelete);
                
                complete.children[1].appendChild(article);
            });

        });


        btnDelete.addEventListener(`click`, c => {

            c.preventDefault();
            
            article.remove();
        });
        
                
    });
}