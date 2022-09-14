function walk(steps, footprint, km){

    let distance = steps * footprint;
    let countOfBreaks = Math.floor(distance / 500);
    let mPerKilometer = km / 3.6;

    let totalTime = countOfBreaks * 60;

    totalTime += Number(distance / mPerKilometer);

    let hours = totalTime / 3600;
    let minutes = totalTime / 60;
    
    hours = Math.floor(hours);
    minutes = Math.floor(minutes);
    let seconds = Number(totalTime - (minutes*60)).toFixed(0);

    let formatedHours = hours<10 ? `0${hours}` : `${hours}`;
    let formatedMinutes = minutes<10 ? `0${minutes}` : `${minutes}`;
    let formatedSeconds = seconds<10 ? `0${seconds}` : `${seconds}`;
    console.log(`${formatedHours}:${formatedMinutes}:${formatedSeconds}`);
}
