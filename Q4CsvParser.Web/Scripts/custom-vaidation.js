$(document).ready(function () {
   
    $("#csvFileSubmit").button().click(function () { return IsCsvUploadFormValid(); });
    $('#csvUploadForm').validate({
        rules: { file: { required: true, extension: "csv", filesize: 1048576 } },
        messages: { file: "File must be CSV" }
    });
});

function IsCsvUploadFormValid() {
    var isValid = false;
    isValid = $('#csvUploadForm').validate().element($('#file'));   
    return isValid;
}