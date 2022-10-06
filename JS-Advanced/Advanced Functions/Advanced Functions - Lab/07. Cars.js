function cars(arr){

    let result = [];

    let obj = {

        set: function(name, key ,value){

            result.filter(x => x.name === name)[key] = value;
        },
        print: function(name) {

            let currentObj = result.filter(x => x.name === name);
            let result = ``;
            for (let obj of currentObj) {
                
                
            }
        }
    };

    for (let index = 0; index < arr.length; index++) {
        
        let cmd = arr[index].split(` `)[0];
        let name = arr[index].split(` `)[1];

        let key = ``;
        let value = ``;
        if (arr[index].split(` `).length === 4){
            
            keyOrInherits = arr[index].split(` `)[2];
            valueOrParentName = arr[index].split(` `)[3];
        }

        switch (cmd){
            case `set`: set(name, keyOrInherits, valueOrParentName);
            case ``
        }
    }

}

cars(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);