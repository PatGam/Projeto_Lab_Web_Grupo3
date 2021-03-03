var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load_Contrato').DataTable({
        "ajax": {
            "url": "/contratos/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "dataInicio", "width": "20%" },
            { "data": "dataFim", "width": "20%" },
            { "data": "valorFinal", "width": "20%" },
            { "data": "telefone", "width": "20%"},
            {
                "data": "contratoId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Promocoes/Edit?id=${data}" class='btn btn btn-warning'>
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a href="/Promocoes/Details?id=${data}" class='btn btn-primary'>
                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a class='btn btn-danger ' onclick=Delete('/promocoes/Delete?id='+${data})>
                            <i class="icon_close_alt2"></i>
                        </a>
                        </div>`;
                }, "width": "20%"
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
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
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