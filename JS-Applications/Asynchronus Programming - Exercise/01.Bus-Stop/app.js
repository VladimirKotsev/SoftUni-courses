async function getInfo() {
    let stopId = document.getElementById(`stopId`).value;
    
    let stopName = document.getElementById(`stopName`);
    let buses = document.getElementById(`buses`);
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    
    buses.innerHTML = ``;
    stopName.textContent = ``;

    try {
        
        let result = await fetch(url);
        result = await result.json();
        
        stopName.textContent = result.name;
        
        for (let index = 0; index < Object.keys(result.buses).length; index++) {
            
            let key = Object.keys(result.buses)[index];
            let line = `Bus ${key} arrives in ${result.buses[key]} minutes`;
            let li = document.createElement(`li`);
            li.textContent = line;
            buses.appendChild(li);
        }
    }
    catch (error) {

        stopName.textContent = "Error";
    }
        
}