//Date picker
$(function () {
    $('.datePicker').datetimepicker({
        ignoreReadonly: true,
        format: 'MM/DD/YYYY',
        useCurrent: false
    })
    $('.startDate').datetimepicker({
        ignoreReadonly: true,
        format: 'MM/DD/YYYY',
        useCurrent: false
    });
    var dateToday = new Date(); 
    $('.endDate').datetimepicker({
        ignoreReadonly: true,
        format: 'MM/DD/YYYY',
        useCurrent: false,
        minDate: dateToday
    });
    $(".startDate").on("dp.change", function (e) {
        $('.endDate').data("DateTimePicker").minDate(e.date);
    });
    $(".endDate").on("dp.change", function (e) {
        $('.startDate').data("DateTimePicker").maxDate(e.date);
    });
});