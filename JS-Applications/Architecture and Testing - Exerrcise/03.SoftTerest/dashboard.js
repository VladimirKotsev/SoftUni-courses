import { hideHeaders, hideSections, getRequest } from "./utils.js";

const section = document.getElementById(`dashboard-page`);

export function showDashboardPageOnClick(event){

    event.preventDefault();

    showDashboardPage();
}

export async function showDashboardPage(){

    hideHeaders();
    hideSections();
    visualizeHeaders();
    
    const divTemplate = section.getElementsByTagName(`div`)[0].cloneNode(true);
    const h1 = section.getElementsByTagName(`h1`)[0].cloneNode(true);

    section.style.display = `block`;

    const data = await getRequest(`data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc`);

    if (!data){

        section.replaceChildren(h1);
    }
    else{

        console.log(data);
    }
}

function visualizeHeaders(){

    document.getElementById(`dashboard`).style.display = `block`;
    document.getElementById(`create`).style.display = `block`;
    document.getElementById(`logout`).style.display = `block`;
}