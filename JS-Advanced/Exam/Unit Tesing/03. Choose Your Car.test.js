const {assert} = require(`chai`);
const {expect} = require(`chai`);

const {chooseYourCar} = require(`./03. Choose Your Car`);

describe("Tests …", function() {
    describe("Function choosingType tests", function() {

        it("Function should throw Error for invalid year", function() {
            
            assert.throws(() => { chooseYourCar.choosingType(`Sedan`, `red`, 1899) },`Invalid Year!`);
            assert.throws(() => { chooseYourCar.choosingType(`Sedan`, `red`, 2023) },`Invalid Year!`);
            assert.throws(() => { chooseYourCar.choosingType(`Sedan`, `red`, 2056) },`Invalid Year!`);
        });

        it (`Function should throw Error invalid type`, () => {

            assert.throw(() => { chooseYourCar.choosingType(`Combi`, `white`, 2000) }, `This type of car is not what you are looking for.`);
            assert.throw(() => { chooseYourCar.choosingType(`Hatchback`, `purple`, 2010) }, `This type of car is not what you are looking for.`);
            assert.throw(() => { chooseYourCar.choosingType(`Coupe`, `green`, 2009) }, `This type of car is not what you are looking for.`);
        });

        it (`Function should return correct output when year is higher than 2010`, () => {

            expect(chooseYourCar.choosingType(`Sedan`, `white`, 2012)).to.equal(`This white Sedan meets the requirements, that you have.`);
            expect(chooseYourCar.choosingType(`Sedan`, `red`, 2010)).to.equal(`This red Sedan meets the requirements, that you have.`);
            expect(chooseYourCar.choosingType(`Sedan`, `blue`, 2020)).to.equal(`This blue Sedan meets the requirements, that you have.`);
        });

        it (`Function should return correct output when year is less than 2010`, () => {

            expect(chooseYourCar.choosingType(`Sedan`, `white`, 2009)).to.equal(`This Sedan is too old for you, especially with that white color.`);
            expect(chooseYourCar.choosingType(`Sedan`, `green`, 2007)).to.equal(`This Sedan is too old for you, especially with that green color.`);
            expect(chooseYourCar.choosingType(`Sedan`, `red`, 2004)).to.equal(`This Sedan is too old for you, especially with that red color.`);
        });
     });

     describe(`Function brandName tests`, () => {

        let brands = [`BMW`, `Honda`, `Toyota`, `Fiat`];
        it (`Function should throw an Error`, () => {

            assert.throws(() => {chooseYourCar.brandName({}, 5)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.brandName(` `, 5)}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.brandName([], 5.5)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.brandName([], 0.2)}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.brandName([], -1)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.brandName([], -5)}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.brandName(brands, 4)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.brandName(brands, 11)}, "Invalid Information!");
        });

        it (`Function should return correct output`, () => {

            expect(chooseYourCar.brandName(brands, 3)).to.equal(`BMW, Honda, Toyota`);
            expect(chooseYourCar.brandName(brands, 1)).to.equal(`BMW, Toyota, Fiat`);
            expect(chooseYourCar.brandName(brands, 2)).to.equal(`BMW, Honda, Fiat`);
        });
     });
     
     describe(`Function carFuelConsumption tests`, () => {

        it (`Function should throw an Error`, () => {

            assert.throws(() => {chooseYourCar.carFuelConsumption(` `, 5)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.carFuelConsumption([] , 7)}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.carFuelConsumption(5, false)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.carFuelConsumption(10, {})}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.carFuelConsumption(0, 3)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.carFuelConsumption(-5, 8)}, "Invalid Information!");

            assert.throws(() => {chooseYourCar.carFuelConsumption(4, 0)}, "Invalid Information!");
            assert.throws(() => {chooseYourCar.carFuelConsumption(6, -8)}, "Invalid Information!");
        });

        it (`Function should return tuzar car`, () => {

            expect(chooseYourCar.carFuelConsumption(240, 24)).to.equal(`The car burns too much fuel - 10.00 liters!`);
            expect(chooseYourCar.carFuelConsumption(500, 37)).to.equal(`The car burns too much fuel - 7.40 liters!`);
            expect(chooseYourCar.carFuelConsumption(350, 42)).to.equal(`The car burns too much fuel - 12.00 liters!`);
        });

        it (`Function should return output efficient car`, () => {

            expect(chooseYourCar.carFuelConsumption(500, 35)).to.equal(`The car is efficient enough, it burns 7.00 liters/100 km.`);
            expect(chooseYourCar.carFuelConsumption(640, 35)).to.equal(`The car is efficient enough, it burns 5.47 liters/100 km.`);
            expect(chooseYourCar.carFuelConsumption(240, 12)).to.equal(`The car is efficient enough, it burns 5.00 liters/100 km.`);
        });
     });
});
