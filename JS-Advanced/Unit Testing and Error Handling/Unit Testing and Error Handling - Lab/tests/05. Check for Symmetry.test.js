const { expect } = require(`chai`);

const { isSymmetric } = require(`../05. Check for Symmetry`);

describe(`Tests for function isSymmetric`, () =>{

    describe(`Test function with wrong arguments`, () => {

        it(`should return false when a string is passed`, () => {
    
            expect(isSymmetric(`yes`)).to.be.false;
        });
        it (`should return false when an empty object is passed`, () => {
    
            expect(isSymmetric({})).to.be.false;
        });
        it (`should return false when an object is passed`, () => {
    
            expect(isSymmetric({name: `Benz`})).to.be.false;
        });
        it (`should return false when a number is passed`, () => {
    
            expect(isSymmetric(Number(0))).to.be.false;
        });
        it (`should return false when a null is passed`, () => {

            expect(isSymmetric(null)).to.be.false;
        });
        it (`should return false when an undefined is passed`, () => {

            expect(isSymmetric(undefined)).to.be.false;
        })
        it (`should return false when a boolean is passed`, () => {

            expect(isSymmetric(true)).to.be.false;
        })
    });

    describe(`Test function with right arguments`, () => {

        it (`should return true when array is symmetric`, () => {
    
            expect(isSymmetric([`a`, `b`, `a`])).to.be.true;
        });
        it (`should return false when array is not symmetric`, () => {
    
            expect(isSymmetric([`a`, `a`, `b`])).to.be.false;
        });
        it (`should return true when an empty array is passed`, () => {

            expect(isSymmetric([])).to.be.true;
        });
        it (`should return true when a array with one element is passed`, () =>{

            expect(isSymmetric([1])).to.be.true;
        });
    });
});