function createAssemblyLine(){

    myObj = {
        hasClima(myCar){
            myCar.temp = Number(21);
            myCar.tempSettings = Number(21);
            myCar.adjustTemp = function() {

                if (this.temp < this.tempSettings){
                    this.temp++;
                }
                else if (this.temp > this.tempSettings){
                    this.temp--;
                }
            }            
        },            
        hasAudio(myCar){
            myCar.currentTrack = {};
            myCar.nowPlaying = function() {
                console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
            }
        },
        hasParktronic(myCar){

            myCar.checkDistance = function(number) {
                number = Number(number);
                if (number < 0.1){
                    console.log("Beep! Beep! Beep!");
                }
                else if (number < 0.25){
                    console.log("Beep! Beep!");
                }
                else if (number < 0.5){
                    console.log("Beep!");   
                }
                else{
                    console.log(``);
                }
            }
        }

    };

    return myObj;
}

