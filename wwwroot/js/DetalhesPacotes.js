$(function () {
    $(".details").click(function () {
        var id = $(this).attr("data-id");
        alert(id);
        $("#modal").load("Details?id=" + id, function () {
            $("#modal").modal();
        })
    });
})