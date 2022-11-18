function attachEvents() {
    
    
    try {
        
        let location = document.getElementById(`location`);
        let locationsUrl = `http://localhost:3030/jsonstore/forecaster/locations`;

        let btn = document.getElementById(`submit`);
        btn.addEventListener(`click`, async (e) => {

            e.preventDefault();

            const response = await fetch(locationsUrl);
            let data = await response.json();
        
            let code = ``;
        
            for (let index = 0; index < data.length; index++) {
                
                if (data[index].name === location.value){
        
                    code = data[index].code;
                    break;
                }
            }

            if (code === ``){

                let div = document.getElementById(`forecast`);
                div.style.display = `block`;

                div.textContent = `Error`;
                return;
            }
        
            currentWeather();
            upcomingWeather();


            async function upcomingWeather(){

                let threeDatWeatherUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}/forecast`;

                const response = await fetch(threeDatWeatherUrl);
                const data = await response.json();

                let divUpcoming = document.getElementById(`upcoming`);

                let div1 = document.createElement(`div`);
                div1.className = `forecast-info`;

                for (let index = 0; index < data.length; index++) {
                    
                    let spanDay = document.createElement(`span`);
                    spanDay.classList.add(`upcoming`);
        
                    let childSpan1 = document.createElement(`span`);
                    childSpan1.className = `symbol`;
        
                    switch(data[index].condition) {
        
                        case `Sunny`: childSpan1.textContent = `\u2600`; break;
                        case `Partly sunny`: childSpan1.textContent = `\u26C5`; break;
                        case `Overcast`: childSpan1.textContent = `\u2601`; break;
                        case `Rain`: childSpan1.textContent = `\u2614`; break;
                    }
        
                    let childSpan2 = document.createElement(`span`);
                    childSpan2.textContent = `${data[index].low}\u00B0/${data[index].high}\u00B0`;
                    childSpan2.className = `forecast-data`;
        
        
                    let childSpan3 = document.createElement(`span`);
                    childSpan3.className = `forecast-data`;
                    childSpan3.textContent = data[index].condition;

                    spanDay.appendChild(childSpan1);
                    spanDay.appendChild(childSpan2);
                    spanDay.appendChild(childSpan3);

                    div1.appendChild(spanDay);
                }

                divUpcoming.appendChild(div1);
            }

            async function currentWeather(){

                let currentWeatherUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

                const todaysWeatherResponse = await fetch(currentWeatherUrl);
                const todaysWeatherData = await todaysWeatherResponse.json();

                const todaysWeatherForecastResponse = await fetch(currentWeatherUrl + `/forecast`);
                const todaysWeatherForecastData = await todaysWeatherForecastResponse.json();
        
                let div = document.getElementById(`forecast`);
                div.style.display = `block`;
            
                let divCurrent = document.getElementById(`current`);
            
                let div1 = document.createElement(`div`);
                div1.classList.add(`forecasts`);
                
                let span1 = document.createElement(`span`);
                span1.className = `condition symbol`;
                switch(todaysWeatherForecastResult.condition){

                    case `Sunny`: span1.textContent = `\u2600`; break;
                    case `Partly sunny`: span1.textContent = `\u26C5`; break;
                    case `Overcast`: span1.textContent = `\u2601`; break;
                    case `Rain`: span1.textContent = `\u2614`; break;
                }

                div1.appendChild(span1);

                let span2 = document.createElement(`span`);
                span2.classList.add(`condition`);

                let childSpan1 = document.createElement(`span`);
                childSpan1.textContent = todaysWeatherData.name;
                childSpan1.className = `forecast-data`;

                let childSpan2 = document.createElement(`span`);
                childSpan2.textContent = `${todaysWeatherForecastData.low}\u00B0/${todaysWeatherForecastData.high}\u00B0`;
                childSpan2.className = `forecast-data`;

                let childSpan3 = document.createElement(`span`);
                childSpan3.textContent = todaysWeatherForecastData.condition;
                childSpan3.className = `forecast-data`;

                span2.appendChild(childSpan1);
                span2.appendChild(childSpan2);
                span2.appendChild(childSpan3);

                div1.appendChild(span2);
                divCurrent.appendChild(div1);
            }

        });
    } catch (error) {
        
        let div = document.getElementById(`forecast`);
        div.style.display = `block`;

        div.textContent = `Error`;
    }
    
}

attachEvents();