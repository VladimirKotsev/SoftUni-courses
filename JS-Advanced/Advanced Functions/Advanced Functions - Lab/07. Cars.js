function cars(arr){

    let result = [];

    for (let i = 0; i < arr.length; i++) {
        
        let [cmd, name] = arr[i].split(` `);

        if (arr[i].split(` `).length === 2){

            switch(cmd){

                case `create`:
                    let obj = {
                        name: name
                    };

                    result.push(obj);
                    break;
                case `print`:

                    let resString = [];
                    for (let key in result.find(x => x.name == name)) {
                        
                        if (key !== `inherit` && key !== `name`){

                            resString.push(`${key}:${result.find(x => x.name == name)[key]}`);
                        }
                    }

                    if (result.find(x => x.name == name).inherit){

                        inherit(name);
                        //resString.reverse();
                    }

                    console.log(resString.join(`,`));

                    function inherit(parentName){

                        if (result.find(x => x.name == parentName).inherit){

                            let nameOfInherit = result.find(x => x.name == parentName).inherit;
                            
                            for (let key in result.find(x => x.name == nameOfInherit)) {
                                
                                if (key !== `inherit` && key !== `name`){
                                    
                                    resString.push(`${key}:${result.find(x => x.name == nameOfInherit)[key]}`);
                                }
                            }
                            if (result.find(x => x.name == nameOfInherit).inherit){

                                inherit(nameOfInherit);
                            }
                        }
                    }
                    break;
            }
        }
        else if (arr[i].split(` `).length === 4){

            let propertyOrIneherit = arr[i].split(` `)[2];
            let nameOrValue = arr[i].split(` `)[3];

            switch (cmd){

                case `create`:

                    let obj = Object.assign({}, result.find(x => x.name == nameOrValue));
                    obj.name = name;
                    obj.inherit = nameOrValue;
                    result.push(obj);
                break;

                case `set`:

                    result.find(x => x.name == name)[propertyOrIneherit] = nameOrValue;
                    
                break;
            }

        }

    }

}

//cars([`create pesho`, `create gosho inherit pesho`, `create stamat inherit gosho`, `set pesho rank number1`, `set gosho nich goshko`, `print stamat`]);
//cars(['create c1','create c2 inherit c1','set c1 color red','set c2 model new','print c1','print c2']);