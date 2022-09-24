function createSortedList(){

    let size = 0;
    let obj = {

        list: [],
        add: function(number){
            let arr = this.list;
            arr.push(Number(number));
            arr.sort((a, b) => a - b);
            this.list = arr;
            this.size = arr.length;
        },
        remove: function(index){
            let arr = this.list;
            if (index >= 0 && index < arr.length){
                arr.splice(index, 1);
            }
            arr.sort((a, b) => a - b);
            this.list = arr;
            this.size = arr.length;
        },
        get: function(index){
            let arr = this.list;
            return arr[index];
        },
        size: size,   
        
    }

    return obj;
}
