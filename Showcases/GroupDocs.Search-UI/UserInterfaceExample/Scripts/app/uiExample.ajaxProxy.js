uiExample.ajaxProxy = function () {

    var sendAjaxRequest = function (url, jsonRequest, onSuccessCallback, onFailureCallback, onComplete) {


        var opts = {lines: 9, length: 0, width: 15, radius: 30, corners: 1, rotate: 30, direction: 1, color: '#000', speed: 0.8, 
            trail: 60, shadow: false, hwaccel: false, className: 'spinner', zIndex: 2e9, top: '50%', left: '50%' 
        };

        //var target = document.getElementById('body');
        //var spinner = new Spinner(opts).spin(target);
        $.blockUI();

        var onFailure = function (data) {
            if (data.status == 200) {
                window.location.href = uiExample.urls.startPage;
            } else {
                var response = {
                    Message: uiExample.messages.technicalError
                };
                if (onFailureCallback) {
                    onFailureCallback(response);
                } else {
                    sweetAlert(uiExample.messages.technicalError);
                }
            }
        };

        var onSuccess = function (response) {
            if (response && response.Status === true && onSuccessCallback) {
                onSuccessCallback(response);
            }
            else {
                sweetAlert(response.Message);
            }
        };

        $.ajax({
            url: url,
            type: 'POST',
            data: jsonRequest,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: onSuccess,
            error: onFailure,
            complete: onComplete
        }).always(function () {
            //spinner.stop();
            $.unblockUI();
        });

    };

    return {
        initModel: function (onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.initModel, null, onSuccess, onFailure, onComplete);
        },
        loadDocument: function (jsonRequest, onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.loadDocument, jsonRequest, onSuccess, onFailure, onComplete);
        },
        createIndex: function (jsonRequest, onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.createIndex, jsonRequest, onSuccess, onFailure, onComplete);
        },
        deleteIndex: function (jsonRequest, onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.deleteIndex, jsonRequest, onSuccess, onFailure, onComplete);
        },
        addFolderToIndex: function (jsonRequest, onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.addFolderToIndex, jsonRequest, onSuccess, onFailure, onComplete);
        },
        runSearch: function (jsonRequest, onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.runSearch, jsonRequest, onSuccess, onFailure, onComplete);
        },
        getDefaultFolders: function (onSuccess, onFailure, onComplete) {
            sendAjaxRequest(uiExample.urls.getDefaultFolders, null, onSuccess, onFailure, onComplete);
        },
    };
}();
