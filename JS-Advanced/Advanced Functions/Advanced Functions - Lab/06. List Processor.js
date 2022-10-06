function process(arr){

    let text = [];

    let obj = {

        add: value => text.push(value),
        remove: value => text = text.filter(x => x !== value),
        print: function() { console.log(text.join(`,`)) }
    }
    for (let index = 0; index < arr.length; index++) {
        
        if (arr[index] !== `print`){

            let cmd = arr[index].split(` `)[0];
            let value = arr[index].split(` `)[1];

            
            switch(cmd){
                case `add`: obj.add(value); break;
                case `remove`: obj.remove(value); break;
            }
        }
        else
        {
            obj.print();
        }
    }
}