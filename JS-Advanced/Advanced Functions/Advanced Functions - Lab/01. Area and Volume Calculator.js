
function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {
    
    let result = [];

    input = JSON.parse(input);
    
    for(let i = 0; i < input.length; i++){
        
        let obj = {

            area: area.call(input[i]),
            volume: vol.call(input[i])
        };

        result.push(obj);
        
    }
    
    return result;

}

