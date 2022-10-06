function filter(employees, criteria){

    let result = [];
    employees = JSON.parse(employees);

    findMatching();

    for (let index = 0; index < result.length; index++) {

        console.log(`${index}. ${result[index].first_name} ${result[index].last_name} - ${result[index].email}`);
    }

    function findMatching(){

        let key = criteria.split(`-`)[0];
        let value = criteria.split(`-`)[1];

        for (let index = 0; index < employees.length; index++) {
            
            if (employees[index][key] === value){

                result.push(employees[index]);
            }
        }
    }
}
