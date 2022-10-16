const { expect } = require(`chai`);

const { sum } = require(`../04. Sum of Numbers`);

describe(`sum`, () =>{

    it(`should be calculated good`, () => {

        let arr = [2, 2, 2];

        let result = sum(arr);

        expect(result).to.be.equal(6);
    });
    it(`should return NaN, if input is not an array`, () =>{
        
        let arr = `test`;

        let result = sum(arr);

        expect(result).to.be.NaN;
    });
});