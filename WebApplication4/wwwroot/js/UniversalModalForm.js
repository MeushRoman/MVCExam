'use strict'

var Modal = {};

Modal.Controller = "";
Modal.Action = "";

Modal.Get = (controller, action, size, param) => {
    debugger
    Modal.Controller = controller;
    Modal.Action = action;

    $.ajax({
        type: "GET",
        url: `/${controller}/${action}/${param}`,
        success: (response) => {
            $("#ModalDialogSizeId").addClass(`modal-${size}`);
            $("#BodyModal").empty();
            $("#BodyModal").append(response);
            $("#UniversalModalId").modal('show');
        }
    })
};

Modal.Post = () => {
    var form = new FormData(document.forms["UniversalModalForm"]);
    $.ajax({
        type: "POST",
        url: `/${Modal.Controller}/${Modal.Action}`,
        data: form,
        dataType: "json",
        contentType: false,
        processData: false,
        success: (response) => {
            $("#BodyModal").empty();
            $("#BodyModal").append(response);
            $("#UniversalModalId").modal("show");
        }
    })
};

Modal.Post2 = (controller, action) => {
    debugger
    var form = new FormData(document.forms["UniversalModalForm"]);
    $.ajax({
        type: "POST",
        url: `/${controller}/${action}`,
        data: form,
        dataType: "json",
        contentType: false,
        processData: false,
        success: (response) => {          
        }
    })
};