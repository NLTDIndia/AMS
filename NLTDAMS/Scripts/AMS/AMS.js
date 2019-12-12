function SuccessAlert(message) {
    var successMessage = '<div class="alert alert-success alert-dismissible fade show">' + message + '<button type="button" class="close" data-dismiss="alert">&times;</button></div>';
    $('#alert-message').empty().append(successMessage);
}
function InformationAlert(message) {
    var infoMessage = '<div class="alert alert-info alert-dismissible fade show">' + message + '<button type="button" class="close" data-dismiss="alert">&times;</button></div>';
    $('#alert-message').empty().append(infoMessage);
}
function WarningAlert(message) {
    var warningMessage = '<div class="alert alert-warning alert-dismissible fade show">' + message + '<button type="button" class="close" data-dismiss="alert">&times;</button></div>';
    $('#alert-message').empty().append(warningMessage);
}
function DangerAlert(message) {
    var dangerMessage = '<div class="alert alert-danger alert-dismissible fade show">' + message + '<button type="button" class="close" data-dismiss="alert">&times;</button></div>';
    $('#alert-message').empty().append(dangerMessage);
}

function DisplayMessage(messageType, message) {
    if (messageType == '0') {
        SuccessAlert(message);
    }
    else if (messageType == '1') {
        InformationAlert(message);
    }
    else if (messageType == '2') {
        WarningAlert(message);
    }
    else if (messageType == '3') {
        DangerAlert(message);
    }
}
