/// <reference path="../../../Lib/framework/typings/jquery.d.ts"/>
/// <reference path="../../../Lib/framework/typings/uif2.d.ts"/>
/// <reference path="../../../Lib/framework/typings/jquery.validation.d.ts"/>

$(() => {
    new LocalABMCtrl();
});

class RowModel {
    Empresa: string;
    Ciudad: string;
    Pais: string;
    constructor(empresa: string, ciudad: string, pais: string) {
        this.Empresa = empresa;
        this.Ciudad = ciudad;
        this.Pais = pais;
    }
}

class LocalABMCtrl implements uif2.ui.UIController {

    rowIndex: number = 0;

    public constructor()
    {
        this.bind();
    }

    bind() {
        $('#tableSingle').on("rowAdd", (e) => { this.showAdd(); });
        $('#btnSaveAdd').click((e) => { this.saveAdd(); });
        $('#btnSaveEdit').click((e) => { this.saveEdit(); });
        $('#btnSaveAll').click((e) => { this.saveAll(); });
        $('#tableSingle').on("rowDelete", (e, data, position) => { this.deleteRow(e, data, position); });
        $('#tableSingle').on('rowEdit', (e, data, position) => { this.editRow(e, data, position); });

    }

    load()
    {

    }

    showAdd() {
        $("#addForm").formReset();
        $('#modalAdd').UifModal('showLocal', 'Agregar');
       
        
    }

    saveAdd() {

        if ($("#addForm").valid()) {

            var rowModel = new RowModel($("#addForm").find("#Empresa").val(),
                                        $("#addForm").find("#Ciudad").val(),
                                        $("#addForm").find("#Pais").val());

            $('#tableSingle').UifDataTable('addRow', rowModel);

            $("#editForm").formReset();
            $('#modalAdd').UifModal('hide');
        }
    }

    saveEdit() {

        if ($("#editForm").valid()) {

            var rowModel = new RowModel($("#editForm").find("#Empresa").val(),
                $("#editForm").find("#Ciudad").val(),
                $("#editForm").find("#Pais").val());

            $('#tableSingle').UifDataTable('editRow', rowModel, this.rowIndex);
            $("#editForm").formReset();
            $('#modalEdit').UifModal('hide');
        }
    }

    deleteRow(event: JQueryEventObject, data:any, position: number)
    {
        $('#tableSingle').UifDataTable('deleteRow', position);
    }

    editRow(event: JQueryEventObject, data: any, position: number) {

        this.rowIndex = position;
        $("#editForm").find("#Empresa").val(data.Empresa);
        $("#editForm").find("#Ciudad").val(data.Ciudad);
        $("#editForm").find("#Pais").val(data.Pais);
        $('#modalEdit').UifModal('showLocal', 'Editar');
    }

    saveAll()
    {
        if ($("#mainForm").valid()) {

            $.ajax({
                type: "POST",
                url: "/Documentation/LocalABM",
                data: JSON.stringify({ jobs: $("#tableSingle").UifDataTable('getData'), personalData: $("#mainForm").serializeObject() }),
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            }).done(function (data) {

                if (data.success) {
                    $("#alert").UifAlert('show', 'Los datos han sido guardado correctamente', 'info');
                }
            });
        }
    }
} 