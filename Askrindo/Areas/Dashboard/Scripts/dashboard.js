$(document).ready(function () {
    Dashboard.Init();
});

var Dashboard = {
    InitRiskTotal: function () {
        $('#dpRiskTotal').datepicker({
            format: "DD/MM/YYYY"
        });

        $('#slRiskClarification').select2();
        $('#slWorkUnit').select2();
    },
    InitRiskMatrix: function () {

    },
    InitDLELoss: function () {

    },
    InitKRIPercentage: function () {

    }
}

var ApiLoad = {

}