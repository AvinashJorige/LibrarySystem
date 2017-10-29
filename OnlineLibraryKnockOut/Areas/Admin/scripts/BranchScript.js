function BranchScripts() {
    ko.validation.rules.pattern.message = 'Invalid.';
    ko.validation.init({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        messageTemplate: "customMessageTemplate",
        errorElementClass: 'has-error',
        errorMessageClass: 'help-block',
        decorateInputElement: true
    }, true);
    

    this.BranchName= ko.observable().extend({
        required: {
            message: "Please enter branch name"
        }
    });
    this.validate= function () {
        if (viewModel.errors().length === 0) {
            alert('Thank you.');
        }
        else {
            alert('Please check your submission.');
            viewModel.errors.showAllMessages();
        }
    }

    //viewModel.errors = ko.validation.group(viewModel);
}
