function cityTaxes(cityName, cityPopulation, cityTreasury){
    cityPopulation = Number(cityPopulation);
    cityTreasury = Number(cityTreasury);

    let city ={
        name: cityName,
        population: cityPopulation,
        treasury: cityTreasury,
        taxRate: Number(10),
        collectTaxes(){
            this.treasury += Number(this.population) * Number(this.taxRate);
        },
        applyGrowth(percentage){
            this.population += Math.floor(this.population * percentage / 100);
        },
        applyRecession(percentage){
            this.treasury -= Math.floor(this.treasury * percentage / 100);
        }
    };

    return city;
}

