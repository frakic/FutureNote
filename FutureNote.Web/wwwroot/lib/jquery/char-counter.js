$(function () {
    $('#Text').keyup(function (e) {
        var max = 500;
        var len = $(this).val().length;
        var char = max - len;
        $('#char-counter').html(char);
    });
});