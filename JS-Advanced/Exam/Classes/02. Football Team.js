class footballTeam{

    constructor(clubName, country){

        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers){

        let playerNames = [];
        footballPlayers.forEach(element => {
            
            let [name, age, playerValue] = element.split(`/`);
            age = Number(age);
            playerValue = Number(playerValue);

            let player = this.invitedPlayers.find(x => x.name === name);

            if (player !== undefined){

                if (playerValue > player.value){

                    player.value = playerValue;
                }
            }
            else{

                let obj = {

                    name: name,
                    age: age,
                    value: playerValue
                };

                this.invitedPlayers.push(obj);
            }

            if (!playerNames.includes(name)){

                playerNames.push(name);
            }
        });

        return `You successfully invite ${playerNames.join(`, `)}.`;
    };

    signContract(selectedPlayer){

        let [name, playerOffer] = selectedPlayer.split(`/`);
        playerOffer = Number(playerOffer);

        let player = this.invitedPlayers.find(x => x.name === name);

        if (player === undefined){

            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (player.value > playerOffer){

            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.value - playerOffer} million more are needed to sign the contract!`);
        }

        player.value = `Bought`;

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    };

    ageLimit(name, age){

        age = Number(age);

        let player = this.invitedPlayers.find(x => x.name === name);

        if (player === undefined){

            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (age > player.age){

            let diffAge = age - player.age;

            if (diffAge < 5){

                return `${name} will sign a contract for ${diffAge} years with ${this.clubName} in ${this.country}!`
            }
            else if (diffAge >= 5){

                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
        }
        else if (player.age >= age){

            return `${name} is above age limit!`
        }
    };

    transferWindowResult(){

        let result = `Players list:\n`;

        this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name));

        this.invitedPlayers.forEach(element => {
            
            result += `Player ${element.name}-${element.value}\n`;
        });

        return result.trimEnd();
    };
};
