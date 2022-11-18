function attachEvents() {
    
    let textArea = document.getElementById(`messages`);
    const url = `http://localhost:3030/jsonstore/messenger`;

    let submitBtn = document.getElementById(`submit`);
    let refreshBtn = document.getElementById(`refresh`);

    let messageAuthor = document.querySelector(`[name=author]`);
    let content = document.querySelector(`[name=content]`);

    submitBtn.addEventListener(`click`, onSubmition);
    refreshBtn.addEventListener(`click`, onRefresh);


    async function onSubmition(event){

        event.preventDefault();

        const response = await fetch(url, {
            method: "post",
            headers: {
                "Content-Type": "aplication/json"
            },
            body: JSON.stringify({ author: messageAuthor.value, content: content.value })
        });

        const data = await response.json();
    }

    async function onRefresh(event){

        event.preventDefault();

        const response = await fetch(url);
        const data = await response.json();
    
        let content = ``;
        for (const key in data) {
            
            content += `${data[key].author}: ${data[key].content}\n`;
        }

        content = content.slice(0, content.length - 1);

        textArea.textContent = content;
    }
}

attachEvents();