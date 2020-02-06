﻿$(function () {
    $('.startDate').datetimepicker({
        ignoreReadonly: true,
        format: "MM/DD/YYYY",
        useCurrent: false,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down",
            previous: "fa fa-chevron-left",
            next: "fa fa-chevron-right",
            today: "fa fa-clock-o",
            clear: "fa fa-trash-o"
        }
    });
    var dateToday = new Date();
    $('.endDate').datetimepicker({
        ignoreReadonly: true,
        format: "MM/DD/YYYY",
        useCurrent: false,
        minDate: dateToday,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down",
            previous: "fa fa-chevron-left",
            next: "fa fa-chevron-right",
            today: "fa fa-clock-o",
            clear: "fa fa-trash-o"
        }
    });
    $(".startDate").on("dp.change", function (e) {
        $('.endDate').data("DateTimePicker").minDate(e.date);
    });
    $(".endDate").on("dp.change", function (e) {
        $('.startDate').data("DateTimePicker").maxDate(e.date);
    });
});