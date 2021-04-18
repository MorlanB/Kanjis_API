console.log("kanjis");

function getTarjetas() {
    http.get("/Tarjetas/getTarjetas", null, resp => {
        //console.log(resp)
        formatTarjetas(resp);
    })
}

function formatTarjetas(tarjetas) {
    document.querySelector("#ListadoTarjetas").innerHTML = "";
    for (let item of tarjetas) {
        let button = document.createElement("button");
        button.textContent = item.significado;
        button.onclick = (() => { alert(`Kanji: ${item.kanji} \nSignificado: ${item.significado} \nLectura: ${item.lectura}  \nNotas: ${item.notas}  \nId de tarjeta: ${item.id}`) });

        let li = document.createElement("li");
        li.appendChild(button);
        document.querySelector("#ListadoTarjetas").appendChild(li);
    }
}

function search() {
    let type = document.querySelector("#searchType").value;
    let search = document.querySelector("#search").value;
    http.get(`/Tarjetas/getTarjetasBy${type}`, { [type.toLowerCase()]: search }, resp => {
        formatTarjetas(resp);
    })}

getTarjetas();