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

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);
