function days(month, year){
    let date = new Date(year, month - 1);
    date.setMonth(month);
    let day = date.getDate();

    date.setDate(day - 1);
    let days = date.getDate();
    console.log(days);
}