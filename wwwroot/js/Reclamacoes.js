var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Reclamacoes/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "Descricao", "width": "30%" },
            { "data": "DataReclamacao", "width": "30%" },
            { "data": "Resposta", "width": "30%" },
            { "data": "DataResposta", "width": "30%" },
            { "data": "EstadoResposta", "width": "30%" },
            { "data": "EstadoResolução", "width": "30%" },
            { "data": "DataResolucao", "width": "30%" },
            { "data": "ClienteId", "width": "30%" },
            { "data": "FuncionarioId", "width": "30%" },
            
            {
                "data": "reclamacaoId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Reclamacoes/Edit?id=${data}" class='btn btn btn-warning'>
                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a href="/Reclamacoes/Details?id=${data}" class='btn btn-primary'>
                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                        </a>
                        &nbsp;
                        <a class='btn btn-danger ' onclick=Delete('/Reclamacoes/Delete?id='+${data})>
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
        title: "Tem a certeza que deseja arquivar esta Reclamação?",

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