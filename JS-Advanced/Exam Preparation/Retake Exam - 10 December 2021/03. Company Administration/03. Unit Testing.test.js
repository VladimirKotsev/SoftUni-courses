const { expect } = require(`chai`);
const { assert } = require(`chai`);

const { companyAdministration } = require(`./03. Unit Testing`);

describe("Tests …", function() {

    describe(`Function hiringEmploye tests`, function() {

        it("Function should throw Error", function() {
            
            assert.throws(() => {companyAdministration.hiringEmployee(` `, ` `, 3);}, `We are not looking for workers for this position.`);
            assert.throws(() => {companyAdministration.hiringEmployee(`Dimitko`, `Cleaner`, 10);}, `We are not looking for workers for this position.`);
            assert.throws(() => {companyAdministration.hiringEmployee(`Ivan`, `Coder`, -3);}, `We are not looking for workers for this position.`);
        });

        it (`Function should return not approved for position`, () => {

            expect(companyAdministration.hiringEmployee(`Pesho`, `Programmer`, 1)).to.be.equal(`Pesho is not approved for this position.`);
            expect(companyAdministration.hiringEmployee(`Ivan`, `Programmer`, 2)).to.be.equal(`Ivan is not approved for this position.`);
            expect(companyAdministration.hiringEmployee(`Stamat`, `Programmer`, -5)).to.be.equal(`Stamat is not approved for this position.`);
            expect(companyAdministration.hiringEmployee(`George`, `Programmer`, -10)).to.be.equal(`George is not approved for this position.`);
            expect(companyAdministration.hiringEmployee(`Boiko`, `Programmer`, -1.6)).to.be.equal(`Boiko is not approved for this position.`);
            expect(companyAdministration.hiringEmployee(`Rumen`, `Programmer`, 2.4)).to.be.equal(`Rumen is not approved for this position.`);
        });

        it (`Function should return successfully hired`, () => {

            expect(companyAdministration.hiringEmployee(`Pesho`, `Programmer`, 3)).to.be.equal(`Pesho was successfully hired for the position Programmer.`);
            expect(companyAdministration.hiringEmployee(`Stanoya`, `Programmer`, 10)).to.be.equal(`Stanoya was successfully hired for the position Programmer.`);
            expect(companyAdministration.hiringEmployee(`Boris`, `Programmer`, 99)).to.be.equal(`Boris was successfully hired for the position Programmer.`);
            expect(companyAdministration.hiringEmployee(`Krasi`, `Programmer`, 5)).to.be.equal(`Krasi was successfully hired for the position Programmer.`);

        });
     });

     describe(`Function calculateSalary tests`, () => {

        it (`Function should throw an Error`, () => {

            assert.throws(() => { companyAdministration.calculateSalary({}) }, `Invalid hours`);
            assert.throws(() => { companyAdministration.calculateSalary([]) }, `Invalid hours`);
            assert.throws(() => { companyAdministration.calculateSalary(-10) }, `Invalid hours`);
            assert.throws(() => { companyAdministration.calculateSalary(-2) }, `Invalid hours`);
            assert.throws(() => { companyAdministration.calculateSalary(-5.7) }, `Invalid hours`);
            assert.throws(() => { companyAdministration.calculateSalary(-9.8) }, `Invalid hours`);
        });

        it (`Function should return correct totalAmount`, () => {

            expect(companyAdministration.calculateSalary(1)).to.be.equal(15);
            expect(companyAdministration.calculateSalary(10)).to.be.equal(150);
            expect(companyAdministration.calculateSalary(0)).to.be.equal(0);
            expect(companyAdministration.calculateSalary(170)).to.be.equal(3550);
            expect(companyAdministration.calculateSalary(200)).to.be.equal(4000);
            expect(companyAdministration.calculateSalary(5.5)).to.be.equal(82.5);
            expect(companyAdministration.calculateSalary(160.5)).to.be.equal(3407.5);

        });
     });

     describe(`Function firedEmployee tests`, () => {

        it (`Function should throw an Error`, () => {

            let employees = [`Ivan`, `George`, `Stamat`, `Spas`];
            assert.throws(() => {companyAdministration.firedEmployee({}, 5)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(` `, 5)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee([], {})}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee([], [])}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, -10)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, -5)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, 4)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, 10)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, 2.3)}, `Invalid input`);
            assert.throws(() => {companyAdministration.firedEmployee(employees, -5.2)}, `Invalid input`);
        });

        it (`Function should return result correctly`, () => {

            let employees = [`Ivan`, `George`, `Stamat`, `Spas`];

            expect(companyAdministration.firedEmployee(employees, 3)).to.equals('Ivan, George, Stamat');
            expect(companyAdministration.firedEmployee(employees, 1)).to.equals('Ivan, Stamat, Spas');
            expect(companyAdministration.firedEmployee(employees, 0)).to.equals('George, Stamat, Spas');
        });
     });
});
