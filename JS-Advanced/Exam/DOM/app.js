window.addEventListener("load", solve);

function solve() {
  
  let publishBtn = document.getElementById(`form-btn`);
  publishBtn.addEventListener(`click`, (e) => {

    e.preventDefault();

    let firstName = document.getElementById(`first-name`);
    let lastName = document.getElementById(`last-name`);
    let age = document.getElementById(`age`);
    let storyTitle = document.getElementById(`story-title`);
    let genre = document.getElementById(`genre`);
    let story = document.getElementById(`story`);

    if (!firstName.value || !lastName.value || !age.value || !storyTitle.value || !genre.value || !story.value){

      return;
    }

    let ul = document.getElementById(`preview-list`);

    let li = document.createElement(`li`);
    li.className = `story-info`

    let article = document.createElement(`article`);
    
    let h4 = document.createElement(`h4`);
    h4.textContent = `Name: ${firstName.value} ${lastName.value}`;
    article.appendChild(h4);

    let p1 = document.createElement(`p`);
    p1.textContent = `Age: ${age.value}`;
    article.appendChild(p1);

    let p2 = document.createElement(`p`);
    p2.textContent = `Title: ${storyTitle.value}`;
    article.appendChild(p2);

    let p3 = document.createElement(`p`);
    p3.textContent = `Genre: ${genre.value}`;
    article.appendChild(p3);

    let p4 = document.createElement(`p`);
    p4.textContent = story.value;
    article.appendChild(p4);

    li.appendChild(article);

    firstName.value = ``;
    lastName.value = ``;
    age.value = ``;
    //genre.value = ``;
    storyTitle.value = ``;
    story.value = ``;

    let btnSave = document.createElement(`button`);
    btnSave.className = `save-btn`;
    btnSave.textContent = `Save Story`;
    btnSave.disabled = true;

    btnSave.addEventListener(`click`, (e) => {

      e.preventDefault();

      let div = document.getElementById(`main`);

      let length = div.children.length;
      for(let i = 0; i < length; i++){

        div.removeChild(div.children[0]);
      }

      let h1 = document.createElement(`h1`);
      h1.textContent = `Your scary story is saved!`;

      div.appendChild(h1);
    });

    let btnEdit = document.createElement(`button`);
    btnEdit.className = `edit-btn`;
    btnEdit.textContent = `Edit Story`;
    btnEdit.disabled = true;

    btnEdit.addEventListener(`click`, (e) => {

      e.preventDefault();

      firstName.value = h4.textContent.split(` `)[1];
      lastName.value = h4.textContent.split(` `)[2];
      age.value = p1.textContent.split(` `)[1];
      genre.value = p3.textContent.slice(7);
      storyTitle.value = p2.textContent.slice(7);
      story.value = p4.textContent;

      publishBtn.disabled = false;

      ul.removeChild(li);
    });

    let btnDelete = document.createElement(`button`);
    btnDelete.className = `delete-btn`;
    btnDelete.textContent = `Delete Story`;
    btnDelete.disabled = true;

    btnDelete.addEventListener(`click`, (e) => {

      e.preventDefault();

      ul.removeChild(li);
      publishBtn.disabled = false;
    });
    
    li.appendChild(btnSave);
    li.appendChild(btnEdit);
    li.appendChild(btnDelete);

    ul.appendChild(li);

    publishBtn.disabled = true;

    btnSave.disabled = false;
    btnEdit.disabled = false;
    btnDelete.disabled = false;

  });
}
