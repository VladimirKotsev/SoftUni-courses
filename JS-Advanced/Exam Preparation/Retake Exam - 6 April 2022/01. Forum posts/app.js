window.addEventListener("load", solve);

function solve() {
  
  let newUl = document.getElementById(`published-list`);

  let publishBtn = document.getElementById(`publish-btn`);

  publishBtn.addEventListener(`click`, (e) =>{

    let title = document.getElementById(`post-title`); //input => value
    let category = document.getElementById(`post-category`); //input => value
    let content = document.getElementById(`post-content`); 

    if (!title.value || !category.value || !content.value){

      return;
    }

    let ul = document.getElementById(`review-list`);

    let li = document.createElement(`li`);
    li.classList.add(`rpost`);

    let article = document.createElement(`article`);

    let h4 = document.createElement(`h4`);
    h4.textContent = title.value;

    let p1 = document.createElement(`p`);
    p1.textContent = `Category: ` + category.value;

    let p2 = document.createElement(`p`);
    p2.textContent = `Content: ` + content.value;

    article.appendChild(h4);
    article.appendChild(p1);
    article.appendChild(p2);

    title.value = ``;
    category.value = ``;
    content.value = ``;

    li.appendChild(article);

    let btn1 = document.createElement(`button`);
    btn1.textContent = `Edit`;
    //btn1.classList.add(`action-btn`);
    btn1.className = `action-btn edit`;

    btn1.addEventListener(`click`, (e) => {

      title.value = h4.textContent;
      category.value = p1.textContent.replace(`Category: `, ``);
      content.value = p2.textContent.replace(`Content: `, ``);

      ul.removeChild(li);
    });

    
    let btn2 = document.createElement(`button`);
    btn2.textContent = `Approve`;
    //btn2.classList.add(`action-btn`);
    btn2.className = `action-btn approve`;
    
    btn2.addEventListener(`click`, (e) => {
      
      li.removeChild(btn1);
      li.removeChild(btn2);
      
      newUl.appendChild(li);
      
      ul.removeChild(li);
      
    });
    
    let btnClear = document.getElementById(`clear-btn`);
    btnClear.addEventListener(`click`, (e) => {
      
      for(let i = 0; i < newUl.children.length; i++){
        
        newUl.removeChild(newUl.children[0]);
      }
    });
    
    li.appendChild(btn2);
    li.appendChild(btn1);

    ul.appendChild(li);
  });

}