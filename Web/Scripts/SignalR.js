hub = $.connection.real;

hub.client.notify = function() {
    toastr.info("Incoming Message");
}

