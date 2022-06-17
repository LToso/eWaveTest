const url = "https://localhost:7090/api/";

$(document).ready(function () {

    list();

    $('#btnGravar').click(function () {
        send();
    });

    $('#btnExcluir').click(function () {
        remove($('#txID').val());
    });

    $('#btnLimpar').click(function () {
        clear();
    });
});


function clear() {
    $('#txID').val('-1');
    $('#txModelo').val('FH');
    $('#txAnoModelo').val('');
    $('#txAnoProd').val('');
    $('#txTamanho').val('');
    $('#txPesoBruto').val('');
    $('#txEixos').val('');
    $('#txCapacCarga').val('');
}

async function select(id) {
    await fetch(url + "truck?id=" + id)
        .then(response => response.json())
        .then(function (response) {
            console.log(response);
            $('#txID').val(response.id);
            $('#txModelo').val(response.model);
            $('#txAnoModelo').val(response.modelYear);
            $('#txAnoProd').val(response.prodYear);
            $('#txTamanho').val(response.maxLenght);
            $('#txPesoBruto').val(response.grossWeight);
            $('#txEixos').val(response.axes);
            $('#txCapacCarga').val(response.loadCapac);
        })
        .catch(function (error) {
            console.log(error);
        });
}

async function list() {
    clear();
    await fetch(url + "truck?id=0")
        .then(response => response.json())
        .then(function (response) {
            console.log(response);
            $('#listBody').html(response.map(x =>
                "<tr onclick='select(" + x.id + ")'>" +
                "<td>" + x.id + "</td>" +
                "<td>" + x.model + "</td>" +
                "<td>" + x.modelYear + "</td>" +
                "<td>" + x.prodYear + "</td>" +
                "<td>" + x.maxLenght + "</td>" +
                "<td>" + x.grossWeight + "</td>" +
                "<td>" + x.axes + "</td>" +
                "<td>" + x.loadCapac + "</td>" +
                "</tr>"
            ));
        })
        .catch(function (error) {
            console.log(error);
        });
}

async function send() {

    var currentTime = new Date();

    obj = {
        id: $('#txID').val(),
        model: $('#txModelo').val(),
        modelYear: $('#txAnoModelo').val(),
        prodYear: $('#txAnoProd').val(),
        maxLenght: $('#txTamanho').val() || 0,
        grossWeight: $('#txPesoBruto').val() || 0,
        axes: $('#txEixos').val() || 0,
        loadCapac: $('#txCapacCarga').val() || 0
    }

    if (obj.modelYear != currentTime.getFullYear() && obj.modelYear != currentTime.getFullYear() + 1) {
        alert("A data do modelo não pode ser diferente de " + currentTime.getFullYear() + " ou " + (currentTime.getFullYear() + 1).toString() + ".");
        return;
    }

    if (obj.prodYear != currentTime.getFullYear()) {
        alert("A data de produção não pode ser diferente de " + currentTime.getFullYear() + ".");
        return;
    }

    let method = "PUT";

    if (obj.id == "-1")
        method = "POST";

    let data = {
        method: method,
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(obj)
    }

    await fetch(url + "truck", data)
        .then(response => response)
        .then(function (response) {
            console.log(response);
            if (obj.id == "-1")
                alert("Caminhão incluido com sucesso.");
            else
                alert("Caminhão alterado com sucesso.");
            list();
        })
        .catch(function (error) {
            console.log(error);
            alert('Ocorreu um erro ao enviar os dados, tente novamente');
        });

}

async function remove(id) {

    if (!id) {
        alert("Nenhum registro selecionado.");
    }

    let data = {
        method: "DELETE",
        headers: { 'Content-type': 'application/json' }
    }

    await fetch(url + "truck?id=" + id, data)
        .then(response => response)
        .then(function (response) {
            console.log(response);
            alert("Caminhão removido com sucesso (ID: " + id + ").");
            list();
        })
        .catch(function (error) {
            console.log(error);
            alert('Ocorreu um erro ao excluir, tente novamente');
        });
}