$(function () {

    $('#license-form').validator();

    $('#license-form').on('submit', function (e) {

        if (!e.isDefaultPrevented()) {

            $(this).prop("disabled", true);

            $(this).find('button').html(
                `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Sending request...`
            );

            var url = "api/Forms/RequestLicense";

            $.ajax({
                type: "POST",
                url: url,
                data: $(this).serialize(),
                success: function (data) {
                    var messageAlert = 'alert-' + data.type;
                    var messageText = data.message;
                    var alertBox = '<div class="alert ' + messageAlert + ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + messageText + '</div>';

                    if (messageAlert && messageText) {
                        $('#license-form').find('.messages').html(alertBox);
                        $('#license-form')[0].reset();
                    } else {
                        $('#license-form').find('.messages').html('<div class="alert alert-success">' + data.message + '</div>');
                    }

                },
                error: function (request, status, error) {
                    $('#license-form').find('.messages').html('<div class="alert alert-danger">Apologies, an error has occured</div>');
                    $('#license-form').find('button').html('Request License');
                }
            });
            return false;
        }
    })
});