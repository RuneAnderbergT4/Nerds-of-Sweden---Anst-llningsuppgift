$(document)
    .ready(function() {
        $("#key")
            .click(function() {
                if ($(document).width() < 600) {
                    alert($("#key").text());
                }
            });
    });