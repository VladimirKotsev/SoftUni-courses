async function solution() {
    
    let url = `http://localhost:3030/jsonstore/advanced/articles/list`;
    let urlContent = `http://localhost:3030/jsonstore/advanced/articles/details/`;

    let main = document.getElementById(`main`);

    const response = await fetch(url);
    const data = await response.json();

    data.forEach(element => {
        
        let parrentDiv = document.createElement(`div`);
        parrentDiv.className = `accordion`;

        let mainDiv = document.createElement(`div`);
        mainDiv.className = `head`;

        let span = document.createElement(`span`);
        span.textContent = element.title;
        mainDiv.appendChild(span);

        let btn = document.createElement(`button`);
        btn.className = `button`;
        btn.id = element._id;
        btn.textContent = `More`;

        btn.addEventListener(`click`, shomeMore);

        mainDiv.appendChild(btn);

        parrentDiv.appendChild(mainDiv);

        let hiddenDiv = document.createElement(`div`);
        hiddenDiv.className = `extra`;
        hiddenDiv.style.display = `none`;

        showMoreTextContent();

        parrentDiv.appendChild(hiddenDiv);

        main.appendChild(parrentDiv);

        async function showMoreTextContent(){
    
            const response = await fetch(urlContent + btn.id);
            const data = await response.json();
    
            let p = document.createElement(`p`);
    
            p.textContent = data.content;
            hiddenDiv.appendChild(p);
        }

        function shomeMore(event){
    
            event.preventDefault();

            if (btn.textContent === `More`){
    
                hiddenDiv.style.display = `inline`;
                btn.textContent = `Less`
            }
            else if (btn.textContent === `Less`){

                hiddenDiv.style.display = `none`;
                btn.textContent = `More`;
            }
        }
    });



}

solution();