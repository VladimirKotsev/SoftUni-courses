import { html, render } from '../node_modules/lit-html/lit-html.js';

const host = `http://localhost:3030/`;

export function navigation(){

    if (sessionStorage.accessToken !== undefined){ // logged in
        document.querySelector(`#user`).style.display = `inline-block`;
        document.querySelector(`#guest`).style.display = `none`;       
    }
    else{ // not logged in
        document.querySelector(`#user`).style.display = `none`;
        document.querySelector(`#guest`).style.display = `inline-block`;
    }
}

export async function postRequest(url, body){

    try {
        
        const response = await fetch(host + url, {
    
            method: 'post',
            headers: { 'Content-Type': 'application/json'},
            body: JSON.stringify(body)
        });
    
        if (response.ok === false){
    
            throw new Error(response.message);
        }
    
        const data = await response.json();
    
        return data;

    } catch (error) {
        
        console.log(error.message);
    }
}

export async function getRequest(url){

    const response = await fetch(host + url);

    const data = await response.json();

    return data;
}

export function createHtml(page){

    const views = {

        'register': html`
        <div class="container">
            <div class="row space-top">
                <div class="col-md-12">
                    <h1>Register New User</h1>
                    <p>Please fill all fields.</p>
                </div>
            </div>
            <form>
                <div class="row space-top">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="form-control-label" for="email">Email</label>
                            <input class="form-control" id="email" type="text" name="email">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="password">Password</label>
                            <input class="form-control" id="password" type="password" name="password">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="rePass">Repeat</label>
                            <input class="form-control" id="rePass" type="password" name="rePass">
                        </div>
                        <input type="submit" class="btn btn-primary" value="Register" />
                    </div>
                </div>
            </form>
        </div>`,
        'login': html`
        <div class="container">
            <div class="row space-top">
                <div class="col-md-12">
                    <h1>Login User</h1>
                    <p>Please fill all fields.</p>
                </div>
            </div>
            <form>
                <div class="row space-top">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="form-control-label" for="email">Email</label>
                            <input class="form-control" id="email" type="text" name="email">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="password">Password</label>
                            <input class="form-control" id="password" type="password" name="password">
                        </div>
                        <input type="submit" class="btn btn-primary" value="Login" />
                    </div>
                </div>
            </form>
        </div>
        `,
        'create': html`
        <div class="container">
            <div class="row space-top">
                <div class="col-md-12">
                    <h1>Create New Furniture</h1>
                    <p>Please fill all fields.</p>
                </div>
            </div>
            <form>
                <div class="row space-top">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="form-control-label" for="new-make">Make</label>
                            <input class="form-control valid" id="new-make" type="text" name="make">
                        </div>
                        <div class="form-group has-success">
                            <label class="form-control-label" for="new-model">Model</label>
                            <input class="form-control " id="new-model" type="text" name="model">
                        </div>
                        <div class="form-group has-danger">
                            <label class="form-control-label" for="new-year">Year</label>
                            <input class="form-control " id="new-year" type="number" name="year">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="new-description">Description</label>
                            <input class="form-control" id="new-description" type="text" name="description">
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="form-control-label" for="new-price">Price</label>
                            <input class="form-control" id="new-price" type="number" name="price">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="new-image">Image</label>
                            <input class="form-control" id="new-image" type="text" name="img">
                        </div>
                        <div class="form-group">
                            <label class="form-control-label" for="new-material">Material (optional)</label>
                            <input class="form-control" id="new-material" type="text" name="material">
                        </div>
                        <input type="submit" class="btn btn-primary" value="Create" />
                    </div>
                </div>
            </form>
        </div>
        `
    };

    return views[page];
}

export async function deleteRequest(url){

    const response = await fetch(host + url, {
        method: 'delete',
    });

    const data = await response.json();

    return data;
}