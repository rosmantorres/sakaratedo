
           $(document).ready(function () {

               var table = $('#tablafactura').DataTable({
                   "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                   "language": {
                       "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                   }
               });
               var req;
               var tr;

               $('#tablafactura tbody').on('click', 'a', function () {
                   if ($(this).parent().hasClass('selected')) {
                       req = $(this).parent().prev().prev().prev().text();
                       tr = $(this).parents('tr');//se guarda la fila seleccionada
                       $(this).parent().removeClass('selected');

                   }
                   else {
                       req = $(this).parent().prev().prev().prev().text();
                       tr = $(this).parents('tr');//se guarda la fila seleccionada
                       table.$('tr.selected').removeClass('selected');
                       $(this).parent().addClass('selected');
                   }

               });

               $('#modal-delete').on('show.bs.modal', function (event) {
                   var modal = $(this)
                   modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                   modal.find('#req').text(req)
               })
               $('#btn-eliminar').on('click', function () {
                   table.row(tr).remove().draw();//se elimina la fila de la tabla
                   $('#modal-delete').modal('hide');//se esconde el modal
                   $('#prueba').show();//Muestra el mensaje de agregado exitosamente

               });

           });

