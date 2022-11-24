const host = `http://localhost:3030/jsonstore/collections/myboard/`;

export async function postRequest(url, body){

    const response = await fetch(host + url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(body)
    });
    
    const data = await response.json();
    //console.log(data);
    return data;
}

export function hideSections(){

    let main = document.getElementsByTagName(`main`)[0];
    
    let [...children] = main.children;

    children.forEach(element => {
        element.style.display = `none`;
    });
}

export async function getRequest(url){

    const response = await fetch(host + url);

    const data = await response.json();
    return data;
}