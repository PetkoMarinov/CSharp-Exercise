function getPreviosDay(year,month, day){
    let input = `${year}-${month}-${day}`;
    let date = new Date(input);
    date.setDate(date.getDate() - 1);

    return `${date.getFullYear()}-${date.getMonth()+1}-${date.getDate()}`;
}

console.log(getPreviosDay(2016, 10, 1));
