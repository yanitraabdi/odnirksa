$(document).ready(function () {
    var datepicker = $.fn.datepicker.noConflict(); // return $.fn.datepicker to previously assigned value
    $.fn.bootstrapDP = datepicker; 

    $(".date").bootstrapDP({ format: 'dd/mm/yyyy', autoclose: true });

    $('#ddlLokasi').change(function () {
        var selectedValue = $(this).val();
        $.getJSON('@VirtualPathUtility.ToAbsolute("~/RiskMap/LoadUnitKerja")', { Id: selectedValue }, function (callbackData) {
            var select = $("#ddlUnitKerja");
            select.empty();
            select.append($("<option/>", {
                value: "",
                text: ""
            }));
            $.each(callbackData, function (index, itemData) {
                select.append($("<option/>", {
                    value: itemData.Value,
                    text: itemData.Text
                }));
            });
        });
    });

    //$('#btnFilter').click(function (event) {
    //    event.preventDefault();
    //    event.stopImmediatePropagation();
    //    $('#frmFilterParameter').submit();
    //});
});