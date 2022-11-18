function init(){


}

async function getComments(){

    const response = await fetch(`http://localhost:3030/jsonstore/comments`);
    const data = await response.json();

    return data;
}

async function postComments(comment){

    const response = await fetch(`http://localhost:3030/jsonstore/comments`, {
        method: `post`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comment)
    });

    const data = response.json();

    return data;
}