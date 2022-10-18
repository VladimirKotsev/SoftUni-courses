const { expect } = require("chai");
const { mathEnforcer } = require("./Math Enforceer");

describe(`mathEnforcer`, () => {

    describe(`addFive function tests`, () =>{

        it (`Function should return undefined when an object is passed`, () => {

            expect(mathEnforcer.addFive( {} )).to.be.undefined;
        });

        it (`Function should return undefined when an array is passed`, () => {

            expect(mathEnforcer.addFive( [] )).to.be.undefined;
        });

        it (`Function should return undefined when null, undefined are passed`, () => {

            expect(mathEnforcer.addFive(undefined)).to.be.undefined;
            expect(mathEnforcer.addFive(null)).to.be.undefined;
        });

        it (`Function should return correct value when a integer is passed`, () => {

            expect(mathEnforcer.addFive( 5 )).to.be.equal(10);
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });

        it (`Function should return correct value when a floating-point number is passed`, () => {

            expect(mathEnforcer.addFive(2.5)).to.be.equal(7.5);
            expect(mathEnforcer.addFive(-5.5)).to.be.equal(-0.5);
        });
    });

    describe(`substractTen function tests`, () => {

        it (`Function should return undefined when an object is passed`, () => {

            expect(mathEnforcer.subtractTen( {} )).to.be.undefined;
        });

        it (`Function should return undefined when an array is passed`, () => {

            expect(mathEnforcer.subtractTen( [] )).to.be.undefined;
        });

        it (`Function should return undefined when null, undefind are passed`, () => {

            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
        });

        it (`Function should return correct value when a integer is passed`, () => {

            expect(mathEnforcer.subtractTen( 10 )).to.be.equal(0);
            expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
        });

        it (`Function should return correct value when a floating-point number is passed`, () => {

            expect(mathEnforcer.subtractTen(14.6)).to.be.equal(4.6);
            expect(mathEnforcer.subtractTen(-0.5)).to.be.equal(-10.5);
        });

    });

    describe(`sum function tests`, () => {

        it (`Function should return undefineed when an object is passed to num1`, () => {

            expect(mathEnforcer.sum({}, 4)).to.be.undefined;
        });

        it (`Function should return undefined when an array is passed to num1`, () => {

            expect(mathEnforcer.sum([], 3)).to.be.undefined;
        });

        it (`Function should return undefined when null, undefined are passed to num1`, () =>{

            expect(mathEnforcer.sum(null, 5)).to.be.undefined;
            expect(mathEnforcer.sum(undefined, 10)).to.be.undefined;
        });

        it (`Function should return undefined when an object is passed to num2`, () => {

            expect(mathEnforcer.sum(5, {})).to.be.undefined;
        });

        it (`Function should return undefined when an array is passed to num2`, () => {

            expect(mathEnforcer.sum(10, [])).to.be.undefined;
        });

        it (`Function should return undefined when null, undefined are passed to num1`, () =>{

            expect(mathEnforcer.sum(5, null)).to.be.undefined;
            expect(mathEnforcer.sum(10, undefined)).to.be.undefined;
        });

        it (`Function should return correct output`, () => {

            expect(mathEnforcer.sum(10, 5)).to.be.equal(15);
            expect(mathEnforcer.sum(-5, 5)).to.be.equal(0);
            expect(mathEnforcer.sum(-10, -7)).to.be.equal(-17);
            expect(mathEnforcer.sum(10, -20)).to.be.equal(-10);
            expect(mathEnforcer.sum(2.5, -5.5)).to.be.equal(-3);
            expect(mathEnforcer.sum(-5.5, -7.7)).to.be.equal(-13.2);
            expect(mathEnforcer.sum(-10, -5.5)).to.be.equal(-15.5);

        });
    });
});