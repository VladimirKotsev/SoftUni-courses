function station(arr, criteria){

    class Ticket{

        constructor(destination, price, status){

            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let result = [];

    for (let i = 0; i < arr.length; i++) {
        
        let [destination, price, status] = arr[i].split(`|`);

        result.push(new Ticket(destination, Number(price), status));
    }

    switch (criteria){

        case `destination`: result.sort((a, b) => a.destination.localeCompare(b.destination)); break;
        case `price` : result.filter(x => x.price).sort((a, b) => a - b); break;
        case `status`: result.sort((a, b) => a.status.localeCompare(b.status)); break;
    }

    return result;
}