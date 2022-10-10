function getArticleGenerator(articles) {

    let arr = articles;
    let div = document.getElementById(`content`);

    return function(){
        
        if (arr.length === 0){

            return;
        }
        let arti = arr.shift();
        div.innerHTML += `<article>${arti}</article>`;
    } 
}
