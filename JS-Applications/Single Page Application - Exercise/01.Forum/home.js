import { getRequest, hideSections, postRequest } from './utils.js';
import { showPostPageOnClick } from './post.js';

let topicTitle = document.getElementById(`topicName`);
let username = document.getElementById(`username`);
let postText = document.getElementById(`postText`);

let divTemplate = document.querySelector(`div[class="topic-name-wrapper"]`).cloneNode(true);

const divContainer = document.querySelector(`div[class="topic-container"]`);

export async function showHomePageOnClick(event){

    event.preventDefault();

    hideSections();
    document.querySelector(`div[class="new-topic-border"]`).style.display = `block`;
    document.querySelector(`div[class="topic-title"]`).style.display = `block`;

}

export function cancelFields(event){

    event.preventDefault();
    
    topicTitle.value = ` `;
    username.value = ` `;
    postText.value = ` `;

}

export async function onLoad(){

    const data = await getRequest(`posts`);

    for (const key in data) {
        
        let obj = data[key];
        
        let h2 = obj.title;
        let time = obj.time;
        let span = obj.username;
        let link = obj._id;

        dataFill(h2, span, time, link);
    }
}

function dataFill(h2Text, spanText, time, linkName){

    let div = divTemplate.cloneNode(true);

    let h2 = div.getElementsByTagName(`h2`)[0];
    h2.textContent = h2Text;

    let span = div.getElementsByTagName(`span`)[0];
    span.textContent = spanText;

    let link = div.getElementsByTagName(`a`)[0];
    link.addEventListener(`click`, showPostPageOnClick);
    link.name = linkName;
    
    let timeTag = div.getElementsByTagName(`time`)[0];
    timeTag.textContent = time;

    div.style.display = `block`;
    divContainer.appendChild(div);
}

export async function onPost(event){

    event.preventDefault();
    
    let h2 = topicTitle.value;
    let span = username.value;

    let today = new Date();
    let date = today.getFullYear()+ '-' +(today.getMonth()+1)+ '-' +today.getDate();
    let time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    time = date + ' ' + time;

    let body = {
        
        title: h2,
        username: span,
        postText: postText.value,
        time: time
    };

    const data = await postRequest(`posts`, body);

    let link = data._id;

    dataFill(h2, span, time, link);
}