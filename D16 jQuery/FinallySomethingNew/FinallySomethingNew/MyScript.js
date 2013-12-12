$(document).ready(function() {
    var motos;

    function populateTable() {
        $("#tabelMoto").empty();
        $("#tabelMoto").append("<tr><th>Brand</th><th>Model</th><th>Year</th><th>Image</th></tr>");

        for (var x = 0; x < motos.length; x++) {
            $("#tabelMoto").append('<tr class="element"' +
                "<td>" + motos[x].Brand + "</td>" +
                "<td>" + motos[x].Model + "</td>" +
                "<td>" + motos[x].Year + "</td>" +
                '<td><img alt="poza moto" src="' + motos[x].Image + '" />' +
                "</tr>");
        }
    }

    $("#listMotos").click(function() {
        $.ajax({
            url: "/Motorcycles/List",
            dataType: "json",
            contentType: "application/json",
            success: function(data) {
                motos = data;
                console.log(motos);
                populateTable();
            },
            error: function() {
                alert("Nu s-a putut apela List()!");
            }
        });
    });
    
    $("#insertMoto").click(function() {
        var brand = $("#inputBrand").val();
        var model = $("#inputModel").val();
        var year = $("#inputYear").val();
        var moto = { Brand: brand, Model: model, Year: year };
        $.ajax({
            url: "/Motorcycles/Insert",
            type: "POST",
            data: JSON.stringify(moto),
            dataType: "json",
            contentType: "application/json",
            success: function() {
                alert("Motocicleta a fost adaugata cu succes!");
                $("#inputBrand").val('');
                $("#inputModel").val('');
                $("#inputYear").val('');
                $("#listMotos").click();
            },
            error: function(jqXHR, exception) {
                alert("Nu s-a adaugat motocicleta!\n" + jqXHR + '\n' + exception);
            }
    });
    })
});