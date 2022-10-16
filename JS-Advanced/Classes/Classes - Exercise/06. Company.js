class Company{

    constructor(){

        this.departments = {};
    }

    addEmployee(name, salary, position, department){

        if (!name || !salary || !position || !department || salary < 0){

            throw new Error(`Invalid input!`);
        }

        if (!this.departments[department]){

            this.departments[department] = {

                avgSalary(){

                    let count = Number(0);
                    let sum = Number(0);

                    for (let employee of this.employes) {
                        
                        sum += Number(employee.salary);
                        count++;
                    }

                    return sum / count;
                },

                employes: [ {name: name, salary: Number(salary), position: position} ]
            };
        }
        else{

            this.departments[department].employes.push( {name: name, salary: Number(salary), position: position} );
        }

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        let max = 0;
        let obj = {};
        let best = ``;
        let result = ``;

        for (let department in this.departments) {
            
            if (this.departments[department].avgSalary() > max){

                max = this.departments[department].avgSalary();
                obj = this.departments[department];
                best = department;
            }
        }

        result += `Best Department is: ${best}\n`;
        result += `Average salary: ${obj.avgSalary().toFixed(2)}\n`

        obj.employes.sort((a, b) => { return b.salary - a.salary || a.name.localeCompare(b.name) } );
        

        for (let employee of obj.employes) {
            
            result += `${employee.name} ${employee.salary} ${employee.position}\n`;
        }

        return result.trimEnd();
    }
}
