function toJSON(input){

    let result = [];
    

    for (let i of input){

        let obj = {};

        let [name, level, items] = i.split(` / `);
        level = Number(level);
        items = items ? items.split(`, `) : [];

        obj = {
            name: name,
            level: level,
            items: items
        };
        result.push(obj);
    }

    console.log(JSON.stringify(result));
}