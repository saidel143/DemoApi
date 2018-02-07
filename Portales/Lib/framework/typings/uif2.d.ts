/// <reference path="jquery.d.ts"/>
declare module uif2.plugins {
    interface UifDataTableOptions {
        /**
        * Tipo de selección: none/single/multiple
        */
        selectionType?: string;
        /**
        * Url con el origen de datos en formato json que espera la tabla para renderizarse.
        */
        source?: string;
        /**
         * Array con los indices de las columnas a ocultarse. Ej: [0, 5, 8].
         */
        hiddenColumns?: number[];
        /**
         * Array con los nombres de las propiedades para las cuales se requiere un custom binding por columna. Ej: ["Id", "Name#].
         */
        propertyNames?: string[];
        /**
         * Valor booleano que determina si el componente permite edición de items.
         */
        edit?: boolean;
        /**
        * Valor booleano que determina si el componente permite borrado de items.
        */
        delete?: boolean;
        /**
        * Valor booleano que determina si el componente permite agregar items.
        */
        add?: boolean;
        /**
        * Valor booleano que determina si el componente permite el filtrado de registros.
        */
        filter?: boolean;
        /**
        * Valor booleano que determina si el componente permite paginación de registros.
        */
        paginate?: boolean;
        /**
        * Valor booleano que determina si el componente permite paginación de registros.
        */
        pageSize?: boolean;
        /**
        * Titulo de la Tabla.
        */
        title?: string;
        /**
         * Valor booleano que determina si el componente permite exportación de registros.
         */
        exporttocsv?: boolean;
        /**
         * Nombre que recibirá el archivo de exportación.
         */
        exportname?: string;
        /**
         * Valor booleano que determina si el componente permite ordenamiento por columnas.
         */
        order?: boolean
    }


    interface UifAutoCompleteOptions {    /**
     * Url con el origen de datos en formato json que espera la tabla para renderizarse.
     */
        source?: string,
        /**
        * Nombre del campo del json tomado del origen de datos para renderizar los datos de resultado.
        */
        displayKey?: string,
        /**
         * Nombre del parámetro a recibir en el controlador MVC que procesa el search del componente.
         */
        queryParameter?: string,
        /**
         * Longitud minima antes que el componente realicé una petición al backend para procesar la consulta.
         */
        minLenght?: number

    }


    interface UifDialogOptions {    
    
        /**
        * Texto a mostrar en el cuerpo del dialogo.
        */
        message: string

         /**
        * Título del dialogo.
        */
        title?: string;

    }


    interface UifMaskOptions {    
    
        /**
        * patrón a aplicar.
        */
        pattern: string
        options?: any

    }


    interface UifMultiSelectOptions {
        /**
         * Url con el origen de datos en formato json que espera la tabla para renderizarse.
         */
        source?: string,
        /**
         * Campo del json que se utilizará para el Id de cada item.
         */
        id?: string,
        /**
         * Campo del json que se utilizará para mostrar en cada item.
         */
        name?: string,
        /**
         * Texto a mostrar si no se seleccionaron items.
         */
        emptyText?: string,

        /**
        * Cantidad de items a mostrar antes de que se muestra la cantidad de items seleccionados.
        */
        numberDisplayed?: number,
        selectedId?: string

    }

    interface UifNotifyOptions {       
        /**
         * Tipo de mensaje a mostrar: info/success/warning/.
         */
        type: string,
        /**
      * Mensaje a mostrar.
      */
        message: string,
        /**
       * Determina si el control se cerrará automáticamente luego de mostrase sin requerir acción de usuario.
       */
        autoclose?: boolean

    }

    interface UifPanelOptions {
        /**
      * Título del panel.
      */
        title?: string,
        /**
      * Desabilitado.
      */
        disabled?: boolean,
        /**
      * Permite edición.
      */
        edit?: boolean,
        /**
      * Permite collapsarse.
      */
        collapsed?: boolean

    }

    interface UifSelectOptions {
        /**
         * Url con el origen de datos en formato json que espera la tabla para renderizarse.
         */
        source?: string,
        /**
         * Campo del json que se utilizará para el Id de cada item.
         */
        id?: string,
        /**
         * Campo del json que se utilizará para mostrar en cada item.
         */
        name?: string,
        /**
         * Texto a mostrar si no se seleccionó ningún item.
         */
        emptyText?: string,
        /**
         * Id del elemento seleccionado.
         */
        selectedId?: string
    }

    interface StepFuncWizardOption {
        (event: JQueryEventObject, currentIndex: number, newIndex: number): boolean;
    }

    interface FinishFuncWizardOption {
        (event: JQueryEventObject, currentIndex: number): boolean;
    }

    interface UifWizardOptions {
        /**
         * Función a ejecutar en cada cambio de paso del componente.
         */
        onStep: StepFuncWizardOption;

        /**
         * Función a ejecutar al realizar el último paso del componente.
         */
        onFinish: FinishFuncWizardOption;

    }


    interface FuncListOption {
        (deferred: JQueryDeferred<void>, data: Object): JQueryPromise<void>;
    }    


    interface UifListOptions {
        /**
         * Url con el origen de datos en formato json que espera la lista para renderizarse.
         */
        source?: string,
        /**
        * Valor booleano que determina si el componente permite edición de items.
        */
        edit?: boolean;
        /**
        * Valor booleano que determina si el componente permite borrado de items.
        */
        delete?: boolean;
        /**
        * Valor booleano que determina si el componente permite agregar items.
        */
        add?: boolean;
        /**
        * Función callback utilizada por el componente para resolver el agregado de un item por medio del formulario inline.
        */
        addCallback?: FuncListOption;

         /**
        * Función callback utilizada por el componente para resolver la edición de un item por medio del formulario inline.
        */
        editCallback?: FuncListOption;

        /**
        * Función callback utilizada por el componente para resolver la eliminación de un item por medio del formulario inline.
        */
        deleteCallback?: FuncListOption;


         /**
        * Selector utilizado por el componente para proveer el template asociado al agregado de un item por medio del formulario inline.
        */
        addTemplate?: JQuery;

          /**
        * Selector utilizado por el componente para proveer el template asociado a la edición de un item por medio del formulario inline.
        */
        editTemplate?: JQuery;

          /**
        * Selector utilizado por el componente para proveer el template asociado a la eliminación de un item por medio del formulario inline.
        */
        deleteTemplate?: JQuery;


          /**
        * Permite realizar una manipulación directa de la agregación de un item sin utilizar el formulario inline del mismo.
        */
        customAdd?: boolean,

          /**
        * Permite realizar una manipulación directa de la edición de un item sin utilizar el formulario inline del mismo.
        */
        customEdit?: boolean,

          /**
        * Permite realizar una manipulación directa del borrado de un item sin utilizar el formulario inline del mismo.
        */
        customDelete?: boolean,

          /**
        * Cultura utilizada por el componente. Por default: 'es'.
        */
        culture?: string;

          /**
        * Habilita utilizar el ListView de manera local, es decir que no utiliza un origen de datos json, sino que se agregan/editan/elminan items localmente.
        */
        localMode: boolean;

        /**
       * Permite utilizar stylos definidos según el template usado. Ejemplo theme: 'dark'.
       */
        theme?: string;

        

        
    }

} 



interface JQuery {
    /**
     * Muestra o oculta el control UifAlert, el cual permite mostrar o ocultar mensajes en linea.
     * 
     * @param method Comando a realizar: show/hide.
     * @param message Texto del mensaje.
     * @param type Tipo de mensaje: info/success/warning/danger.
     */
    UifAlert(method: string, message: string, type: string): JQuery;

    /**
     * Muestra o oculta el control UifModal, el cual permite mostrar o ocultar ventanas modales.
     * 
     * @param command Comando a realizar: show/showLocal/hide.
     * @param title Título de la modal.
     * @param url (opcional), se utiliza junto con el comando show.
     */
    UifModal(command: string, title?: string, url?: string): JQuery;

    /**
    * Construye el componente UifDataTable, el cual permite mostrar información en forma tabular.
    */
    UifDataTable(): JQuery;


    /**
    * Construye el componente UifList, el cual permite mostrar información en forma de lista, ideal para interfaces de usuario full responsive.
    */
    UifList(options: uif2.plugins.UifListOptions): JQuery;

    /**
    * Construye el componente UifDataTable, el cual permite mostrar información en forma tabular.
    * 
    * @param options Opciones del componente.
    */
    UifDataTable(options: uif2.plugins.UifDataTableOptions): JQuery;

    /**
     * Construye el componente UifDataTable, el cual permite mostrar información en forma tabular.
     * 
     * @param command Comando a realizar: addRow/editRow/deleteRow/getSelected/next/previous/getData/clear/unselect/redraw
     * @param rowData Objeto a asociar al comando addRow o editRow
     * @param rowIndex Indice asociado al comando editRow o deleteRow
     */
    UifDataTable(command: string, rowData?: Object, rowIndex?: number): JQuery;


    /**
     * Construye el componente UifAutoComplete, el cual permite sugerir datos en base a una cadena de texto.
     */
    UifAutoComplete(): JQuery;

    /**
     * Construye el componente UifAutoComplete, el cual permite sugerir datos en base a una cadena de texto.
     * @param options Opciones del componente.
     */
    UifAutoComplete(options: uif2.plugins.UifAutoCompleteOptions): JQuery;

    /**
     * Construye el componente UifAutoComplete, el cual permite sugerir datos en base a una cadena de texto.
    * @param command Comando a realizar: disabled.
    * @param value: true/false. Se utiliza con el comando disabled.
     */
    UifAutoComplete(command: string, value: boolean): JQuery;

    /**
     * Construye el componente UifDatePicker, el cual permite seleccionar una fecha de un calendario.
     */
    UifDatePicker(): JQuery;

    /**
     * Construye el componente UifDatePicker, el cual permite seleccionar una fecha de un calendario.
    * @param command Comando a realizar: disabled.
    * @param value: true/false. Se utiliza con el comando disabled.
     */
    UifDatePicker(command: string, value: boolean): JQuery;


    


    /**
     * Construye el componente UifEditor, el cual permite editar texto ingresado por el usuario.
    * @param command Comando a realizar: setHtmlText/getHtmlText.
    * @param text: Texto a setear en el cuerpo del componente. Se utiliza en conjunto con el comando setHtmlText.
     */
    UifEditor(command: string, text?: string): JQuery;

    /**
     * Construye el componente UifEditor, el cual permite editar texto ingresado por el usuario.
     */
    UifEditor(): JQuery;

    /**
    * Construye el componente UifFileInput, el cual brinda un layout unificado para los input file de html5.
    */
    UifFileInput(): JQuery;

    /**
    * Construye el componente UifInline, el cual permite realizar ediciones en linea conjugado con el componente UifDataTable.
    */
    UifInline(): JQuery;

    /**
     * Construye el componente UifInline, el cual permite realizar ediciones en linea conjugado con el componente UifDataTable.
    * @param command Comando a realizar: show/hide. 
    */
    UifInline(command: string): JQuery;

    /**
     * Construye el componente UifInputSearch, el cual permite tener un marco definido visual para realizar busquedas por un campo de texto.
    */
    UifInputSearch(): JQuery;
    
    /**
     * Construye el componente UifInputSearch, el cual permite tener un marco definido visual para realizar busquedas por un campo de texto.
    * @param command Comando a realizar: disabled.
    * @param value: true/false. Se utiliza con el comando disabled.
    */
    UifInputSearch(command: string, value: boolean): JQuery;

    /**
     * Construye el componente UifMask, el cual permite formatear un contenido en base a una máscara definida.
    */
    UifMask(): JQuery;

    
    /**
     * Construye el componente UifMask, el cual permite formatear un contenido en base a una máscara definida.
     * @param options Opciones del componente.
    */
    UifMask(options: uif2.plugins.UifMaskOptions): JQuery;


    /**
    * Construye el componente UifMultiSelect, el cual permite seleccionar de un DropDown uno o varios valores.
   */
    UifMultiSelect(): JQuery;

    /**
    * Construye el componente UifMultiSelect, el cual permite seleccionar de un DropDown uno o varios valores.
    * @param options Opciones del componente.
   */
    UifMultiSelect(options: uif2.plugins.UifMultiSelectOptions): JQuery;

    /**
     * Construye el componente UifMultiSelect, el cual permite seleccionar de un DropDown uno o varios valores.
     * @param command Comando a realizar:disabled/getSelected.
     * @param value: true/false. Se utiliza con el comando disabled.
    */
    UifMultiSelect(command: string, value?: boolean): JQuery;

    /**
    * Construye el componente UifMultiSelect, el cual permite seleccionar de un DropDown uno o varios valores.
    * @param command Comando a realizar:setSelected.
    * @param values Lista de indices a setear. Ej: [2,4,7]
   */
    UifMultiSelect(command: string, values: number[]): JQuery;


    


    /**
     * Construye el componente UifPanel, el construye un panel visual.
     * @param command Comando a realizar:show/update/close.
     * @param options Opciones del componente. Se utiliza en conjunto con el comando show/update.
    */
    UifPanel(): JQuery;

    /**
     * Construye el componente UifPanel, el construye un panel visual.
     * @param command Comando a realizar:show/update/close.
     * @param options Opciones del componente. Se utiliza en conjunto con el comando show/update.
    */
    UifPanel(options: uif2.plugins.UifPanelOptions): JQuery;

    /**
    * Construye el componente UifSelect, el cual permite seleccionar de un DropDown uno o varios valores.
   */
    UifSelect(): JQuery;
    /**
    * Construye el componente UifSelect, el cual permite seleccionar de un DropDown uno o varios valores.
    @param options Opciones del componente.
   */
    UifSelect(options: uif2.plugins.UifSelectOptions): JQuery;
    /**
    * Construye el componente UifSelect, el cual permite seleccionar de un DropDown uno o varios valores.
    * @param command Comando a realizar: disabled.
    * @param value: true / false.Se utiliza con el comando disabled.
   */
    UifSelect(command: string, value: boolean): JQuery;

    /**
    * Construye el componente UifTab.
    * @param command Comando a realizar: disabled.
    * @param tabId Id del Tab.
    * @param value: true / false.Se utiliza con el comando disabled.
   */
    UifTabHeader(command: string, tabId: string, value: boolean): JQuery;

    /**
    * Construye el componente UifTreeView.
   */
    UifTreeView(): JQuery;
    
    /**
    * Construye el componente UifTreeView.
    * @param command Comando a realizar: getSeleted.
   */
    UifTreeView(command: string): JQuery;


    /**
   * Construye el componente UifTreeView.
   * @param command Comando a realizar: createNode.
    * @param parent Id del objecto padre obtenido del método getSelected.
    * @param node Nodo a insertar.
  */
    UifTreeView(command: string, parent: number[], node: any): JQuery;


    /**
   * Construye el componente UifTreeView.
   * @param command Comando a realizar: renameNode.
    * @param parent Id del objecto a actualizar.
    * @param value Nuevo valor.
  */
    UifTreeView(command: string, parent: number[], value: string): JQuery;

    /**
  * Construye el componente UifWizard.
  * @param options Opciones del componente.
 */
    UifWizard(options: uif2.plugins.UifWizardOptions): JQuery;


    formReset(): JQuery;

    serializeObject(): JQuery;

    UifRedirect(url: string): JQuery;

    Uif_ViewModelToJsonObject(viewModel: any): JQuery;

    UifLayout(): JQuery;



}



declare module uif2.layout
{

    interface core
    {
        defaults: any;
        helpers: UIHelpers;
    }


    interface SetGlobalTitle {
        (title: string): JQuery;
    }

    interface UIHelpers {
        setGlobalTitle: SetGlobalTitle;
    }
}


interface JQueryStatic
{
    /**
     * Construye el componente UifDialog, el cual permite mostrar un Dialogo de Confirmación o Alerta.
    * @param command Comando a realizar: comfirm/alert.
    * @param options: Opciones del componente.
    * @callback: Función que maneja el resultado del Dialogo.
     */
    UifDialog(command: string, options: uif2.plugins.UifDialogOptions, callback: Function): JQuery;

    /**
    * Construye el componente UifMultiSelect, el cual permite seleccionar de un DropDown uno o varios valores.
    * @param command Comando a realizar:show/update/close.
    * @param options Opciones del componente. Se utiliza en conjunto con el comando show/update.
   */
    UifNotify(command: string, options?: uif2.plugins.UifNotifyOptions): JQuery;


     /**
    * Brinda acceso a los elementos de configuración y helpers de UIF 2 Touch.
   */
    uif2: uif2.layout.core;

}

