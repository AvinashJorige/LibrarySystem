function BranchScripts() {
    ko.validation.rules.pattern.message = 'Invalid.';
    ko.validation.init({
        messageTemplate: null,
        errorElementClass: 'has-error',
        errorMessageClass: 'help-block',
        decorateInputElement: true
    }, true);

    this.BranchName = ko.observable();

    this.viewModel = ko.validatedObservable([
    this.BranchName.extend({
        required: {
            message: "Please enter branch name"
        }
    })]);

    this.validate = function () {
        if (!this.BranchScripts.viewModel.isValid()) {
            this.BranchScripts.viewModel.errors.showAllMessages()
        } 
        else  {
            alert('good job');
        }
    }

    this.clear = function () {
        this.BranchScripts.BranchName(null);
        this.BranchScripts.BranchName.isModified(false);
    }



}
