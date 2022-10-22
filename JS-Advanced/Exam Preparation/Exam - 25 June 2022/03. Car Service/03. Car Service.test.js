const {assert} = require(`chai`);
const {expect} = require(`chai`);

const {carService} = require(`./03. Car Service`);

describe("Tests …", function() {

    describe(`Function isItExpensive tests`, function() {

        it(`Function should return cheap fix`, function() {
            
            expect(carService.isItExpensive(`Disks`)).to.be.equal(`The overall price will be a bit cheaper`);
            expect(carService.isItExpensive(`HandBrake`)).to.be.equal(`The overall price will be a bit cheaper`);
            expect(carService.isItExpensive(` `)).to.be.equal(`The overall price will be a bit cheaper`);
            expect(carService.isItExpensive(undefined)).to.be.equal(`The overall price will be a bit cheaper`);
        });

        it (`Function should return major issue`, () => {

            expect(carService.isItExpensive(`Engine`)).to.be.equal(`The issue with the car is more severe and it will cost more money`);
            expect(carService.isItExpensive(`Transmission`)).to.be.equal(`The issue with the car is more severe and it will cost more money`);
        });
     });

     describe(`Function discount tests`, () => {

        it (`Function should throw Error`, () => {

            assert.throws(() => {carService.discount({}, 2000)}, "Invalid input");
            assert.throws(() => {carService.discount(`no`, 3000)}, "Invalid input");

            assert.throws(() => {carService.discount(3, [])}, "Invalid input");
            assert.throws(() => {carService.discount(2, false)}, "Invalid input");
        });

        it (`Function should return cannot apply discount`, () => {

            expect(carService.discount(2, 2000)).to.equal("You cannot apply a discount");
            expect(carService.discount(-5, 2000)).to.equal("You cannot apply a discount");
            expect(carService.discount(0, 2000)).to.equal("You cannot apply a discount");
        });

        it (`Function should return correct output with 15% discount`, () => {

            expect(carService.discount(3, 1000)).to.equal(`Discount applied! You saved 150$`);
            expect(carService.discount(5, 1000)).to.equal(`Discount applied! You saved 150$`);
            expect(carService.discount(7, 1000)).to.equal(`Discount applied! You saved 150$`);
        });

        it (`Function should return correct output with 30% discount`, () => {

            expect(carService.discount(8, 1000)).to.equal(`Discount applied! You saved 300$`);
            expect(carService.discount(13, 1000)).to.equal(`Discount applied! You saved 300$`);
            expect(carService.discount(20, 1000)).to.equal(`Discount applied! You saved 300$`);
        }); 
     });

     describe(`Function partsToBuy`, () => {

        it (`Function should throw an Error`, () => {

            assert.throws(() => { carService.partsToBuy({}, []) }, "Invalid input");
            assert.throws(() => { carService.partsToBuy(` `, []) }, "Invalid input");

            assert.throws(() => { carService.partsToBuy([], false) }, "Invalid input");
            assert.throws(() => { carService.partsToBuy([], 5) }, "Invalid input");
        });

        it (`Function should return correct output`, () => {

            let partsCatalog = [{part: `disks`, price: Number(300)}, {part: `throttleBody`, price: Number(70)}, {part: `rods`, price: Number(150)}];

            expect(carService.partsToBuy(partsCatalog, [`disks`, `rods`])).to.equal(Number(450));
            expect(carService.partsToBuy(partsCatalog, [`throttleBody`])).to.equal(Number(70));
            expect(carService.partsToBuy(partsCatalog, [`rods`])).to.equal(Number(150));
        });
    });     
});