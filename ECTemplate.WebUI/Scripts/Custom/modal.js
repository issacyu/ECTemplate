$(function () {
    var emptyModalContent = function () {
        $('#modal-container').removeData('bs.modal').find('.modal-content').empty();
    };

    $('#modal-container').on('hidden.bs.modal', function () {
        emptyModalContent();
    })
})