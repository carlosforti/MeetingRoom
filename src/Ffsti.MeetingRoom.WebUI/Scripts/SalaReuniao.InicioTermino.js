$(document).ready(function () {
    $('#Inicio').datetimepicker({
        hourMin: 8,
        hourMax: 20,
        dateFormat: 'dd/mm/yy',
        timeFormat: 'hh:mm',
        onClose: function (dateText, inst) {
            var endDateTextBox = $('#Termino');
            if (endDateTextBox.val() != '') {
                var testStartDate = new Date(dateText);
                var testEndDate = new Date(endDateTextBox.val());
                if (testStartDate > testEndDate)
                    endDateTextBox.val(dateText);
            }
            else {
                endDateTextBox.val(dateText);
            }
        },
        onSelect: function (selectedDateTime) {
            var start = $(this).datetimepicker('getDate');
            $('#Termino').datetimepicker('option', 'minDate', new Date(start.getTime()));
        },
    });
    $('#Termino').datetimepicker({
        hourMin: 8,
        hourMax: 20,
        dateFormat: 'dd/mm/yy',
        timeFormat: 'hh:mm',
        onClose: function (dateText, inst) {
            var startDateTextBox = $('#Inicio');
            if (startDateTextBox.val() != '') {
                var testStartDate = new Date(startDateTextBox.val());
                var testEndDate = new Date(dateText);
                if (testStartDate > testEndDate)
                    startDateTextBox.val(dateText);
            }
            else {
                startDateTextBox.val(dateText);
            }
        },
        onSelect: function (selectedDateTime) {
            var end = $(this).datetimepicker('getDate');
            $('#Inicio').datetimepicker('option', 'maxDate', new Date(end.getTime()));
        }
    });
});