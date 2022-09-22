function toHTML(input){

    let arr = JSON.parse(input);
    let HTML = ``;

    //html table open
    HTML += "<table>\n"

    //header
    HTML += HTMLHeader();

    //body
    HTML += HTMLBody();

    //html table close
    HTML += `</table>`
    
    //print
    console.log(HTML);
    


    function HTMLEscape(value){
        
        return value
                .toString()
                .replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&#39;');

    }
    function HTMLHeader(){

        let concat = `   <tr>`

        for(let key of Object.keys(arr[0])){
            concat += `<th>${HTMLEscape(key)}</th>`;
        }

        concat += `</tr>`
        concat += `\n`;

        return concat;
    }
    function HTMLBody(){

        let concat = ``;

        for(let element of arr){

            concat += `   <tr>`;

            for(let value of Object.values(element)){
                concat += `<td>${HTMLEscape(value)}</td>`;
            }

            concat += `</tr>`;
            concat += `\n`;
        }

        return concat;
    }
}