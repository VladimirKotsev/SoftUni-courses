function create(words) {
   
   let content = document.getElementById(`content`);

   for (let word of words) {
      
      let div = document.createElement(`div`);
      div.className = `div`;

      let p = document.createElement(`p`);
      p.className = `div p`;
      p.textContent = word;
      p.style.display = `none`;

      div.appendChild(p);
      div.addEventListener(`click`, function(){

         p.style.display = `inline`;
      });

      content.appendChild(div);
   }
}