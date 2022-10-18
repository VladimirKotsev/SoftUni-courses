const { expect } = require(`chai`);

describe(`isOddOrEven`, () =>{

    it (`Function should return undefined when an object is passed`, () => {

        expect(isOddOrEven({ })).to.be.undefined;
    });

    it (`Function should return undefined when an array is passeed`, () => {

        expect(isOddOrEven([ ])).to.be.undefined;
    });

    it (`Function should return even when a string with even lenght is passeed`, () => {

        expect(isOddOrEven(`Nadenica`)).to.equal(`even`);
    });

    it (`Function should return odd when a string with odd lenght is passeed`, () => {

        expect(isOddOrEven(`shoes`)).to.equal(`odd`);
    });
});