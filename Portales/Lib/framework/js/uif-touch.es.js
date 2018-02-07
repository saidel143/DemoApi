(function($) {
	$.validator.addMethod(
				"date",
				function (value, element) {
					var bits = value.match(/([0-9]+)/gi), str;
					if (!bits)
						return this.optional(element) || false;
					str = bits[1] + '/' + bits[0] + '/' + bits[2];
					return this.optional(element) || !/Invalid|NaN/.test(new Date(str));
				},
				"Por favor ingrese una fecha en el formato dd/mm/yyyy"
			);

	jQuery.extend(jQuery.validator.messages, {
		required: "obligatorio.",
		remote: "Por favor, rellena este campo.",
		email: "Por favor, escribe una direcci�n de correo v�lida",
		url: "Por favor, escribe una URL v�lida.",
		date: "Por favor, escribe una fecha v�lida.",
		dateISO: "Por favor, escribe una fecha (ISO) v�lida.",
		number: "Por favor, escribe un n�mero entero v�lido.",
		digits: "Por favor, escribe s�lo d�gitos.",
		creditcard: "Por favor, escribe un n�mero de tarjeta v�lido.",
		equalTo: "Por favor, escribe el mismo valor de nuevo.",
		accept: "Por favor, escribe un valor con una extensi�n aceptada.",
		maxlength: jQuery.validator.format("Por favor, no escribas m�s de {0} caracteres."),
		minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
		rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
		range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}."),
		max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}."),
		min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
	});

}(jQuery));

$.uif2.defaults.decimalSeparator = ".";
$.uif2.defaults.thousandsSeparator = ",";
$.uif2.defaults.decimalPlaces = "3";

$.fn.UifListView.cultures['es'] = {
	emptyText: "No se encontraron registros.",
	saveSuccess: "Los datos se han guardado correctamente",
	save: "Guardar Registro",
	cancel: "Cancelar",
	addText: "Agregar Registro",
	saveError: "Lo sentimos ha ocurrido un error, intente nuevamente"
};


