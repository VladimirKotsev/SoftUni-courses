function attachEventsListeners() {

    let days = document.getElementById(`days`);
    let hours = document.getElementById(`hours`);
    let minutes = document.getElementById(`minutes`);
    let seconds = document.getElementById(`seconds`);

    let daysBtn = document.getElementById(`daysBtn`);
    let hoursBtn = document.getElementById(`hoursBtn`);
    let minutesBtn = document.getElementById(`minutesBtn`);
    let secondsBtn = document.getElementById(`secondsBtn`);

    daysBtn.addEventListener(`click`, function(){

        let day = days.value;

        hours.value = day * 24;
        minutes.value = day * 1440;
        seconds.value = day * 86400;
    });

    hoursBtn.addEventListener(`click`, function(){

        let hour = hours.value;

        days.value = hour / 24;
        minutes.value = hour * 60;
        seconds.value = hour * 3600;
    });

    minutesBtn.addEventListener(`click`, function(){

        let minute = minutes.value;

        hours.value = minute / 60;
        days.value = hours.value / 24;
        seconds.value = minute * 60;
    });

    secondsBtn.addEventListener(`click`, function(){

        let second = seconds.value;

        minutes.value = second / 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
    });

}