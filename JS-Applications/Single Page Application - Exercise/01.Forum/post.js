import { getRequest, hideSections, postRequest } from './utils.js';

const mainTemplate = document.getElementById(`post-page`);
const submitCommentSection = document.getElementById(`comment-section`);
let postId = ``;

export function showPostPageOnClick(event){
    
    event.preventDefault();
    
    
    showPostPage(event.target.parentElement);
}

async function showPostPage(target){

    hideSections();
    
    postId = target.name;
    const dataPosts = await getRequest(`posts/${postId}`);
    const dataComments = await getRequest(`comments`);

    document.getElementById(`header`).style.display = `block`;
    
    loadPost(dataPosts);

    if (dataComments){
        
        let comments = [];
        
        for (const key in dataComments) {
            
            let obj = dataComments[key];
            if (obj.postID === target.name){
                comments.push(obj);
            }
        }
        
        loadComments(comments, true);
        mainTemplate.style.display = `block`;
        let section = mainTemplate.cloneNode(true);

        submitCommentSection.style.display = `block`;
        let postBtn = submitCommentSection.getElementsByTagName(`button`)[0];
        postBtn.addEventListener(`click`, onSubmittingComment);
    }
    else{

        document.querySelector(`#user-comment`).style.display = `none`;
        document.querySelector(`div[class="header"]`).style.display = `block`;
    }
} 

function removeOldComments(){

    let comments = mainTemplate.querySelectorAll(`div[name="user comments"]`);
    comments.forEach(element => {
        
        mainTemplate.removeChild(element);
    });
}

async function onSubmittingComment(event){

    event.preventDefault();

    let textarea = submitCommentSection.querySelector(`textarea`)
    let username = submitCommentSection.querySelector(`input`);

    let today = new Date();
    let date = today.getFullYear()+ '-' +(today.getMonth()+1)+ '-' +today.getDate();
    let time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    time = date + ' ' + time;
    
    let body = {
        postID: postId,
        username: username.value,
        time: time,
        text: textarea.value
    };
    
    const data = await postRequest(`comments`, body);
    loadComments(data, false);
}

function loadPost(data){

    let span = mainTemplate.getElementsByTagName(`span`)[0];
    span.textContent = data.username;

    let timeNode = mainTemplate.getElementsByTagName(`time`)[0];
    timeNode.textContent = data.time;

    let p = mainTemplate.getElementsByTagName(`p`)[1];
    p.textContent = data.postText;
}

function loadComments(data, IsOnLoad){

    let template = document.getElementById(`user-comment`); 

    if (IsOnLoad){

        data.forEach(element => {
            
            visualizeComment(element, template);
        });
    }
    else{

        visualizeComment(data, template);
    }
}

function visualizeComment(data, template){

    let strong = template.querySelector(`strong`);
    strong.textContent = data.username;
    
    let time = template.getElementsByTagName(`time`)[0];
    time.textContent = data.time;
    
    let p = template.getElementsByTagName(`p`)[1];
    p.textContent = data.text;
    
    template.style.display = `block`;
    let div = template.cloneNode(true);
    div.id = ``;
    template.style.display = `none`;

    mainTemplate.appendChild(div);
}