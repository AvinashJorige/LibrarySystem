function PostCallProcess(url, parameters, successCallback) {
    //show loading... image

    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(parameters),
        contentType: 'application/json;',
        async: false,
        dataType: 'json',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            console.log('error');
        }
    });
}

function GetCallProcess(url, successCallback) {
    //show loading... image

    $.ajax({
        type: 'GET',
        url: url,
        async: false,
        contentType: 'application/json;',
        dataType: 'json',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            console.log('error');
        }
    });
}

//PostCallProcess(url, pars, onSuccess);

//function onSuccess(param) {
    //remove loading... image
    //do something with the response
//}