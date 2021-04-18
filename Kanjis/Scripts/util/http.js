const http = {
    get: async (url, args, onFinish) => {
        //verifica si hay argumentos, si los hay, concatena
        const endpoint = args ? url.concat('?', Object.keys(args).map(arg => arg.concat("=",args[arg])).toString().replace(/,/g, "&")) : url;
        //hace request via http
        fetch(endpoint)
            .then(resp => resp.json()) //transform response into json
            .then(resp => onFinish(resp)) //do a action with response
            .catch(err => console.error(err)); //respuesta en caso de error
    }
}
