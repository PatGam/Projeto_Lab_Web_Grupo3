var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load_OperadoresDistritosCoimbra').DataTable({
        "ajax": {
            "url": "/utilizadores/getalloperadorescoimbra/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "nome", "width": "20%" },
            { "data": "nif", "width": "20%" },
            { "data": "telemovel", "width": "20%" },

            {
                "data": "utilizadorId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Utilizadores/Edit?id=${data}" class='btn btn btn-warning'>
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a href="/Utilizadores/Details?id=${data}" class='btn btn-primary'>
                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a class='btn btn-danger ' onclick=Delete('/Utilizadores/Delete?id='+${data})>
                            <i class="icon_close_alt2"></i>
                        </a>
                        </div>`;
                }, "width": "40%"
            }

        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
};