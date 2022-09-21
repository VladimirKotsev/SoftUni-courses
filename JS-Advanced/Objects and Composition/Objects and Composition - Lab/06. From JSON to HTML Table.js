function toHTML(arr){
    console.log(`<table>`);
    console.log(`<tr><th>Name</th><th>Score</th></tr>`);  
    for (let element of arr){
        console.log(`<tr><th>${element["Name"]}</th><th>${element["Score"]}</th></tr>`);
    }
    console.log(`</table>`)
}

toHTML(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
);
console.log(`-------------`);
toHTML(`[{"Name":"Pesho",
"Score":4,
" Grade":8},
{"Name":"Gosho",
"Score":5,
" Grade":8},
{"Name":"Angel",
"Score":5.50,
" Grade":10}]`
);