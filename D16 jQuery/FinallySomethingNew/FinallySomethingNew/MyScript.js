$(document).ready(function() {
    var motos;

    function populateTable() {
        var tabel = $("#tabelMoto");
        tabel.empty();
        tabel.append("<tr><th>Brand</th><th>Model</th><th>Year</th><th>Image</th><th></th></tr>");

        for (var x = 0; x < motos.length; x++) {
            tabel.append("<tr data-brand=\"" + motos[x].Brand + "\" data-model=\"" + motos[x].Model + "\">" +
                "<td>" + motos[x].Brand + "</td>" +
                "<td>" + motos[x].Model + "</td>" +
                "<td>" + motos[x].Year + "</td>" +
                "<td><img src=\"" + motos[x].Image + "\" /></td>" +
                "<td><input type=\"button\" value=\"+\" class=\"buttonMore\" data-id=\"" + x + "\" /></td>" +
                "</tr>");
        }
    }

    $(document).on("click", ".buttonMore", function() {
        var id = parseInt($(this).attr("data-id"));
        var container = $("#motoInfo");
        container.empty();
        container.append("<p>Brand: " + motos[id].Brand + "</p>");
        container.append("<p>Model: " + motos[id].Model + "</p>");
        container.append("<p>Year: " + motos[id].Year + "</p>");
        container.append("<p>Image: <img src=\"" + motos[id].Image + "\" /></p>");
    });

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
            error: function (jqXHR, exception) {
                alert("Nu s-a putut apela List()\n!" + jqXHR + '\n' + exception);
            }
        });
    });

    $("#insertMoto").click(function() {
        var brand = $("#inputBrand").val();
        var model = $("#inputModel").val();
        var year = $("#inputYear").val();
        var moto = { Brand: brand, Model: model, Year: year, Image: '' };
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
    });

});