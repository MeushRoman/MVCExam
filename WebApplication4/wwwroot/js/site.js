// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    document.getElementsByName("btnClick").forEach(elem => elem.onclick = function () {
        $("#SurvId").attr('value', $(this).attr('data-id'));
    });

    $("#FinishTest").click(function () {
        var parameters = [];
        var table = document.getElementsByClassName('table')[0];
        for (var i = 1, count = table.rows.length - 1; i < count; i++) {
            var columns = table.rows[i].cells;
            parameters.push({
                qId: columns[0].getElementsByClassName('sds')[0].innerText,
                qAnswer: table.rows[i].getElementsByClassName('form-control')[0].value
            });
        };

        document.location.href = 'Result?request=' + JSON.stringify(parameters) + '&surveyId=' + document.getElementById('sId').innerHTML; 

        //$.ajax({
        //    url: 'CheckSum?request=' + JSON.stringify(parameters) + '&surveyId=' + document.getElementById('sId').innerHTML,
        //    type: "get"
        //});
    })
});

