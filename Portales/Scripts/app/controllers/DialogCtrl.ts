/// <reference path="../../../Lib/framework/typings/jquery.d.ts"/>
/// <reference path="../../../Lib/framework/typings/uif2.d.ts"/>
/// <reference path="../../../Lib/framework/typings/jquery.validation.d.ts"/>


$(() => {
    new DialogCtrl(); 
});



class DialogCtrl implements uif2.ui.UIController {

    public constructor()
    {
        this.bind();
    }

    bind() {
        $(".btn-confirm-example").click((e) => { this.showConfirm(); });
        $(".btn-alert-example").click((e) => { this.showAlert(); });
        $("#modal-button").click((e) => { this.showModal(); });
       
    }

    load()
    {

    }

    showConfirm() {
        $.UifDialog('confirm', { 'message': 'Desea Confirmar?', 'title': 'Está realmente seguro' }, function (result) {
            $.UifNotify('show', { 'type': 'info', 'message': 'El resultado del dialogo fue: ' + result, 'autoclose': true });
        });
    }

    showAlert() {
        $.UifDialog('alert', { 'message': 'Bienvenido a uif 2 touch' }, function () {
            $.UifNotify('show', { 'type': 'info', 'message': 'Se ha aceptado el mensaje', 'autoclose': true });
        });
    }

    showModal() {
        $('#modalDialog').UifModal('showLocal', 'En Modal');
    }

} 