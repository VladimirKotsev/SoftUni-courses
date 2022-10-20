const { bookSelection } = require(`./bookSelection`);
const { expect } = require(`chai`);
const { assert } = require(`chai`);

describe("Tests …", function() {
    describe("isGenreSuitable tests", function() {

        it("Function should return book not suitable", function() {
                     
            expect(bookSelection.isGenreSuitable(`Thriller`, 10)).to.be.equal(`Books with Thriller genre are not suitable for kids at 10 age`);
            expect(bookSelection.isGenreSuitable(`Horror`, 10)).to.be.equal(`Books with Horror genre are not suitable for kids at 10 age`);
            expect(bookSelection.isGenreSuitable(`Thriller`, -5)).to.be.equal(`Books with Thriller genre are not suitable for kids at -5 age`);
            expect(bookSelection.isGenreSuitable(`Horror`, -10)).to.be.equal(`Books with Horror genre are not suitable for kids at -10 age`);
        });

        it (`Function should return book suitable`, () => {

            expect(bookSelection.isGenreSuitable(`Thriller`, 15)).to.be.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable(`Horror`, 20)).to.be.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable(`Drama`, 5)).to.be.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable(`Action`, 3)).to.be.equal(`Those books are suitable`);
        });
     });

     describe(`isItAffordable tests`, () => {

        it (`Function should throw Error when price is not a number`, () => {

            assert.throw(() => { bookSelection.isItAffordable(` `, 10); }, `Invalid input`);
            assert.throw(() => { bookSelection.isItAffordable({}, 10); }, `Invalid input`);
            assert.throw(() => { bookSelection.isItAffordable([], 10); }, `Invalid input`);
        });

        it (`Function should throw Error when budget is not a number`, () => {

            assert.throw(() => { bookSelection.isItAffordable(10, ` `); }, `Invalid input`);
            assert.throw(() => { bookSelection.isItAffordable(10, {}); }, `Invalid input`);
            assert.throw(() => { bookSelection.isItAffordable(10, []); }, `Invalid input`);
        });

        it (`Function should return unsuficiant money`, () => {

            expect(bookSelection.isItAffordable(200, 100)).to.be.equal(`You don't have enough money`);
            expect(bookSelection.isItAffordable(100.54, 54.92)).to.be.equal(`You don't have enough money`);
        });

        it (`Function should return book bought`, () => {

            expect(bookSelection.isItAffordable(100, 200)).to.be.equal(`Book bought. You have 100$ left`);
            expect(bookSelection.isItAffordable(54.3, 100.5)).to.be.equal(`Book bought. You have 46.2$ left`);
        });
     });

     describe(`suitableTitles tests`, () => {

        it (`Function should throw an Error when an array is not passeed`, () => {

            assert.throw(() => { bookSelection.suitableTitles({}, ` `); }, `Invalid input`);
            assert.throw(() => { bookSelection.suitableTitles(` `, ` `); }, `Invalid input`);
        });

        it (`Function should throw an Error when a string is not passed`, () => {

            assert.throw(() => { bookSelection.suitableTitles([], {}); }, `Invalid input`);
            assert.throw(() => { bookSelection.suitableTitles([], []); }, `Invalid input`);
        });

        it (`Function should return output correctly`, () => {

            assert.equal( bookSelection.suitableTitles([{ title: "It ends with us", genre: "Drama" }], `Drama`)[0] , `It ends with us`);
            expect(bookSelection.suitableTitles([{ title: "It ends with us", genre: "Drama" }], `Thriller`)[0]).to.be.equal(undefined);
            expect(bookSelection.suitableTitles([{ title: "Percy", genre: "Action" }, {title: `It`, genre: `Horror`}, {title: `F2F`, genre: `Action`}], `Action`)[0]).to.be.equal(`Percy`);
            expect(bookSelection.suitableTitles([{ title: "Percy", genre: "Action" }, {title: `It`, genre: `Horror`}, {title: `F2F`, genre: `Action`}], `Action`)[1]).to.be.equal(`F2F`);
        });
     });
     
});
