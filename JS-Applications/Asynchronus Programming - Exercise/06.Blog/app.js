function attachEvents() {

    let urlPosts = `http://localhost:3030/jsonstore/blog/posts`;
    let urlComments = `http://localhost:3030/jsonstore/blog/comments`;

    let select = document.getElementById(`posts`);

    let ul = document.getElementById(`post-comments`);

    let postTitle = document.getElementById(`post-title`);

    let postBody = document.getElementById(`post-body`);

    let loadBtn = document.getElementById(`btnLoadPosts`);
    loadBtn.addEventListener(`click`, async (e) => {

        e.preventDefault();

        const response = await fetch(urlPosts);
        const data = await response.json();
        enterOpinions(data);
    });

    let viewBtn = document.getElementById(`btnViewPost`);
    viewBtn.addEventListener(`click`, async (e) => {
        
        e.preventDefault();

        let id = select.options[select.selectedIndex].value;
    
        const response = await fetch(urlComments);
        const data = await response.json();

        for (const key in data) {

            let current = data[key];
            if (current.postId === id){

                enterComments(current.text);
                getRecord();

                async function getRecord(){

                    const response = await fetch(urlPosts + `/` + id);
                    const data = await response.json();

                    visualizeTitleAndBody(data.title, data.body);
                }

            }
        }
    });
    
    function enterOpinions(data){
    
        for (const key in data) {
            
            let obj = data[key];
    
            let opinion = document.createElement(`option`);
    
            opinion.textContent = obj.title;
            opinion.value = obj.id;
    
            select.appendChild(opinion);
        }
    }

    function visualizeTitleAndBody(title, body){

        postTitle.textContent = title;
        postBody.textContent = body;
    }
    
    function enterComments(text){

        let li = document.createElement(`li`);
        li.textContent = text;  
        ul.appendChild(li);
    }

}


attachEvents();