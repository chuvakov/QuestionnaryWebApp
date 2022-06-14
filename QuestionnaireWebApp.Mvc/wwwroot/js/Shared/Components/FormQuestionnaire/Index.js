const isValidFormQuestionnaire = () => {

    let $personeName = $('#personeName'),
        $personAge = $('#personAge');

    if ($personeName.val() == '') {
        $personeName.addClass('is-invalid');
        return false;
    } else {
        $personeName.removeClass('is-invalid');
    }

    let personAge = $personAge.val();
    if (personAge == '') {
        $personAge.addClass('is-invalid');
        $('#PersonAgeFeedback').text('Возраст не введен!')
        return false;
    } else if (personAge <= 0 || personAge > 120) {
        $personAge.addClass('is-invalid');
        $('#PersonAgeFeedback').text('Возраст не корректный!')
        return false;
    } else {
        $personAge.removeClass('is-invalid');
    }

    $personeName.attr('disabled','');
    $personAge.attr('disabled','');
    $('#personSex').attr('disabled','');
    
    return true;
}