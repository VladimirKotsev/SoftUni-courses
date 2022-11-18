function solve() {

    let btnDepart = document.getElementById(`depart`);
    let btnArrive = document.getElementById(`arrive`);

    let span = document.getElementsByClassName(`info`)[0];

    let firstStop = true;

    let currentStop;
    let previousStop;

    async function depart() {
        
        btnDepart.disabled = true;
        btnArrive.disabled = false;
        
        if (firstStop){

            url = `http://localhost:3030/jsonstore/bus/schedule/depot`;

            let promise = await fetch(url);
            currentStop = await promise.json();

            firstStop = false;
        }
        else{

            previousStop = currentStop;
            url = `http://localhost:3030/jsonstore/bus/schedule/${previousStop.next}`;

            let promise = await fetch(url);
            currentStop = await promise.json();
        }

        span.textContent = `Next stop ${currentStop.name}`;
    }

    function arrive() {
        
        btnArrive.disabled = true;
        btnDepart.disabled = false;

        span.textContent = `Arriving at ${currentStop.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();