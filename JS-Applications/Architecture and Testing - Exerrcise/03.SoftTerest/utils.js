const host = `http://localhost:3030/`;

export function hideSections(){
    let sections = document.getElementsByName(`section`);
    sections.forEach(sections => sections.style.display = `none`);
}

export function hideHeaders(){
    let [...li] = document.getElementsByTagName(`li`);
    li.forEach(li => li.style.display = `none`);
}

export async function postRequest(url, body){
 
    const response = await fetch(host + url, {

        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(body)
    });

    if (response.ok === false){
        const error = await response.json();
        throw new Error(error.message);
    }
    else{
        
        const data = await response.json();
    
        return data;
    }
}

export async function getRequest(url){

    const response = await fetch(host + url);
    const data = await response.json();

    return data;
}

export async function logoutRequest(url){

    const token = localStorage.getItem(`accessToken`);

    const response = await fetch(host + url, {
    
        method: `get`,
        headers: {
            'X-Authorization': token
        }
    });
}