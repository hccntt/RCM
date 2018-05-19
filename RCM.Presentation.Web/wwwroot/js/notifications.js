﻿$(document).ready(function () {
    var container = $('#notifications-container');
    var detail = $('#notifications-detail-collapsible');

    container.slideToggle(250);

    $('#notifications-dismissable').click(function () {
        container.slideUp(200, function () {
            container.remove();
        });
    });

    $('#notifications-expand').click(function () {
        detail.slideToggle(250);
    });
});