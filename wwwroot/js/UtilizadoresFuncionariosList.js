﻿var dataTableFuncionarios;

$(document).ready(function () {
    loadDataTableFuncionarios();
});

function loadDataTableFuncionarios() {
    dataTableFuncionarios = $('#DT_load_Utilizadores_Funcionarios').dataTable({
        "ajax": {
            "url": "/utilizadores/getallfuncionarios/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nome", "width": "12%" },
            { "data": "nif", "width": "12%" },
            { "data": "dataNascimento", "width": "12%" },
            { "data": "morada", "width": "12%" },
            { "data": "telemovel", "width": "12%" },
            { "data": "email", "width": "12%" },
            { "data": "role", "width": "12%" },
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
                        <a class='btn btn-danger ' onclick=Delete('/utilizadores/Delete?id='+${data})>
                            <i class="icon_close_alt2"></i>
                        </a>
                        </div>`;
                }, "width": "16%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Tem a certeza que deseja arquivar este Funcionário?",

        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTableFuncionarios.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}