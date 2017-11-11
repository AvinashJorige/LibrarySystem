// Common features list .... 

ko.validation.rules.pattern.message = 'Invalid.';
ko.validation.init({
    messageTemplate: null,
    errorElementClass: 'has-error',
    errorMessageClass: 'help-block',
    decorateInputElement: true
}, true);

// Used for date time picker/* Adds the binding dateValue to use with bootstra-datepicker */
ko.bindingHandlers.dateValue = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var dpicker = $(element).datepicker({
            format: "yyyy-mm-dd"
        }).on('changeDate', function (ev) {
                var newDate = new Date(ev.date);
                var value = valueAccessor();
                value(newDate);
            });
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var date = ko.utils.unwrapObservable(valueAccessor());
        if (date) {
            $(element).datepicker('setDate', date);
        }
    }
}

var bindObjects = {
    sideMenu: document.getElementById('sideMenuContainer') ? new MenuDisplayViewModel() : null,
    BranchScripts: document.getElementById('Add_new_Branch') ? new branchFnc() : null, 
    StudentScripts: document.getElementById('StudentContainer') ? new StudentInfo() : null
}

$(document).ready(function () {
    bindingAll();
    if ($(".search-quantity-autoHide").val() == 5) {
        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 10 });
    }
    else {
        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 5 });
    }
    
    $('#search').keyup(function () {
        search_table($(this).val());
        if ($(this).val() == '') {
            if ($(".search-quantity-autoHide").val() == 5) {
                $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 10 });
            }
            else {
                $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: 5 });
            }
        }
    });

    $(".search-quantity").change(function () {
        var options = parseInt($(this).val()) * 2;

        $('.table-search').load().tablePaginate({ navigateType: 'full', fullData: false, buttonPosition: 'after', navigateType: 'navigator', recordPerPage: (parseInt(options)) });
    });

});

function search_table(value) {
    $('.table-search tbody tr').each(function () {
        var found = 'false';
        $(this).each(function () {
            if ($(this).text().toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                found = 'true';
            }
        });
        if (found == 'true') {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });
}

function bindingAll() {
    ko.applyBindings(bindObjects);
}
