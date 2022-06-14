$('.share').click(function () {
    let input = $('<input>');
    $('body').append(input);

    let qId = $(this).data('id');
    let host = location.protocol + '//' + location.host;

    input.val(host + '/Home/FormQuestionnaire/' + qId).select();
    document.execCommand('copy');
    input.remove();
})

var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

$('.remove').click(function (){

    let isReady = confirm('Вы уверены?')
    if (!isReady) {
        return;
    }

    let questionnaireId = $(this).data('id');

    $.ajax({
        url : '/Home/Delete/',
        method : 'post',
        data : {
            id : questionnaireId
        },
        success : function () {
            location.reload();
        },
        error : function (request, exception) {
            console.log(request);
            console.log(exception);
        }
    });
})