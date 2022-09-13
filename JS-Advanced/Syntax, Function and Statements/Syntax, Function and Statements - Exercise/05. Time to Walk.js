function walk(steps, footprint, km){

    let distance = steps * footprint;
    let countOfBreaks = distance / 500;
    let mPerKilometer = km / 3.6;

    let totalTime = countOfBreaks * 60;

    totalTime += Number(distance / mPerKilometer);

    let hours = totalTime / 3600;
    let minutes = totalTime / 60;


    console.log(totalTime);
}

walk(4000, 0.60, 5);
walk(2564, 0.70, 5.5);