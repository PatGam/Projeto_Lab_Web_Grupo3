﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/servicos/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            
        { "data": "nome", "width": "30%" },
        { "data": "tipoServico", "width": "30%" },
        {
            "data": "servicoId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Servicos/Edit?id=${data}" class='btn btn btn-warning'>
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a href="/Servicos/Details?id=${data}" class='btn btn-primary'>
                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a class='btn btn-danger ' onclick=Delete('/servicos/Delete?id='+${data})>
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
}

function Delete(url) {
    swal({
        title: "Tem a certeza que deseja arquivar este Serviço?",

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
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}