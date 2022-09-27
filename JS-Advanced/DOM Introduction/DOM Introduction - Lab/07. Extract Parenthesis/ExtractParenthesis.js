function extract(content) {

    let text = document.getElementById(content).textContent;
    let regex = /[(][A-Za-z\s]*[)]/g;

    let matched = text.match(regex);

    return matched.join(`; `);
}