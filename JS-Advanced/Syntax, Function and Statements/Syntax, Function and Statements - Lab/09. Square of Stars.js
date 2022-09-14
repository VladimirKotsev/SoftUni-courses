function printSquare(a){

    let helper = ``;
    for (let row = 1; row <= a; row++)
    {
        for (let i = 1; i <= a; i++)
        {
            helper += `* `;
        }
        console.log(helper);
        helper = ``;
    }
}
