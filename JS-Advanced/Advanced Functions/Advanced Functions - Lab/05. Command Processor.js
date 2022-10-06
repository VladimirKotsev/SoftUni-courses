function solution(){

    let concat = ``;

    return {
        append: text => concat += text,
        removeStart: n => concat = concat.substring(n),
        removeEnd: n => concat = concat.substring(0, concat.length - n),
        print: function() { console.log(concat) }
    };
}

