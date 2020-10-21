// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(function () {
    xsrfToken = document.getElementsByName("__RequestVerificationToken")[0].value;
    $('#dropArea').filedrop({
        url: window.location.href + '?handler=UploadFile',
        headers: { "XSRF-TOKEN": xsrfToken },
        allowedfilestypes: ['image/jpeg', 'image/png', 'image/gif'],
        allowedfileextensions: [
            '.jpg', '.jpeg', '.png', '.gif', '.JPG', '.JPEG', '.PNG'],
        paramname: 'file',
        maxfiles: 1,
        maxfilessize: 5, // in MB
        dragOver: function () {
            $('#dropArea').addClass('active-drop');
        },
        dragLeave: function () {
            $('#dropArea').removeClass('active-drop');
        },
        drop: function () {
            $('#dropArea').removeClass('active-drop');
        },
        afterAll: function (e) {
            $('#dropArea').html('File uploaded successfully.');
        },
        uploadFinished: function (i, file, response, time) {
            $('#picFileName').val(file.name);
        }
    });
});