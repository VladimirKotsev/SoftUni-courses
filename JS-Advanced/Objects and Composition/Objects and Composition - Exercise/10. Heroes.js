function solve(){
    let obj = {

        mage(name){

            return {

                name: name,
                health: Number(100),
                mana: Number(100),
                cast(spell){
                    
                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                }
            };
        },
        fighter(name){

            return {

                name: name,
                health: Number(100),
                stamina: Number(100),
                fight(){

                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            };
        },
    };

    return obj;
}
