$(document).ready(function () {
    $('#tabladojos').DataTable();

    var table = $('#tabladojos').DataTable();
    var dojo;
    var tr;

    $('#tabladojos tbody').on('click', 'a', function () {
        if ($(this).parent().hasClass('selected')) {
            dojo = $(this).parent().prev().prev().prev().prev().prev().text();
            tr = $(this).parents('tr');//se guarda la fila seleccionada
            $(this).parent().removeClass('selected');

        }
        else {
            dojo = $(this).parent().prev().prev().prev().prev().prev().text();
            tr = $(this).parents('tr');//se guarda la fila seleccionada
            table.$('tr.selected').removeClass('selected');
            $(this).parent().addClass('selected');
        }
    });



    $('#modal-delete').on('show.bs.modal', function (event) {
        var modal = $(this)
        modal.find('.modal-title').text('Eliminar Dojo:  ' + dojo)
        modal.find('#dojo').text(dojo)
    })
    $('#btn-eliminar').on('click', function () {
        table.row(tr).remove().draw();//se elimina la fila de la tabla
        $('#modal-delete').modal('hide');//se esconde el modal
    });


});