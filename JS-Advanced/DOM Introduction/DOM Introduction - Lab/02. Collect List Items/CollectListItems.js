function extractText() {

    let result = document.getElementById(`result`).textContent;
    let li = document.getElementsByTagName(`li`);

    for (let i = 0; i < li.length; i++){

        result += li[i].textContent + `\n`;
    }

    result.trim();
    document.getElementById(`result`).textContent = result;
}