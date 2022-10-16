function printDeckOfCards(cards) {

    let arr = [];
    try {
        
        for (let c of cards) {
            
            if (c.length > 3){
                
                throw new Error(`Invalid card: ${card}`);
            }
            
            let face = c.slice(0, c.length - 1);
            let suit = c[c.length - 1];
            
            let card = createCard(face, suit, c);
            arr.push(card.toString());
        }
    } catch (error) {

        console.log(error.message);
        return;
    }

    
    console.log(arr.join(` `));
    
    function createCard(face, suit, card){
       
        let suits = [`S`, `H`, `D`, `C`];
        let faces = [`2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `J`, `Q`, `K`, `A`];

        let result = ``;
        if (faces.includes(face) && suits.includes(suit)){

            result += face;
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

                face: face,
                suit: suit,
                toString(){
                    
                    return this.face + this.suit;
                }
            }
        }
        else{

            throw new Error(`Invalid card: ${card}`);
        }
    }
  }
