function radar(speed, area){

    let speedLimit = Number(0);
    switch(area)
    {
        case `city`: speedLimit = Number(50); break;
        case `interstate`: speedLimit = Number(90); break;
        case `motorway`: speedLimit = Number(130); break;
        case `residential`: speedLimit = Number(20); break;
    }

    if (speed <= speedLimit)
    {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`)
    }
    else
    {
        let status = ``;
        let diff = speed - speedLimit;
        if (diff <= 20)
        {
            status = `speeding`;
        }
        else if (diff <= 40)
        {
            status = `excessive speeding`;
        }
        else
        {
            status = `reckless driving`;
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }

}
