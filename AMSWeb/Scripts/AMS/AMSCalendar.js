$(function () {

    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, "DD/MM/YYYY", true).isValid();
    }
    $('.startDate').datetimepicker({
        ignoreReadonly: true,
        format: "DD/MM/YYYY",
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
   
    $('.endDate').datetimepicker({
        
        format: "DD/MM/YYYY",
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

    $(".startDate").on("dp.change", function (e) {
        $('.endDate').data("DateTimePicker").minDate(e.date);
    });
    $(".endDate").on("dp.change", function (e) {
        $('.startDate').data("DateTimePicker").maxDate(e.date);
    });
});