function uppercase(input){

    let words = input.match(/\w+/g).join(", ").toUpperCase();
    console.log(words);

}