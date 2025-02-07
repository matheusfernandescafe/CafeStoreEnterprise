$(document).ready(function () {
    $(document).on('click', '.dropdown-menu', function (e) {
        e.stopPropagation();
    });

    if ($('[data-toggle="tooltip"]').length > 0) {
        $('[data-toggle="tooltip"]').tooltip();
    }

    if ($('.dropdown-toggle').length > 0) {
        $('.dropdown-toggle').dropdown();
    }
});
