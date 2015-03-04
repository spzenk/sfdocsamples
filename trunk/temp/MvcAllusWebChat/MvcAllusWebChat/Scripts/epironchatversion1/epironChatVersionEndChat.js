$(function () {
    $('#btn-answer-no').on('click', function () {
        $('#div-end-chat').hide();
        $('#div-final-display').hide();
        $('#btn-answer-yes').css('background-color', '#fff');
    });


    $('#btn-answer-yes').on('click', function () {
        $('#div-final-display').show('slow');
        $('#btn-answer-yes').css('background-color','#00adef');
    });
});