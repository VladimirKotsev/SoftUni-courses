function solve() {

  let input = document.getElementsByTagName(`textarea`)[0].value;
  let button = document.getElementsByTagName(`button`)[0];

  debugger;
  
  console.log(input);
  input = JSON.stringify(input);

  button.addEventListener(`click`, generate(input));



  
  function generate(input){

    console.log(input);

  }
   
}