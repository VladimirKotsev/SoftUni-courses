function notify(message) {

  let div = document.getElementById(`notification`);
  div.addEventListener(`click`, function(){

    div.style.display = `none`;
  });

  div.textContent = message;

  div.style.display = `block`;
}