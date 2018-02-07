/// <reference path="../../../Lib/framework/typings/jquery.d.ts"/>
/// <reference path="../../../Lib/framework/typings/uif2.d.ts"/>
/// <reference path="../../../Lib/framework/typings/uif2.ts"/>
$(() => {
    new AlertCtrl();
});


class AlertCtrl implements uif2.ui.UIController{
    
    public constructor() {
        this.bind();
    }

    bind() {
        $("#showInfo").click((e) => { this.showInfo(); });
        $("#showSuccess").click((e) => { this.showSuccess(); });
        $("#showWarning").click((e) => { this.showWarning(); });
        $("#showDanger").click((e) => { this.showDanger(); });
    }
    load()
    {

    }

    showInfo() {
        $("#alert").UifAlert('show', 'Bienvenido a UIF2 Touch!', "info");
        $.uif2.helpers.setGlobalTitle("Cambiando el título del Layout");
    }

    showSuccess() {
        $("#alert").UifAlert('show', 'Bienvenido a UIF2 Touch!', "success");
    }

    showWarning() {
        $("#alert").UifAlert('show', 'Bienvenido a UIF2 Touch!', "warning");
    }

    showDanger() {
        $("#alert").UifAlert('show', 'Bienvenido a UIF2 Touch!', "danger");
    }
}