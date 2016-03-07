$(document).ready(function() {
    $('form[data-confirm-message]').on('submit', function(e) {
        var confirmMessage = this.getAttribute('data-confirm-message');

        return confirm(confirmMessage);
    });
});