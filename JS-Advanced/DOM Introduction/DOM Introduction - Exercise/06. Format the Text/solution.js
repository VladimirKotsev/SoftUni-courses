function solve() {

  let input = document.getElementById(`input`).value.split(`.`);
  input.pop();

  let output = document.getElementById(`output`);
  
  let text = ``;
  let counter = Number(0);
  let paragraph;

  for (let sentence of input){
    
    text += sentence.trim() + `.`;
    counter++;
    
    if (counter === 3){
      
      paragraph = document.createElement(`p`);

      paragraph.textContent = text;

      output.appendChild(paragraph);

      text = ``;
      counter = Number(0);
    }
    
  }

  if (counter > 0){

    paragraph = document.createElement(`p`);
    output.appendChild(paragraph);
    paragraph.textContent = text;
  }
}