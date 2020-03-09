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


        $.ajax({
            url: 'NewAct?request=' + JSON.stringify(parameters),
            type: this.method,
            //data: JSON.stringify(parameters),
            //contentType: 'application/json; charset=utf-8',
            success: function (result) {
            },
            error: function (request) {
            }
        });

        return false;
    })

    //document.getElementById("FinishTest").click(submitForm());
});


//$("#FinishTest").click(submitForm());


//function submitForm() {
//    jQuery.ajax({
//        type: "POST",
//        url: "NewAct",
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        data: createObj(),
//        success: function (data) { alert(data); },
//        failure: function (errMsg) {
//            alert(errMsg);
//        }
//    });
//}
//$(function () {
//    $("#FinishTest").click(function () {

//        var parameters = [];
//        var table = document.getElementsByClassName('table')[0];
//        for (var i = 1, count = table.rows.length - 1; i < count; i++) {
//            var columns = table.rows[i].cells,                
//            parameters.push({
//                qId: columns[0].getElementsByClassName('sds')[0].innerText,
//                qAnswer: table.rows[i].getElementsByClassName('form-control')[0].value
//            });
//        };


//        $.ajax({
//            url: 'NewAct',
//            type: this.method,
//            data: JSON.stringify(parameters),
//            contentType: 'application/json; charset=utf-8',
//            success: function (result) {
//            },
//            error: function (request) {
//            }
//        });

//        return false;
//    });
//});




//function createObj() { 
//    var arrayOfTrValues = [];
//    var table = document.getElementsByClassName('table')[0];
//    for (var i = 1, count = table.rows.length - 1; i < count; i++) {
//        var columns = table.rows[i].cells,
//            obj = {};

//        obj[columns[0].getAttribute("name")] = columns[0].getElementsByClassName('sds')[0].innerText;
//        obj[columns[2].getAttribute("name")] = table.rows[i].getElementsByClassName('form-control')[0].value;


//        //arrayOfTrValues[i-1] = obj;
//        arrayOfTrValues.push(obj);
//    }

//    console.log(JSON.stringify(arrayOfTrValues));
//    return JSON.stringify(arrayOfTrValues);
//}

//$.ajax({
//    url: "/Questionnaire/NewAct",
//    type: 'POST',
//    dataType: JSON,
//    contentType: "application/json; charset=utf-8",
//    data: {
//        qId="12",
//        qAnswer="askdjal"
//    },
//    success: function (result) {
//          }
//});