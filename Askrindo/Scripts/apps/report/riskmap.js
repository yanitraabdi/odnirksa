$(document).ready(function () {
    $("##params").accordion({
        collapsible: true,
        active: -1
    });

    $(".tanggal").datepicker({ dateFormat: "dd/mm/yy" });

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
});