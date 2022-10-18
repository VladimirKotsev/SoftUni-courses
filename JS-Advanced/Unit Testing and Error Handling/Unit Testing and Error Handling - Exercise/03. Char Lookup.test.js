const { expect } = require(`chai`);

describe(`lookupChar`,() => {

    it (`Function should return undefined when an object instead of string is passed`, () => {

        expect(lookupChar( {}, 2 )).to.be.undefined;
    });

    it (`Function should return undefined when an array instead of string is passed`, () => {

        expect(lookupChar([], 2)).to.be.undefined;
    });

    it (`Function should return undefined when a string instead of number is passed`, () => {

        expect(lookupChar(`SoftUni`, `kjghghjghk`)).to.be.undefined;
    });

    it (`Function should return undefined when an object instead of number is passed`, () => {

        expect(lookupChar(`SoftUni`, {})).to.be.undefined;
    });

    it (`Function should return undefined when a floating-point number instead of integer number is passed`, () => {

        expect(lookupChar(`SoftUni`, 2.3056)).to.be.undefined;
    });

    it (`Function should return Incorrect index when index is less than 0`, () => {

        expect(lookupChar(`SoftUni`, -1)).to.be.equal(`Incorrect index`);
    });

    it (`Function should return Incorrect index when index is equal to string.length`, () => {

        expect(lookupChar(`SoftUni`, 7)).to.be.equal(`Incorrect index`);
    });

    it (`Function should return Incorrect index when index is more than string.length`, () => {

        expect(lookupChar(`SoftUni`, 8)).to.be.equal(`Incorrect index`);
    });

    it (`Function should return character at position 3`, () => {

        expect(lookupChar(`SoftUni`, 3)).to.be.equal(`t`);
    });

    it (`Function should return character at position 6`, () => {

        expect(lookupChar(`SoftUni`, 6)).to.be.equal(`i`);
    });
});