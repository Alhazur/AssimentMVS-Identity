function LinkUpdate(urlPath, targetUpdate) {
    console.log('Link Url: ' + urlPath);
    console.log('Id Target: ' + targetUpdate);

    $.get(urlPath, function (res) {
        $('#' + targetUpdate).replaceWith(res);
    });
}
//Post
function LinkEdit(urlPath, targetUpdate, personId) {
    console.log('Edit Url: ' + urlPath);
    $.post(urlPath,
        {
            Id: personId,
            Name: $('#' + targetUpdate + 'Name').val(),
            Age: $('#' + targetUpdate + 'Age').val(),
        },
        function (res) {
            $('#' + targetUpdate).replaceWith(res);
        });
}

function LinkCreate(urlPath) {
    console.log('Create Url: ' + urlPath);
    $.post(urlPath,
        {
            name: $('#createName').val(),
            age: $('#createAge').val(),
        },
        function (res) {
            $('#AllPersons').append(res);
        });
}