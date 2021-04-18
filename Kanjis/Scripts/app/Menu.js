
function getMenu() {
    //# = id
    http.get("/Home/getMenu", null, resp => {
        console.log(resp)
        var html = "";
        resp.items.forEach(item => html = html.concat("<li>", '<button onClick="redirect(\'',item.Url,'\')">', item.Nombre, "</button>", "</li>"));
        document.querySelector("#message-loaded").innerHTML = html;
    })
}

function redirect(url) {
    document.location.href = url;
}

getMenu();