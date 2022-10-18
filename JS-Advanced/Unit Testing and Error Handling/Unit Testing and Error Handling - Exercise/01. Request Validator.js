function validor(obj){

    let methods = [`GET`, `POST`, `DELETE`, `CONNECT`];
    let versions = [`HTTP/0.9`, `HTTP/1.0`, `HTTP/1.1`, `HTTP/2.0`];
    let URIPattern = /^[\w+.]+$/g;
    let messagePattern = /\w+/g;

    if (!obj.method || !methods.includes(obj.method)){

        throw new Error(`Invalid request header: Invalid Method`);
    }
    else if (!obj.uri || obj.uri !== `*` && !obj.uri.match(URIPattern)){

        throw new Error(`Invalid request header: Invalid URI`);
    }
    else if (!obj.version || !versions.includes(obj.version)){

        throw new Error(`Invalid request header: Invalid Version`);
    }
    else if (obj.message === undefined || !obj.message.match(messagePattern) && obj.message !== `` || obj.message.includes(`<`) ||
    obj.message.includes(`>`) || obj.message.includes(`\\`) 
    || obj.message.includes(`&`) || obj.message.includes(`'`) || obj.message.includes(`"`)){

        throw new Error(`Invalid request header: Invalid Message`)
    }
    else{

        return obj;
    }
}