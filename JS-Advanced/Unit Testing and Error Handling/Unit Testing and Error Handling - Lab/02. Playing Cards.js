function cards(card, suit){

    let result = ``;

    let suits = [`S`, `H`, `D`, `C`];
    let cards = [`2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `J`, `Q`, `K`, `A`];

    if (cards.includes(card) && suits.includes(suit)){

        result += card;
        if (suit === `S`){
            suit = `\u2660`;
        }
        else if (suit === `H`){
            suit = `\u2665`;
        }
        else if (suit === `D`){
            suit = `\u2666`;
        }
        else if (suit === `C`){
            suit = `\u2663`;
        }

        return {

            face: card,
            suit: suit,
            toString(){
                return this.face + this.suit;
            }
        }
    }
    else{

        throw new Error (`Error`);
    }
}